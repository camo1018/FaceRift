using UnityEngine;
using System.Collections;
using System;

public class Authentication : MonoBehaviour {

	// Use this for initialization
	void Start () {
		string[] arguments = Environment.GetCommandLineArgs();
		
		var argument = arguments[1];
		
		var authenticationToken = argument.Substring(8);
		
		Debug.Log("Auth Token " + authenticationToken);
		
		Toolbox.Instance.authenticationToken = authenticationToken;		
	}
}
