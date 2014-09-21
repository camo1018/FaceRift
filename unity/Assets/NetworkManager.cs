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
		player.transform.Find("OVRCameraController/CameraLeft").gameObject.GetComponent<Camera>().enabled = true;
		player.transform.Find("OVRCameraController/CameraRight").gameObject.GetComponent<Camera>().enabled = true;
		player.GetComponent<OVRPlayerController>().enabled = true;
		player.GetComponent<OVRMainMenu>().enabled = true;
		player.GetComponent<PlayerInfo>().name = Toolbox.Instance.name;
		player.GetComponent<PlayerInfo>().id = Toolbox.Instance.id;
		
		Debug.Log ("ID: " + player.GetComponent<PlayerInfo> ().id);
		Debug.Log ("Name: " + player.GetComponent<PlayerInfo> ().name);
	}
}
