using UnityEngine;
using System.Collections;
using UnityEditor;
using System.IO;

// TBBuildSettings
// Sets config settings and imports correct SDK versions whenever we change VR target platforms.
// 
// Consistent with Oculus recommended settings as of:
// PC SDK 0.4.4
// Mobile SDK 0.4.2
//
// Written 1/16/15 by Holden Link
// Copyright 2015 Turbo Button, Inc
// www.turbo-button.com
// With help from bzgeb's PlatformMonitor.cs https://gist.github.com/bzgeb/6216118

	[InitializeOnLoad]
	public class TBBuildSettings : MonoBehaviour {

		static string loadedLevel;
		static bool working = false;

		static GameObject OVRCam;
		static GameObject leftEye;
		static GameObject rightEye;
		static GameObject centerEye;

		static TBBuildSettings()
		{
			// EditorApplication.update += Update;
			EditorUserBuildSettings.activeBuildTargetChanged += OnChangedPlatform;
		}

		static void OnChangedPlatform() 
		{
			EditorApplication.SaveScene("Assets/PlatformChangeBackup.unity");
			EditorApplication.Exit(0);
		}

		static void ImportNewPlatformFiles()
		{
			switch(EditorUserBuildSettings.activeBuildTarget)
			{
				// DK2
				case BuildTarget.StandaloneOSXIntel:
				case BuildTarget.StandaloneOSXIntel64:
				case BuildTarget.StandaloneOSXUniversal:
				case BuildTarget.StandaloneWindows:
				case BuildTarget.StandaloneWindows64:
				case BuildTarget.StandaloneLinux:
				case BuildTarget.StandaloneLinux64:
				case BuildTarget.StandaloneLinuxUniversal:
					AssetDatabase.ImportPackage("sdk-dk2.unitypackage", false);
					ConfigDK2();
					break;
				// Gear VR
				case BuildTarget.Android:
					AssetDatabase.ImportPackage("sdk-gearvr.unitypackage", false);
					ConfigGearVR();
					break;
			}
			AssetDatabase.Refresh();
		}

		static void ConfigDK2()
		{
			// Lock at 75 FPS
			Time.fixedDeltaTime = 1/75f;
			Time.maximumDeltaTime = 1/75f;

			// Update Build Settings
			PlayerSettings.useDirect3D11 = true;
			PlayerSettings.defaultScreenWidth = 1920;
			PlayerSettings.defaultScreenHeight = 1080;
			PlayerSettings.runInBackground = true;
			PlayerSettings.SetAspectRatio(AspectRatio.Aspect4by3, false);
			PlayerSettings.SetAspectRatio(AspectRatio.Aspect5by4, false);
			PlayerSettings.SetAspectRatio(AspectRatio.Aspect16by9, true);
			PlayerSettings.SetAspectRatio(AspectRatio.Aspect16by10, true);
			PlayerSettings.SetAspectRatio(AspectRatio.AspectOthers, false);
		}

		static void ConfigGearVR()
		{
			// Lock at 60 FPS
			Time.fixedDeltaTime = 1/60f;
			Time.maximumDeltaTime = 1/60f;

			// Update Build Settings
			EditorUserBuildSettings.androidBuildSubtarget = AndroidBuildSubtarget.ETC2;

			// Resolution and Presentation section
			PlayerSettings.defaultInterfaceOrientation = UIOrientation.LandscapeLeft;
			PlayerSettings.statusBarHidden = true; 						
			PlayerSettings.use32BitDisplayBuffer = true;
			PlayerSettings.Android.use24BitDepthBuffer = true;
			PlayerSettings.Android.showActivityIndicatorOnLoading = AndroidShowActivityIndicatorOnLoading.DontShow;

			// Other Settings
			PlayerSettings.mobileRenderingPath = RenderingPath.Forward;
			PlayerSettings.mobileMTRendering = true;
			PlayerSettings.MTRendering = true;

			PlayerSettings.Android.minSdkVersion = AndroidSdkVersions.AndroidApiLevel19;

			PlayerSettings.targetGlesGraphics = TargetGlesGraphics.OpenGLES_2_0;
			PlayerSettings.Android.targetDevice = AndroidTargetDevice.ARMv7;
			PlayerSettings.Android.preferredInstallLocation = AndroidPreferredInstallLocation.PreferExternal;

			PlayerSettings.apiCompatibilityLevel = ApiCompatibilityLevel.NET_2_0_Subset;
			// PlayerSettings.strippingLevel = StrippingLevel.Disabled;
			PlayerSettings.stripUnusedMeshComponents = true; 	// "Optimize Mesh Data"
		}
	}
