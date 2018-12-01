using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

public class VRManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine(SwitchToVRMode());
	}

	IEnumerator SwitchToVRMode() {
		VRSettings.LoadDeviceByName("cardboard");
		yield return null;
		VRSettings.enabled = true;
	}
}
