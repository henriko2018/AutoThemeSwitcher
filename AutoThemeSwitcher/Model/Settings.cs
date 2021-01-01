using SunCalcNet.Model;
using System;

namespace AutoThemeSwitcher.Model
{
	public class Settings
    {
        public TimeSetting LightAt { get; set; }
        public TimeSetting DarkAt { get; set; }
    }

    public class TimeSetting
	{
        public TimeType Type { get; set; } // Fixed or sun
        /// <summary>
        /// Only the time portion is used.
        /// </summary>
        public DateTime FixedTime { get; set; }
        public SunPhase? SunPhase { get; set; }
    }

    public enum TimeType { Fixed, Sun }
}
