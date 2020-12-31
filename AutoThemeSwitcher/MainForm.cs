using AutoThemeSwitcher.Model;
using Microsoft.Win32;
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
		public MainForm()
		{
			InitializeComponent();
		}

		private async void MainForm_Load(object sender, EventArgs e)
		{
			GetCurrentColorMode();
			await GetGeoLocation();
			GetSunPhases(new Location { Lat = double.Parse(tbLatitude.Text), Long = double.Parse(tbLongitude.Text) });
			lightTime.Value = DateTime.Today.Add(new TimeSpan(08, 00, 00));
			darkTime.Value = DateTime.Today.Add(new TimeSpan(18, 00, 00));
		}

		private void GetCurrentColorMode()
		{
			using var regkey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Themes\Personalize", false);
			var currentSystem = GetColorMode(regkey, "SystemUsesLightTheme");
			var currentApps = GetColorMode(regkey, "AppsUseLightTheme");
			tbCurrentSystem.Text = currentSystem.ToString();
			tbCurrentApps.Text = currentApps.ToString();
		}

		private async Task GetGeoLocation()
		{
			var accessStatus = await Geolocator.RequestAccessAsync();
			if (accessStatus == GeolocationAccessStatus.Allowed)
			{
				var locator = new Geolocator();
				var position = await locator.GetGeopositionAsync();
				tbLatitude.Text = position.Coordinate.Latitude.ToString();
				tbLongitude.Text = position.Coordinate.Longitude.ToString();
			}
			else
				MessageBox.Show("Please change setting ms-settings:privacy-location for full functionality.", "Geo location access not allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
		}

		private ColorMode GetColorMode(RegistryKey regkey, string valueName)
		{
			var value = (int?)regkey.GetValue(valueName);
			// Default seems to be light.
			return value switch { 0 => ColorMode.Dark, _ => ColorMode.Light };
		}

		private void GetSunPhases(Location location)
		{
			var today = DateTime.Today;
			var sunPhases = SunCalc.GetSunPhases(today, location.Lat, location.Long)
					.Select(sp => new SunPhaseListItem(sp.Name.Value, sp.PhaseTime.ToLocalTime() - today))
					.OrderBy(sp => sp.Value)
					.ToArray();

			cbLightSunphase.ValueMember = nameof(SunPhaseListItem.Value);
			cbLightSunphase.DisplayMember = nameof(SunPhaseListItem.Display);
			var defaultLight = sunPhases.Single(sp => sp.Name == SunCalcNet.Model.SunPhaseName.Sunrise.Value); // TODO: Get from store
			cbLightSunphase.Items.AddRange(sunPhases);
			cbLightSunphase.SelectedItem = defaultLight;

			cbDarkSunphase.ValueMember = nameof(SunPhaseListItem.Value);
			cbDarkSunphase.DisplayMember = nameof(SunPhaseListItem.Display);
			var defaultDark = sunPhases.Single(sp => sp.Name == SunCalcNet.Model.SunPhaseName.Sunset.Value); // TODO: Get from store
			cbDarkSunphase.Items.AddRange(sunPhases);
			cbDarkSunphase.SelectedItem = defaultDark;
		}
	}
}
