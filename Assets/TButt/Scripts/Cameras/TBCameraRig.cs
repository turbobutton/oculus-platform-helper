using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif

// TBCameraRig
// Holds camera references for mobile and PC OVR cameras.
//
// Written 1/16/15 by Holden Link
// Copyright 2015 Turbo Button, Inc
// www.turbo-button.com

namespace TButt
{
	public class TBCameraRig : MonoBehaviour 
	{
		private GameObject leftEye;
		private GameObject rightEye;
		private GameObject centerEye;
		private GameObject cameraObject;

		public Vector3 cameraScale = new Vector3(1,1,1);
		public bool usePositionTracking = true;
		public float nearClippingPlane = 0.01f;
		public float farClippingPlane = 1500f;

		public GameObject DK2Camera;
		public GameObject GearVRCamera;
		public Transform TBLeft;
		public Transform TBCenter;
		public Transform TBRight;

		void Awake()
		{
			ChooseCamera();

			cameraObject.transform.localScale = cameraScale;

			// Update clipping planes
			leftEye.GetComponent<Camera>().nearClipPlane = nearClippingPlane;
			leftEye.GetComponent<Camera>().farClipPlane = farClippingPlane;
			rightEye.GetComponent<Camera>().nearClipPlane = nearClippingPlane;
			rightEye.GetComponent<Camera>().farClipPlane = farClippingPlane;

			// Place nested transforms
			TBLeft.transform.parent = leftEye.transform;
			TBRight.transform.parent = rightEye.transform;
			TBCenter.transform.parent = centerEye.transform;
		}

		private void ChooseCamera()
		{
		#if UNITY_ANDROID
			GearVRCamera.SetActive(true);
			GearVRCamera.GetComponent<OVRCameraController>().EnablePosition = usePositionTracking;
			cameraObject = GearVRCamera;
			leftEye = cameraObject.transform.FindChild("CameraLeft").gameObject;
			centerEye = cameraObject.transform.FindChild("CameraLeft").gameObject;;
			rightEye = cameraObject.transform.FindChild("CameraRight").gameObject;;
			Destroy(DK2Camera);
			return;
		#endif

		#if UNITY_STANDALONE
			DK2Camera.SetActive (true);
			DK2Camera.GetComponent<OVRManager>().usePositionTracking = usePositionTracking;
			cameraObject = DK2Camera;
			leftEye = cameraObject.transform.FindChild("LeftEyeAnchor").gameObject;
			centerEye = cameraObject.transform.FindChild("CenterEyeAnchor").gameObject;;
			rightEye = cameraObject.transform.FindChild("RightEyeAnchor").gameObject;;
			Destroy (GearVRCamera);
			return;
		#endif
		}

		public GameObject GetLeftCamera()
		{
			if(leftEye == null)
				Awake ();
			return leftEye;
		}

		public GameObject GetCenterCamera()
		{
			if(leftEye == null)
				Awake ();
			return centerEye;
		}

		public GameObject GetRightCamera()
		{
			if(leftEye == null)
				Awake ();
			return rightEye;
		}


	}
}
