using AutoThemeSwitcher.Model;
using SunCalcNet;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.Devices.Geolocation;

namespace AutoThemeSwitcher
{
	public partial class MainForm : Form
	{
		private readonly SettingsRepository _settingsRepository;
		private readonly ScheduledTasksWrapper _scheculedTasksWrapper;
		private readonly ColorModeService _colorModeService;

		public MainForm()
		{
			InitializeComponent();
			_settingsRepository = new SettingsRepository();
			_scheculedTasksWrapper = new ScheduledTasksWrapper();
			_colorModeService = new ColorModeService();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			UseWaitCursor = true;
			toolTip1.SetToolTip(gbLocation, " ");
			toolTip1.SetToolTip(lblLatitude, " ");
			toolTip1.SetToolTip(lblLongitude, " ");
			toolTip1.SetToolTip(btnSystemPos, " ");
			toolTip1.SetToolTip(llMaps, "In Maps, right-click on a position and then left-click the first row in the popup to copy location co-ordinates.");
			toolTip1.SetToolTip(btnPastePosition, "Text on clipboard must be formatted like this example: 55.508388467200604, 14.315097421559296");
			PopulateCurrentColorMode();
			PopulateCurrentSettings();
			UseWaitCursor = false;
		}

		private void PopulateCurrentColorMode()
		{
			var currentColorMode = _colorModeService.GetCurrent();
			lblColorMode.Text = lblColorMode.Text.Replace("{system}", currentColorMode.System.ToString());
			lblColorMode.Text = lblColorMode.Text.Replace("{apps}", currentColorMode.Apps.ToString());
		}

		private void PopulateCurrentSettings()
		{
			var settings = _settingsRepository.LoadSettings();
			PopulateLocation(settings.Location);
			rbLightTime.Checked = settings.LightAt.Type == TimeType.Fixed;
			lightTime.Value = settings.LightAt.FixedTime;
			rbLightSunphase.Checked = settings.LightAt.Type == TimeType.Sun;
			SelectItem(cbLightSunphase, settings.LightAt.SunPhase);
			rbDarkTime.Checked = settings.DarkAt.Type == TimeType.Fixed;
			darkTime.Value = settings.DarkAt.FixedTime;
			rbDarkSunphase.Checked = settings.DarkAt.Type == TimeType.Sun;
			SelectItem(cbDarkSunphase, settings.DarkAt.SunPhase);
		}

		private async void btnSystemPos_Click(object sender, EventArgs e) =>
            PopulateLocation(await GetGeoLocationFromSystem());

        private void llMaps_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => 
			Process.Start(new ProcessStartInfo("https://google.com/maps") { UseShellExecute = true });

        private void btnPastePosition_Click(object sender, EventArgs e) =>
			PopulateLocation(GetLocationFromClipboard());

		private void PopulateLocation(Location location)
		{
			if (location != null)
			{
				tbLatitude.Text = location.Lat.ToString();
				tbLongitude.Text = location.Long.ToString();
				GetSunPhases(location);
				rbLightSunphase.Enabled = true;
				cbLightSunphase.Enabled = true;
				rbDarkSunphase.Enabled = true;
				cbDarkSunphase.Enabled = true;
			}
		}

		private static void SelectItem(ComboBox cb, string sunPhaseName)
		{
			if (sunPhaseName != null)
				foreach (SunPhaseListItem item in cb.Items)
					if (item.Value.Name.Value == sunPhaseName)
						cb.SelectedItem = item;
		}

		private async Task<Location> GetGeoLocationFromSystem()
		{
			UseWaitCursor = true;

			var accessStatus = await Geolocator.RequestAccessAsync();
			if (accessStatus == GeolocationAccessStatus.Allowed)
			{
				var locator = new Geolocator();
				var position = await locator.GetGeopositionAsync();
				UseWaitCursor = false;
				return new Location { Lat = position.Coordinate.Latitude, Long = position.Coordinate.Longitude };
			}
			else
			{
				UseWaitCursor = false;
				var response = MessageBox.Show("Do you want to open system settings to allow it?", "Geo location access not allowed", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                switch (response)
                {
                    case DialogResult.Yes:
						Process.Start(new ProcessStartInfo("ms-settings:privacy-location") { UseShellExecute = true });
                        break;
					default:
						break;
				}
				return null;
			}
		}

		private static Location GetLocationFromClipboard()
		{
			var text = Clipboard.GetText();
			if (string.IsNullOrEmpty(text))
			{
				MessageBox.Show("No text on clipboard", "Paste Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return null;
			}
			else
			{
				var parts = text.Split(',');
				if (parts.Length == 2 && TryParseLocation(parts[0], parts[1], CultureInfo.InvariantCulture, out var location))
					return location;
				var message = "Text on clipboard:" + Environment.NewLine +
					text + Environment.NewLine +
					"is not a position. It must be formatted like the follwing example:" + Environment.NewLine +
					"55.508388467200604, 14.315097421559296";
				MessageBox.Show(message, "Paste Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return null;
			}
		}

		private static bool TryParseLocation(string latitude, string longitude, IFormatProvider formatProvider, out Location location)
        {
			if (double.TryParse(latitude.Trim(), NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign, formatProvider, out var lat) &&
				double.TryParse(longitude.Trim(), NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign, formatProvider, out var @long))
			{
				location = new Location { Lat = lat, Long = @long };
				return true;
			}
			else
            {
				location = null;
				return false;
            }
        }

		private void GetSunPhases(Location location)
		{
			var today = DateTime.Today;
			var sunPhases = SunCalc.GetSunPhases(today, location.Lat, location.Long)
					.Select(sp => new SunPhaseListItem(sp))
					.OrderBy(sp => sp.Value.PhaseTime)
					.ToArray();

			cbLightSunphase.SelectedIndex = -1;
			cbLightSunphase.Items.Clear();
			cbLightSunphase.ValueMember = nameof(SunPhaseListItem.Value);
			cbLightSunphase.DisplayMember = nameof(SunPhaseListItem.Display);
			cbLightSunphase.Items.AddRange(sunPhases);

			cbDarkSunphase.SelectedIndex = -1;
			cbDarkSunphase.Items.Clear();
			cbDarkSunphase.ValueMember = nameof(SunPhaseListItem.Value);
			cbDarkSunphase.DisplayMember = nameof(SunPhaseListItem.Display);
			cbDarkSunphase.Items.AddRange(sunPhases);
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			if ((rbLightSunphase.Checked && cbLightSunphase.SelectedItem == null) ||
				(rbDarkSunphase.Checked && cbDarkSunphase.SelectedItem == null))
			{
				MessageBox.Show(this, "Please select a sun-phase!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}

			Location location = null;
			if ((rbLightSunphase.Checked || rbDarkSunphase.Checked) && !TryParseLocation(tbLatitude.Text, tbLongitude.Text, CultureInfo.CurrentCulture, out location))
			{
				MessageBox.Show(this, "Please enter a valid location!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}

			var settings = new Settings
			{
				Location = location,
				LightAt = new TimeSetting
				{
					FixedTime = lightTime.Value,
					SunPhase = ((SunPhaseListItem)cbLightSunphase.SelectedItem)?.Value.Name.Value,
					Type = rbLightSunphase.Checked ? TimeType.Sun : TimeType.Fixed
				},
				DarkAt = new TimeSetting
				{
					FixedTime = darkTime.Value,
					SunPhase = ((SunPhaseListItem)cbDarkSunphase.SelectedItem)?.Value.Name.Value,
					Type = rbDarkSunphase.Checked ? TimeType.Sun : TimeType.Fixed
				}
			};
			
			_settingsRepository.SaveSettings(settings);
			ScheduleTask();
			MessageBox.Show(this, "You can now close this app.", "All set", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void ScheduleTask()
		{
			var lightAt = rbLightTime.Checked
				? lightTime.Value
				: ((SunPhaseListItem)cbLightSunphase.SelectedItem).Value.PhaseTime;
			var darkAt = rbDarkTime.Checked
				? darkTime.Value
				: ((SunPhaseListItem)cbDarkSunphase.SelectedItem).Value.PhaseTime;

			_scheculedTasksWrapper.SaveScheduledTask(lightAt, darkAt);
		}
    }
}
