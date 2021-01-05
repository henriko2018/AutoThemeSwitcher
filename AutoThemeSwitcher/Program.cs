using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoThemeSwitcher
{
	class Program
	{
		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		static async Task Main(string[] args)
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
					await new Switcher(loggerFactory).SwitchAsync();
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
