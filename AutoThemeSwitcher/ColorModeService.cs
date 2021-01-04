using AutoThemeSwitcher.Model;
using Microsoft.Win32;

namespace AutoThemeSwitcher
{
	public class ColorModeService
    {

		public (ColorMode System, ColorMode Apps) GetCurrent()
		{
			using var regkey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Themes\Personalize", false);
			var currentSystem = GetColorMode(regkey, "SystemUsesLightTheme");
			var currentApps = GetColorMode(regkey, "AppsUseLightTheme");
			return (currentSystem, currentApps);
		}

		public void Set(ColorMode desiredMode)
		{
			using var regkey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Themes\Personalize", true);
			SetColorMode(regkey, "SystemUsesLightTheme", desiredMode);
			SetColorMode(regkey, "AppsUseLightTheme", desiredMode);
		}

		private ColorMode GetColorMode(RegistryKey regkey, string valueName)
		{
			var value = (int?)regkey.GetValue(valueName);
			// Default seems to be light.
			return value switch { 0 => ColorMode.Dark, _ => ColorMode.Light };
		}

		private void SetColorMode(RegistryKey regkey, string valueName, ColorMode desiredMode)
		{
			regkey.SetValue(valueName, desiredMode == ColorMode.Dark ? 0 : 1, RegistryValueKind.DWord);
		}
	}
}
