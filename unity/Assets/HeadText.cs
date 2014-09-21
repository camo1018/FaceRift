using UnityEngine;
using System.Collections;

public class HeadText : MonoBehaviour {
	string name;
	// Use this for initialization
	void Start () {
		name = transform.parent.parent.GetComponent<PlayerInfo>().name;
	}
	
	// Update is called once per frame
	void Update () {
		name = transform.parent.parent.GetComponent<PlayerInfo>().name;
		GetComponent<TextMesh> ().text = name;
	}
}
