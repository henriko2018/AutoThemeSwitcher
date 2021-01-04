using AutoThemeSwitcher.Model;
using SunCalcNet;
using System;
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

		private async void MainForm_Load(object sender, EventArgs e)
		{
			UseWaitCursor = true;
			PopulateCurrentColorMode();
			var location = await GetGeoLocation();
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
			PopulateCurrentSettings();
			UseWaitCursor = false;
		}

		private void PopulateCurrentColorMode()
		{
			var currentColorMode = _colorModeService.GetCurrent();
			tbCurrentSystem.Text = currentColorMode.System.ToString();
			tbCurrentApps.Text = currentColorMode.Apps.ToString();
		}

		private void PopulateCurrentSettings()
		{
			var settings = _settingsRepository.LoadSettings();
			rbLightTime.Checked = settings.LightAt.Type == TimeType.Fixed;
			lightTime.Value = settings.LightAt.FixedTime;
			rbLightSunphase.Checked = settings.LightAt.Type == TimeType.Sun;
			SelectItem(cbLightSunphase, settings.LightAt.SunPhase);
			rbDarkTime.Checked = settings.DarkAt.Type == TimeType.Fixed;
			darkTime.Value = settings.DarkAt.FixedTime;
			rbDarkSunphase.Checked = settings.DarkAt.Type == TimeType.Sun;
			SelectItem(cbDarkSunphase, settings.DarkAt.SunPhase);
		}

		private void SelectItem(ComboBox cb, string sunPhaseName)
		{
			if (sunPhaseName != null)
				foreach (SunPhaseListItem item in cb.Items)
					if (item.Value.Name.Value == sunPhaseName)
						cb.SelectedItem = item;
		}

		private async Task<Location> GetGeoLocation()
		{
			var accessStatus = await Geolocator.RequestAccessAsync();
			if (accessStatus == GeolocationAccessStatus.Allowed)
			{
				var locator = new Geolocator();
				var position = await locator.GetGeopositionAsync();
				return new Location { Lat = position.Coordinate.Latitude, Long = position.Coordinate.Longitude };
			}
			else
			{
				UseWaitCursor = false;
				MessageBox.Show("Please change setting ms-settings:privacy-location for full functionality.", "Geo location access not allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return null;
			}
		}

		private void GetSunPhases(Location location)
		{
			var today = DateTime.Today;
			var sunPhases = SunCalc.GetSunPhases(today, location.Lat, location.Long)
					.Select(sp => new SunPhaseListItem(sp))
					.OrderBy(sp => sp.Value.PhaseTime)
					.ToArray();

			cbLightSunphase.ValueMember = nameof(SunPhaseListItem.Value);
			cbLightSunphase.DisplayMember = nameof(SunPhaseListItem.Display);
			cbLightSunphase.Items.AddRange(sunPhases);

			cbDarkSunphase.ValueMember = nameof(SunPhaseListItem.Value);
			cbDarkSunphase.DisplayMember = nameof(SunPhaseListItem.Display);
			cbDarkSunphase.Items.AddRange(sunPhases);
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			if ((rbLightSunphase.Checked && cbLightSunphase.SelectedItem == null) ||
				(rbDarkSunphase.Checked && cbDarkSunphase.SelectedItem == null))
			{
				MessageBox.Show("Please select a sun-phase!");
				return;
			}

			var settings = new Settings
			{
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
		}

		private void ScheduleTask()
		{
			var lightAt = rbLightTime.Checked
				? lightTime.Value
				: ((SunPhaseListItem)cbLightSunphase.SelectedItem).Value.PhaseTime;
			var darkAt = rbDarkTime.Checked
				? darkTime.Value
				: ((SunPhaseListItem)cbDarkSunphase.SelectedItem).Value.PhaseTime;
			if (lightAt < DateTime.Now)
				lightAt += TimeSpan.FromDays(1);
			if (darkAt < DateTime.Now)
				darkAt += TimeSpan.FromDays(1);

			_scheculedTasksWrapper.SaveScheduledTask(lightAt, darkAt);
		}
	}
}
