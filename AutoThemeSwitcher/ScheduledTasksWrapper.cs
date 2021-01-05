using Microsoft.Win32.TaskScheduler;
using System;

namespace AutoThemeSwitcher
{
	public class ScheduledTasksWrapper
    {
		public void SaveScheduledTask(DateTime lightAt, DateTime darkAt)
		{
			var taskName = "AutoThemeSwitcher";
			var task = TaskService.Instance.FindTask(taskName);
			if (task == null)
			{
				task = TaskService.Instance.AddTask(
					path: taskName,
					trigger: new DailyTrigger(),
					action: new ExecAction(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName, "--switch"),
					description: "Switch theme/color mode");
				task.Definition.Triggers.AddNew(TaskTriggerType.Daily);
				task.Definition.Settings.StartWhenAvailable = true;
			}
			task.Definition.Triggers[0].StartBoundary = lightAt;
			task.Definition.Triggers[1].StartBoundary = darkAt;
			task.RegisterChanges();
		}
	}
}
