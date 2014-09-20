using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {

	
	public GameObject playerPrefab;

	// Use this for initialization
	void Start () {
		Connect ();
	}
	
	void Connect() {
		PhotonNetwork.ConnectUsingSettings( "Frift" );
	}
	
	void OnGUI() {
		GUILayout.Label( PhotonNetwork.connectionStateDetailed.ToString() );
	}
	
	void OnJoinedLobby() {
		Debug.Log ("OnJoinedLobby");
		PhotonNetwork.JoinRandomRoom();
	}
	
	void OnPhotonRandomJoinFailed() {
		Debug.Log ("OnPhotonRandomJoinFailed");
		PhotonNetwork.CreateRoom( null );
	}
	
	void OnJoinedRoom() {
		Debug.Log ("OnJoinedRoom");
		
		SpawnMyPlayer();
	}
	
	void SpawnMyPlayer() {
		
		GameObject player = (GameObject)PhotonNetwork.Instantiate(playerPrefab.name, Vector3.up * 5, Quaternion.identity, 0);
		Debug.Log ("spawned");
		//((MonoBehaviour)myPlayerGO.GetComponent("FPSInputController")).enabled = true;
		//((MonoBehaviour)myPlayerGO.GetComponent("MouseLook")).enabled = true;
		//((MonoBehaviour)myPlayerGO.GetComponent("CharacterMotor")).enabled = true;
		//myPlayerGO.transform.FindChild("OVRCameraController").gameObject.SetActive(true);
	}
}
