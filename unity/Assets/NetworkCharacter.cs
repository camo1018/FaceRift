using UnityEngine;
using System.Collections;

public class NetworkCharacter : Photon.MonoBehaviour {
	
	Vector3 realPosition;
	Quaternion realRotation;
	
	string realId;
	string realName;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if( photonView.isMine ) {
			// Do nothing -- the character motor/input/etc... is moving us
		}
		else {
			transform.position = Vector3.Lerp(transform.position, realPosition, 0.1f);
			transform.Find("ForwardDirection").rotation = Quaternion.Lerp(transform.Find("ForwardDirection").rotation, realRotation, 0.1f);
			transform.Find("OVRCameraController").rotation = Quaternion.Lerp(transform.Find("OVRCameraController").rotation, realRotation, 0.1f);
			gameObject.GetComponent<PlayerInfo>().id = realId;
			gameObject.GetComponent<PlayerInfo>().name = realName;
		}
	}
	
	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {
		if(stream.isWriting) {
			// This is OUR player. We need to send our actual position to the network.
			stream.SendNext(transform.position);
			stream.SendNext(transform.Find("ForwardDirection").rotation);
			stream.SendNext(gameObject.GetComponent<PlayerInfo>().id);
			stream.SendNext(gameObject.GetComponent<PlayerInfo>().name);
		}
		else {
			// This is someone else's player. We need to receive their position (as of a few
			// millisecond ago, and update our version of that player.
			realPosition = (Vector3)stream.ReceiveNext();
			realRotation = (Quaternion)stream.ReceiveNext();
			
		}
		
	}
}
