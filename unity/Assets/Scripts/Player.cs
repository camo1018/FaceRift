using UnityEngine;
using System.Collections;
/**
 * Most credit goes to http://www.paladinstudios.com/2013/07/10/how-to-create-an-online-multiplayer-game-with-unity/ 
 **/
public class Player : MonoBehaviour
{
    public float speed = 10f;

    private float lastSynchronizationTime = 0f;
    private float syncDelay = 0f;
    private float syncTime = 0f;
    private Vector3 syncStartPosition = Vector3.zero;
    private Vector3 syncEndPosition = Vector3.zero;

    void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info)
    {
        Vector3 syncPosition = Vector3.zero;
        Vector3 syncVelocity = Vector3.zero;
        if (stream.isWriting)
        {
            syncPosition = rigidbody.position;
            stream.Serialize(ref syncPosition);

            syncPosition = rigidbody.velocity;
            stream.Serialize(ref syncVelocity);
        }
        else
        {
            stream.Serialize(ref syncPosition);
            stream.Serialize(ref syncVelocity);

            syncTime = 0f;
            syncDelay = Time.time - lastSynchronizationTime;
            lastSynchronizationTime = Time.time;

            syncEndPosition = syncPosition + syncVelocity * syncDelay;
            syncStartPosition = rigidbody.position;
        }
    }

    void Awake()
    {
        lastSynchronizationTime = Time.time;
    }

    void Update()
    {
        if (networkView.isMine)
        {
            InputMovement();
        }
        else
        {
            SyncedMovement();
        }
    }


    private void InputMovement()
    {
		if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            rigidbody.MovePosition(rigidbody.position + Vector3.forward * speed * Time.deltaTime);

		if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            rigidbody.MovePosition(rigidbody.position - Vector3.forward * speed * Time.deltaTime);

		if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            rigidbody.MovePosition(rigidbody.position + Vector3.right * speed * Time.deltaTime);

		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            rigidbody.MovePosition(rigidbody.position - Vector3.right * speed * Time.deltaTime);
    }

    private void SyncedMovement()
    {
        syncTime += Time.deltaTime;

        rigidbody.position = Vector3.Lerp(syncStartPosition, syncEndPosition, syncTime / syncDelay);
    }
}
