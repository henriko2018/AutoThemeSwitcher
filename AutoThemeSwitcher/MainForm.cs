using AutoThemeSwitcher.Model;
using Microsoft.Win32;
using Microsoft.Win32.TaskScheduler;
using SunCalcNet;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
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

		private async System.Threading.Tasks.Task GetGeoLocation()
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
			{
				MessageBox.Show("Please change setting ms-settings:privacy-location for full functionality.", "Geo location access not allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				rbDarkSunphase.Enabled = false;
				rbDarkSunphase.Checked = false;
				rbDarkTime.Checked = true;
				rbLightSunphase.Enabled = false;
				rbLightSunphase.Checked = false;
				rbLightTime.Checked = true;
			}
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
					.Select(sp => new SunPhaseListItem(sp))
					.OrderBy(sp => sp.Value.PhaseTime)
					.ToArray();

			cbLightSunphase.ValueMember = nameof(SunPhaseListItem.Value);
			cbLightSunphase.DisplayMember = nameof(SunPhaseListItem.Display);
			var defaultLight = sunPhases.Single(sp => sp.Value.Name.Value == SunCalcNet.Model.SunPhaseName.Sunrise.Value); // TODO: Get from store
			cbLightSunphase.Items.AddRange(sunPhases);
			cbLightSunphase.SelectedItem = defaultLight;

			cbDarkSunphase.ValueMember = nameof(SunPhaseListItem.Value);
			cbDarkSunphase.DisplayMember = nameof(SunPhaseListItem.Display);
			var defaultDark = sunPhases.Single(sp => sp.Value.Name.Value == SunCalcNet.Model.SunPhaseName.Sunset.Value); // TODO: Get from store
			cbDarkSunphase.Items.AddRange(sunPhases);
			cbDarkSunphase.SelectedItem = defaultDark;
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			var settings = new Settings
			{
				LightAt = new TimeSetting
				{
					FixedTime = lightTime.Value,
					SunPhase = ((SunPhaseListItem)cbLightSunphase.SelectedItem)?.Value,
					Type = rbLightSunphase.Checked ? TimeType.Sun : TimeType.Fixed
				},
				DarkAt = new TimeSetting
				{
					FixedTime = darkTime.Value,
					SunPhase = ((SunPhaseListItem)cbDarkSunphase.SelectedItem)?.Value,
					Type = rbDarkSunphase.Checked ? TimeType.Sun : TimeType.Fixed
				}
			};

			var folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "AutoThemeSwitcher");
			Directory.CreateDirectory(folderPath);
			var filePath = Path.Combine(folderPath, "Settings.json");
			File.WriteAllText(filePath, Newtonsoft.Json.JsonConvert.SerializeObject(settings));

			SaveScheduledTasks(settings);
		}

		private void SaveScheduledTasks(Settings settings)
		{
			SaveScheduledTask("light", settings.LightAt);
			SaveScheduledTask("dark", settings.DarkAt);
		}

		private void SaveScheduledTask(string lightOrDark, TimeSetting timeSetting)
		{
			var taskName = "Switch to " + lightOrDark;
			var task = TaskService.Instance.FindTask(taskName);
			if (task == null)
			{
				task = TaskService.Instance.AddTask(
					path: $"AutoThemeSwitcher\\{taskName}",
					trigger: new DailyTrigger(),
					//action: new ExecAction(Assembly.GetExecutingAssembly().Location, $"--{lightOrDark}"),
					action: new ExecAction(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName, $"--{lightOrDark}"),
					description: "Switch theme/color mode to " + lightOrDark);
				task.Definition.Settings.StartWhenAvailable = true;
			}
			task.Definition.Triggers.Single().StartBoundary = timeSetting.Type == TimeType.Fixed ? timeSetting.FixedTime : timeSetting.SunPhase.Value.PhaseTime;
			task.RegisterChanges();
		}
	}
}
