using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		Debug.DrawLine(transform.FindChild("OVRCameraController").position, transform.FindChild("OVRCameraController").position + transform.FindChild("OVRCameraController").forward*5.0f, Color.green);
        if (Physics.Raycast(transform.FindChild("OVRCameraController").position, transform.FindChild("OVRCameraController").forward, out hit, 100.0F)) {
			Debug.DrawLine(transform.FindChild("OVRCameraController").position, hit.point, Color.red);
		}
	}
}
