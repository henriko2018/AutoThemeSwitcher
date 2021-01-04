using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoThemeSwitcher
{
	static class Program
	{
		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		static async Task Main(string[] args)
		{
			if (args.Length > 0)
			{
				if (args[0].ToLower() == "--switch")
				{
					await new Switcher().SwitchAsync();
					Console.Out.WriteLine("Done");
				}
				else
				{
					Console.Error.WriteLine($"Unknown argument '{args[0]}'");
					Environment.Exit(1);
				}
			}
			else
			{
				Console.Out.WriteLine("Info: No command parameters given. Starting GUI.");
				Application.SetHighDpiMode(HighDpiMode.SystemAware);
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(new MainForm());
			}
		}
	}
}
