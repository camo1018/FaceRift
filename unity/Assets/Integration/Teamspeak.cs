using UnityEngine;
using System.Collections;

public class Teamspeak : MonoBehaviour {

	void Start() {
		Application.OpenURL("ts3server://128.61.114.195");
	}
	
	// Update is called once per frame
	void OnApplicationQuit() {
		
	}
}
