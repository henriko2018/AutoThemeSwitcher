# Auto Theme Switcher
![.NET Core Desktop](https://github.com/henriko2018/AutoThemeSwitcher/workflows/.NET%20Core%20Desktop/badge.svg)

This utility enables automatic switching of Windows 10 colour mode (theme) between light and dark.
You can choose fixed times or sun phases (e.g. sunrise and sunset), which are calculated based on your location.
No program needs to run in the background, since the utility utilizes the regular task scheduler.

To download a release, go to the Releases section to the right. There are two executables:
* The smaller one can be run if you have .NET 5 runtime installed.
* The larger one is self-contained, meaning the runtime is included in the executable.

Credits go to:
* Koste Budinoski for [SunCalcNet](https://github.com/kostebudinoski/SunCalcNet)
* David Hall for [Task Scheduler Managed Wrapper](https://github.com/dahall/TaskScheduler)
