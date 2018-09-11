using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MoveSleeveForwardScript : MonoBehaviour {

	Action callbackAction;
	

	float movementSpeed = 1.0f;
	bool isMoving = false;
	Vector3 originalStartPosition;
	Vector3 originalEndPosition;

	Vector3 currentDestination;
	public void Setup()
	{
		originalStartPosition = transform.position;
		originalEndPosition = transform.position;
		originalEndPosition.z -= 5.0f;
		originalEndPosition.y -= 1.5f;
	}
	public void MoveSleeveForward(Action callWhenDone)
	{
		callbackAction = callWhenDone;
		isMoving = true;
		currentDestination = originalEndPosition;
	}
	public void MoveSleeveBackwards(Action callWhenDone)
	{
		callbackAction = callWhenDone;
		isMoving = true;
		currentDestination = originalStartPosition;
	}
	void Update()
	{
		if (isMoving)
		{
			Moving();
		}
	}

	void Moving()
	{
		float currentDistance = Vector3.Distance(transform.position,currentDestination);
		if (currentDistance == 0 || currentDistance == Mathf.Infinity)
		{
			isMoving = false;
			callbackAction();
			return;
		}
		Vector3 newPosition = Vector3.MoveTowards(transform.position,currentDestination,movementSpeed * Time.deltaTime);
		transform.position = newPosition;
	}


}
