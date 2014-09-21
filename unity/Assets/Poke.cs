using UnityEngine;
using System.Collections;

public class Poke : MonoBehaviour {

	public float pokeDistance = 10.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (OVRGamepadController.GPC_GetButton (0) || Input.GetKey(KeyCode.E)) {
			RaycastHit hit;
			Ray rayFired = new Ray(transform.FindChild("OVRCameraController").FindChild("CameraLeft").position + 
			                       														(transform.FindChild("OVRCameraController").FindChild("CameraLeft").forward*3.0f),
			                       transform.FindChild("OVRCameraController").FindChild("CameraLeft").forward);

			if (Physics.Raycast(rayFired, out hit, pokeDistance)) {
				if (hit.collider.tag == "user") {
					string id = hit.collider.GetComponentInParent<OVRPlayerController>().GetComponent<PlayerInfo>().id;
					StartCoroutine(Poker(id));

				}
			}
		}
	}

	IEnumerator Poker(string id)
	{
		string url = "localhost:7000/actions/userInteraction/poke?accessToken="+Toolbox.Instance.authenticationToken+"&friendID="+id;
		
		Debug.Log (url);
		WWW www = new WWW(url);
		yield return www;
		
		if (www.error == null)
		{
			Debug.Log("Poke Success");
		} else {
			Debug.LogError("Poke didn't work");
		} 
	}
}
