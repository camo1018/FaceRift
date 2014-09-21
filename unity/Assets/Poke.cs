using UnityEngine;
using System.Collections;

public class Poke : MonoBehaviour {

	public float pokeDistance = 10.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (OVRGamepadController.GPC_GetButton (0) || Input.GetKey(KeyCode.F)) {
			RaycastHit hit;
			Ray rayFired = new Ray(transform.FindChild("OVRCameraController").FindChild("CameraLeft").position + 
			                       														(transform.FindChild("OVRCameraController").FindChild("CameraLeft").forward*3.0f),
			                       transform.FindChild("OVRCameraController").FindChild("CameraLeft").forward);

			if (Physics.Raycast(rayFired, out hit, pokeDistance)) {
				if (hit.collider.tag == "user") {
					//hit.collider.GetComponentsInParent<OVRPlayerController>(); <---- example on how to get higher in heirarchy
				}
			}
		}
	}

}
