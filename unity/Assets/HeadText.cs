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
		GetComponent<TextMesh> ().text = name;
	}
}
