using UnityEngine;
using System.Collections;

public class PlayerNames : MonoBehaviour {

	public Camera camera;

	// Use this for initialization
	void Start () {
		string name = GetComponentInParent<PlayerInfo> ().name;
		GetComponent<TextMesh>().text =name;
	}
	
	// Update is called once per frame
	void Update () {
		//Camera cam = FindObjectOfType<Camera> ();
		string name = GetComponentInParent<PlayerInfo> ().name;
		//transform.LookAt (camera.transform);
	}
}
