using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {

	public GameObject standbyCamera;

	// Use this for initialization
	void Start () {
		Connect ();
	}

	void Connect() {
		PhotonNetwork.ConnectUsingSettings( "Frift v001" );
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
		float x = 0.0f;//Random.Range (-10.0f, 10.0f);
		float y = 2.0f;//Random.Range (-10.0f, 10.0f);
		float z = 0.0f;//Random.Range (-10.0f, 10.0f);
		GameObject myPlayerGO = (GameObject)PhotonNetwork.Instantiate("OVRPlayerController", new Vector3(x, y, z), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f), 0);
		standbyCamera.SetActive(false);
		myPlayerGO.transform.FindChild("OVRCameraController").gameObject.SetActive(true);
	}
}
