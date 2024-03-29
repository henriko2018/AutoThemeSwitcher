﻿using AutoThemeSwitcher.Model;
using Microsoft.Extensions.Logging;
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
		private readonly ILogger<Switcher> _logger;

		public Switcher(ILoggerFactory loggerFactory)
		{
			_settingsRepository = new SettingsRepository();
			_scheduledTasksWrapper = new ScheduledTasksWrapper();
			_colorModeService = new ColorModeService();
			_logger = loggerFactory.CreateLogger<Switcher>();
		}

		public async Task SwitchAsync()
		{
			var currentMode = _colorModeService.GetCurrent();
			_logger.LogInformation($"Current theme/color mode for system is {currentMode.System} and for apps is {currentMode.Apps}");

			// Calculate desired mode:
			var settings = _settingsRepository.LoadSettings();
			var location = settings.Location;
			if (location == null && (settings.LightAt.Type == TimeType.Sun || settings.DarkAt.Type == TimeType.Sun))
				location = await GetGeoLocation();
			var (lightAt, darkAt) = GetTimes(location, settings, false);
			var desiredMode = DateTime.Now < lightAt || darkAt < DateTime.Now ?  ColorMode.Dark : ColorMode.Light;

			if (currentMode.System != desiredMode || currentMode.Apps != desiredMode)
			{
				_logger.LogInformation($"Switching to {desiredMode}...");
				_colorModeService.Set(desiredMode);
			}
			else
			{
				_logger.LogInformation($"Desired mode is also {desiredMode} so no need to switch.");
			}

			// Possibly update schedule:
			if (settings.LightAt.Type == TimeType.Sun || settings.DarkAt.Type == TimeType.Sun)
			{
				(lightAt, darkAt) = GetTimes(location, settings, true);
				_logger.LogInformation($"Updating triggers to {lightAt.ToLocalTime():t} and {darkAt.ToLocalTime():t}...");
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

		private (DateTime lightAt, DateTime darkAt) GetTimes(Location location, Settings settings, bool adjustForNextDay)
		{
			return (
				settings.LightAt.Type == TimeType.Fixed
					? GetTimeOfDay(settings.LightAt.FixedTime)
					: GetPhaseTime(location, settings.LightAt.SunPhase, adjustForNextDay),
				settings.DarkAt.Type == TimeType.Fixed
					? GetTimeOfDay(settings.DarkAt.FixedTime)
					: GetPhaseTime(location, settings.DarkAt.SunPhase, adjustForNextDay));
		}

        private static DateTime GetTimeOfDay(DateTime dateTime) => DateTime.Today.Add(dateTime - dateTime.Date);

        private static DateTime GetPhaseTime(Location location, string phaseName, bool adjustForNextDay)
		{
			var time = SunCalc.GetSunPhases(DateTime.UtcNow, location.Lat, location.Long).Single(sp => sp.Name.Value == phaseName).PhaseTime;
			return !adjustForNextDay || time > DateTime.UtcNow 
				? time 
				: SunCalc.GetSunPhases(DateTime.UtcNow.AddDays(1), location.Lat, location.Long).Single(sp => sp.Name.Value == phaseName).PhaseTime;
		}
	}
}
