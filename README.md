# Oculus Platform Helper
## Intro ##
### What is this? ###
This is a package and workflow for Unity developers that allows support for PC and Gear VR in a single Unity project.

### Why do I need something like this? ###
The current Oculus SDKs cannot live together in a single project, but this package will flush and import the correct SDKs whenever you change platforms in Unity. Additionally, it will move any objects you have under the Oculus camera transforms into the correct place on the correct cameras and keep settings in sync between the two cameras.

### What are the requirements? ###
This has been tested on Windows with Unity 4.6, Oculus PC SDK 0.4.4, and Oculus Mobile SDK 0.4.2. We can't promise it will work with other setups.

## How to Install ##
1. Download the mobile and PC Oculus SDKs from the Oculus Developer site, located here: https://developer.oculus.com/. This has been tested with PC SDK 0.4.4 and mobile SDK 0.4.2.
2. Rename the PC SDK unitypackage file to "sdk-dk2.unitypackage" and place it in the root of your project directory (not in the Assets folder).
3. Rename the mobile SDK unitypackage file to "sdk-gearvr.unitypackage" and place it in the root of your project directory (not in the Assets folder).
4. Download the Oculus Platform Helper and copy the "Change Platform.bat" (or .sh for OSX users) file into the root of your project directory.
5. Install the TBOculusPlatformHelper.unitypackage into your project from within Unity.
6. Move any non-Oculus plugins out of your main Assets/Plugins folder and into a subfolder, such as Assets/TButt/Plugins.
7. Switch your Unity project platform to PC/Standalone.
8. Import the Oculus PC SDK unitypackage manually. You should only have to do this once.

## Using TBCameraRig ##
You should use TBCameraRig in your scenes instead of the Oculus camera prefabs. The TBCameraRig has both of the Oculus camera prefabs (PC and mobile) nested underneath them, and chooses the correct one depending on which platform you're compiling for. If you have objects nested underneath the Oculus cameras, put them under TBLeft, TBCenter, or TBRight as appropriate.

## Changing Platforms ##
1. Switch platforms from the Unity Build Settings menu as usual. After reimporting assets, Unity will close and save the current open scene as a backup to /Assets/PlatformChangeBackup (just in case you didn't save before you quit).
2. Run the "Change Platform.bat" batch file (or shell script for OSX users) in the project root. This will automate the process of flushing the old SDK, launching Unity, importing the correct SDK, and verifying your build settings are correct for your target platform (updating the physics timestep, etc).

### Known Issues ###
On some machines, you may need to restart Unity again the normal way (by opening Unity, rather than using the batch file) after switching to a PC build.
