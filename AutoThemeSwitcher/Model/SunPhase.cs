using System;

namespace AutoThemeSwitcher.Model
{
	public class SunPhaseListItem
    {
        public TimeSpan Value { get; }
        public string Name { get; }
        public string Display => $"{Name} ({Value})";

		public SunPhaseListItem(string name, TimeSpan value)
		{
            Name = name;
            Value = value;
		}
    }
}
