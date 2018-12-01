using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerCtrl : NetworkBehaviour {

	public Transform MainCamTrans {
		get {
			if (cashedMainCamTrnas == null) {
				cashedMainCamTrnas = Camera.main.transform;
			}
			return cashedMainCamTrnas;
		}
	}
	private Transform cashedMainCamTrnas;

	public Transform MainCamOffset {
		get {
			if (cashedMainCamOffset == null) {
				cashedMainCamOffset = Camera.main.transform.parent;
			}
			return cashedMainCamOffset;
		}
	}
	private Transform cashedMainCamOffset;

	private Vector3 spawnPos;

	void Start() {
		if (!isLocalPlayer) {
			Destroy(this);
			return;
		}
		spawnPos = NetworkManager.singleton.GetStartPosition().position;
	}

	void Update () {
		transform.position = MainCamTrans.localPosition + spawnPos;
		transform.rotation = MainCamTrans.localRotation;

		MainCamOffset.position = transform.position;
	}
}
