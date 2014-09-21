using UnityEngine;
using System.Collections;
using System;

public class Authentication : MonoBehaviour {

	// Use this for initialization
	IEnumerator Start () {	
		string[] arguments = Environment.GetCommandLineArgs();
		
		var argument = arguments[1];
		
		var authenticationToken = argument.Substring(8);
		
		Debug.Log("Auth Token " + authenticationToken);
		
		Toolbox.Instance.authenticationToken = authenticationToken;	

		string url = "localhost:7000/actions/userInteraction/getMe?accessToken="+authenticationToken;

		WWW www = new WWW(url);
		yield return www;

		if (www.error == null)
		{
			string[] vals = (www.text.Substring(1, www.text.Length - 2)).Split(',');
			Toolbox.Instance.id = vals[0];
			Toolbox.Instance.name = vals[1];
		} else {
			Debug.LogError("Could not find user from auth token");
		}  
	}	  

}
