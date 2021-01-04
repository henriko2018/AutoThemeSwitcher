using AutoThemeSwitcher.Model;
using Newtonsoft.Json;
using System;
using System.IO;

namespace AutoThemeSwitcher
{
	public class SettingsRepository
    {
		private string _folderPath;
		private string _filePath;

		public SettingsRepository()
		{
			_folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "AutoThemeSwitcher");
			_filePath = Path.Combine(_folderPath, "Settings.json");
		}

		public void SaveSettings(Settings settings)
		{
			Directory.CreateDirectory(_folderPath);
			File.WriteAllText(_filePath, JsonConvert.SerializeObject(settings, Formatting.Indented));
		}

		public Settings LoadSettings()
		{
			if (File.Exists(_filePath))
				return JsonConvert.DeserializeObject<Settings>(File.ReadAllText(_filePath));
			else
				return Settings.Defaults;
		}
	}
}
