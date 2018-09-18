using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayerBack : MonoBehaviour {

	bool isMoving = false;
	
	Vector3 startPosition;
	Quaternion startRotation;
	float moveSpeed = 10;
	// Use this for initialization
	void Start () {
		startPosition = transform.position;
		startRotation = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		if (isMoving)
		{
			if (transform.position != startPosition)
				transform.position = Vector3.MoveTowards(transform.position,startPosition,Time.deltaTime*moveSpeed);
			if (transform.rotation != startRotation)
				transform.rotation = Quaternion.Lerp(transform.rotation,startRotation,Time.deltaTime);
		}
	}

	public void MoveBack()
	{
		isMoving = true;

	}

	public void Stop()
	{
		isMoving = false;
	}
}
