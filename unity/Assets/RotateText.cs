using UnityEngine;
using System.Collections;

public class RotateText : MonoBehaviour {

	public Camera camera;
	public GUIText text;
	// Use this for initialization
	void Start () {
		//camera = transform.parent.transform.FindChild("CameraLeft").camera;
		text.text = "bobby";//GetComponentInParent<PlayerInfo> ().name;
		//text.transform.localPosition = new Vector3 (-0.956114f, 0.9587379f, -0.01224245f);
	}
	void Update()
	{
		transform.LookAt(camera.transform);
	}
}
