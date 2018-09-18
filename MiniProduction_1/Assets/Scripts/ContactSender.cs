using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactSender : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//ContactReciever something = GameObject.Find("Sender").GetComponent<ContactReciever>();
		//Debug.Log(something.text);
		//transform.SetParent(something.transform);
		//SceneController.Instance.UnloadMainScene();

	}
	
	// Update is called once per frame
	void Update () {
		Vector3 newPosition = transform.position;
		newPosition.x += 0.05f;
		//transform.position = newPosition;

		gameObject.GetComponent<CharacterController>().Move(Vector3.right);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Reciever")
		{
			ContactReciever something = other.GetComponent<ContactReciever>();
			Debug.Log(something.text);
		}
	}
}
