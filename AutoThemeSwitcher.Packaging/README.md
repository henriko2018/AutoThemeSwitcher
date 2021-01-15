# Testing Windows 10 S

Procedure:

- Copy `Windows10STestPolicies\SiPolicy_DevModeEx_Enforced.p7b` to 
`C:\Windows\System32\CodeIntegrity\SiPolicy` on the test (virtual) machine.
- Reboot.
- On the development machine, open a Visual Studio prompt:
```
cd C:\Source\AutoThemeSwitcher\AutoThemeSwitcher.Packaging\
MakeAppx.exe pack /l /h sha256 /f obj\x64\Debug\package.map.txt /o /p AppPackages\AutoThemeSwitcher.x64_Debug.appx
cd Windows-AppConsult-Tools-DesktopBridgeRePack-master\RepackageForWindows10S
MakeAPPXForWin10S.cmd ..\..\AppPackages\AutoThemeSwitcher.x64_Debug.appx
```
- Copy `AppPackages\AutoThemeSwitcher.x64_DebugStoreSigned.appx` and 
  `Windows10STestPolicies\AppxTestRootAgency\AppxTestRootAgency.cer` to the test machine.
- Double-click on `AppxTestRootAgency.cer` and place it in Local Machine -> Trusted people.
- Double-click on `AutoThemeSwitcher.x64_DebugStoreSigned.appx`.

Links:

* https://docs.microsoft.com/sv-se/archive/blogs/appconsult/porting-and-testing-your-classic-desktop-applications-on-windows-10-s-with-the-desktop-bridge
* https://docs.microsoft.com/en-us/windows/msix/desktop/desktop-to-uwp-test-windows-s
* https://docs.microsoft.com/en-us/archive/blogs/appconsult/unpack-modify-repack-sign-appx
