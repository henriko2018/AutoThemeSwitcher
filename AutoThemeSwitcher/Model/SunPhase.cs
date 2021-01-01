using SunCalcNet.Model;

namespace AutoThemeSwitcher.Model
{
	public class SunPhaseListItem
    {
        public SunPhase Value { get; }
        public string Display => $"{Value.Name} ({Value.PhaseTime.ToLocalTime():t})";

		public SunPhaseListItem(SunPhase value)
		{
            Value = value;
		}
    }
}
