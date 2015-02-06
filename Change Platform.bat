ECHO OFF
ECHO ==========================
ECHO Oculus Platform Switcher
ECHO by Turbo Button
ECHO www.turbo-button.com
ECHO ==========================
cd %~dp0\Assets\Plugins\
del OculusPlugin.dll /q
del OculusPlugin.dll.meta /q
del OculusPlugin.dll.signature /q
del OculusPlugin.dll.signature.meta /q
del donotdelete.txt /q
del donotdelete.txt.meta /q
del OculusPlugin.bundle.meta /q

cd %~dp0\Assets\Plugins\x86_64\
del OculusPlugin.dll /q
del OculusPlugin.dll.meta /q
del OculusPlugin.dll.signature /q
del OculusPlugin.dll.signature.meta /q
rd del %~dp0\Assets\Plugins\OculusPlugin.bundle /s /q

rd del %~dp0\Assets\OVR /s /q
rd del %~dp0\Assets\Moonlight /s /q

ECHO Dumped files. Press any key to continue.

cd C:\Program Files (x86)\Unity\Editor\
START Unity.exe -projectPath %~dp0 -executeMethod TBBuildSettings.ImportNewPlatformFiles
