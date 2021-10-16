using Microsoft.Extensions.Logging;
using System;
using System.Windows.Forms;

namespace AutoThemeSwitcher
{
    class Program
	{
		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			using var loggerFactory = LoggerFactory.Create(builder =>
			{
				builder
					.AddFilter("Microsoft", LogLevel.Warning)
					.AddFilter("System", LogLevel.Warning)
					.AddFilter("AutoThemeSwitcher.Program", LogLevel.Information)
					.AddConsole()
					.AddEventLog()
					.AddDebug();
			});
			var logger = loggerFactory.CreateLogger<Program>();
			if (args.Length > 0)
			{
				if (args[0].ToLower() == "--switch")
				{
					var task = new Switcher(loggerFactory).SwitchAsync();
					task.GetAwaiter().GetResult();
					logger.LogInformation("Done");
				}
				else
				{
					logger.LogError($"Unknown argument '{args[0]}'");
					Environment.Exit(1);
				}
			}
			else
			{
				logger.LogInformation("No command parameters given. Starting GUI.");
				Application.SetHighDpiMode(HighDpiMode.SystemAware);
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(new MainForm());
			}
		}
	}
}
