using AutoThemeSwitcher.Model;
using SunCalcNet;
using System;
using System.Linq;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;

namespace AutoThemeSwitcher
{
	public class Switcher
    {
		private readonly SettingsRepository _settingsRepository;
		private readonly ScheduledTasksWrapper _scheduledTasksWrapper;
		private readonly ColorModeService _colorModeService;

		public Switcher()
		{
			_settingsRepository = new SettingsRepository();
			_scheduledTasksWrapper = new ScheduledTasksWrapper();
			_colorModeService = new ColorModeService();
		}

		public async Task SwitchAsync()
		{
			var currentMode = _colorModeService.GetCurrent();
			Console.Out.WriteLine($"Current theme/color mode for system is {currentMode.System} and for apps is {currentMode.Apps}");

			// Calculate desired mode:
			var settings = _settingsRepository.LoadSettings();
			var location = settings.LightAt.Type == TimeType.Sun || settings.DarkAt.Type == TimeType.Sun
				? await GetGeoLocation()
				: null;
			ColorMode desiredMode;
			var now = DateTime.Now;
			var (lightAt, darkAt) = GetTimes(now, location, settings);
			if (now < lightAt || darkAt < now)
				desiredMode = ColorMode.Dark;
			else
				desiredMode = ColorMode.Light;

			if (currentMode.System != desiredMode || currentMode.Apps != desiredMode)
			{
				Console.Out.WriteLine($"Switching to {desiredMode}...");
				_colorModeService.Set(desiredMode);
			}
			else
			{
				Console.Out.WriteLine($"Desired mode is also {desiredMode} so no need to switch.");
			}

			// Possibly update schedule:
			if (settings.LightAt.Type == TimeType.Sun || settings.DarkAt.Type == TimeType.Sun)
			{
				var tomorrow = DateTime.Today.AddDays(1);
				(lightAt, darkAt) = GetTimes(tomorrow, location, settings);
				Console.Out.WriteLine($"Updating triggers to {lightAt.ToLocalTime()} and {darkAt.ToLocalTime()}...");
				_scheduledTasksWrapper.SaveScheduledTask(lightAt, darkAt);
			}
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
				throw new ApplicationException("Geolocation access not allowed.");
			}
		}

		private (DateTime lightAt, DateTime darkAt) GetTimes(DateTime dateTime, Location location, Settings settings)
		{
			return (
				settings.LightAt.Type == TimeType.Fixed
					? settings.LightAt.FixedTime
					: GetPhaseTime(dateTime, location, settings.LightAt.SunPhase),
				settings.DarkAt.Type == TimeType.Fixed
					? settings.DarkAt.FixedTime
					: GetPhaseTime(dateTime, location, settings.DarkAt.SunPhase));
		}

		private DateTime GetPhaseTime(DateTime date, Location location, string phaseName)
			=> SunCalc.GetSunPhases(date, location.Lat, location.Long).Single(sp => sp.Name.Value == phaseName).PhaseTime;
	}
}
