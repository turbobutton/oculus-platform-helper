ECHO OFF
ECHO ==========================
ECHO Oculus Platform Switcher
ECHO by Turbo Button
ECHO www.turbo-button.com
ECHO ==========================
rd del %~dp0\Assets\Plugins /s /q
rd del %~dp0\Assets\OVR /s /q
rd del %~dp0\Assets\Moonlight /s /q
ECHO Dumped files. Press any key to continue.
cd C:\Program Files (x86)\Unity\Editor\
START Unity.exe -projectPath %~dp0 -executeMethod TBBuildSettings.ImportNewPlatformFiles
