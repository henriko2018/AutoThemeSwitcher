using SunCalcNet.Model;
using System;

namespace AutoThemeSwitcher.Model
{
    public class Settings
    {
        public TimeSetting LightAt { get; set; }
        public TimeSetting DarkAt { get; set; }

        public static Settings Defaults
            => new Settings
            {
                LightAt = new TimeSetting { Type = TimeType.Fixed, FixedTime = DateTime.Today + new TimeSpan(08, 00, 00) },
                DarkAt = new TimeSetting { Type = TimeType.Fixed, FixedTime = DateTime.Today + new TimeSpan(18, 00, 00) }
            };
    }

    public class TimeSetting
	{
        public TimeType Type { get; set; } // Fixed or sun
        /// <summary>
        /// Only the time portion is used.
        /// </summary>
        public DateTime FixedTime { get; set; }
        public string SunPhase { get; set; }
    }

    public enum TimeType { Fixed, Sun }
}
