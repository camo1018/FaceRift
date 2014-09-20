using UnityEngine;
using System.Collections;

public class NetworkCharacter : Photon.MonoBehaviour {

	Vector3 realPosition = Vector3.zero;
	Quaternion realRotation = Quaternion.identity;

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
			transform.rotation = Quaternion.Lerp(transform.rotation, realRotation, 0.1f);

			//MeshRenderer Mesh1= null;
			//if (this.transform.parent.GetComponent<MeshRenderer>() != null) 
			//	Mesh1 = this.transform.parent.GetComponent<MeshRenderer>();

			if (this.GetComponent<OVRCameraController>() != null)
				this.GetComponent<OVRCameraController>().gameObject.SetActive(false);

			//if (this.GetComponent<OVRPlayerController>() != null)
			//	this.GetComponent<OVRPlayerController>().gameObject.SetActive(false);
			
			 
			//if (Mesh1 != null) 
			//	Mesh1.gameObject.SetActive(true);
		}
	}

	void LateUpdate() {
		if( photonView.isMine ) {
			// Do nothing -- the character motor/input/etc... is moving us
		}
		else {
			//MeshRenderer Mesh1= null;
			//if (this.transform.parent.GetComponent<MeshRenderer>() != null) 
			//	Mesh1 = this.transform.parent.GetComponent<MeshRenderer>();
			
			if (this.GetComponent<OVRCameraController>() != null)
				this.GetComponent<OVRCameraController>().gameObject.SetActive(false);
			
			//if (this.GetComponent<OVRPlayerController>() != null)
			//	this.GetComponent<OVRPlayerController>().gameObject.SetActive(false);
			
			
			//if (Mesh1 != null) 
			//	Mesh1.gameObject.SetActive(true);
		}
	}

	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {
		if(stream.isWriting) {
			// This is OUR player. We need to send our actual position to the network.

			stream.SendNext(transform.position);
			stream.SendNext(transform.rotation);
		}
		else {
			// This is someone else's player. We need to receive their position (as of a few
			// millisecond ago, and update our version of that player.

			realPosition = (Vector3)stream.ReceiveNext();
			realRotation = (Quaternion)stream.ReceiveNext();
		}

	}
}
