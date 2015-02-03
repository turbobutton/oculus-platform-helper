#!/bin/bash
echo "=========================="
echo "Oculus Platform Switcher"
echo "by Turbo Button"
echo "www.turbo-button.com"
echo "=========================="
rm -rf "$(pwd)/Assets/Plugins"
rm -rf "$(pwd)/Assets/OVR"
rm -rf "$(pwd)/Assets/Moonlight"
read -p "Dumped files. Press any key to continue."
exec /Applications/Unity/Unity.app/Contents/MacOS/Unity -projectPath $(pwd) -executeMethod TBBuildSettings.ImportNewPlatformFiles
