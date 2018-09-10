using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInputController : MonoBehaviour {

	//The transform the distance of the cube to the center will move
	public Transform lineController;

	//For audio
	public float currentSpeed = 0;
	Touch prevTouch;
	Vector3 startPosition;
	//Controls the acceleration of the drag of the conveyor belt
	float acceleration = 0.07f;
	//Controls the maximum amount of drag on the conveyor belt
	float maxDrag = 5;
	//Controls the current drag of the conveyor belt
	float currentDrag = 0;
	//Controls the maximum distance from the starting position the control cube can move
	float maxDistanceFromCenter = 10;
	//Controls the added force to the cube when you drag across the screen
	float forceAddedToCube = 80;
	
	//Declares whether or not the code should calculate movement of the cube
	bool shouldMoveLine;
	
	// Use this for initialization
	void Start () {
		startPosition = transform.position;
		shouldMoveLine = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount != 0)
		{
			Touch currentTouch = Input.GetTouch(0);
			FirstTouch(currentTouch);
		} else {
			ReturnCubeTowardsCenter();
		}
		if (shouldMoveLine)
		{
			MoveLineBasedOnCube();
		}

        AkSoundEngine.SetRTPCValue("conveyor_acc", currentSpeed);
	}

	//Slowly accelerates the cube towards its center position
	void ReturnCubeTowardsCenter()
	{
		if (Vector3.Distance(transform.position,startPosition) == 0)
		{
			transform.position = startPosition;
			shouldMoveLine = false;
			return;
		} else {
			shouldMoveLine = true;
		}
		currentDrag += acceleration * Time.deltaTime;
		if (currentDrag > maxDrag)
		{
			currentDrag = maxDrag;
		}
		Vector3 nextPosition = Vector3.Lerp(transform.position, startPosition,currentDrag*Time.deltaTime);
		transform.position = nextPosition;
	}

	//Checks which phase the touches[0] is in, and if it has moved, apply that movement to the control cube
	void FirstTouch(Touch currentTouch)
	{
		if (currentTouch.phase == TouchPhase.Canceled)
		{
			return;
		}
		if (currentTouch.phase == TouchPhase.Began)
		{
			prevTouch = currentTouch;
			transform.position = startPosition;
			return;
		}
		if (currentTouch.phase == TouchPhase.Moved)
		{
			float angle = Vector2.Angle(prevTouch.position,currentTouch.position);
			float force = Vector2.Distance(prevTouch.position,currentTouch.position);
			//Define the limits to the acceptable angle, and send either 180 or 0 direction to the movelinebasedontouch.
			Vector3 direction = Camera.main.ScreenToViewportPoint(prevTouch.position) - Camera.main.ScreenToViewportPoint(currentTouch.position);
			//Debug.Log(direction);

			Vector3 newPositionOfCube = Vector3.Lerp(transform.position, transform.position +(direction * forceAddedToCube),force * Time.deltaTime);
			Debug.Log("New position of cube: " +newPositionOfCube);
			if (newPositionOfCube.x < -maxDistanceFromCenter +startPosition.x)
			{
				newPositionOfCube.x = -maxDistanceFromCenter +startPosition.x;
			} else if (newPositionOfCube.x > maxDistanceFromCenter +startPosition.x)
			{
				newPositionOfCube.x = maxDistanceFromCenter +startPosition.x;
			}

			newPositionOfCube.y = startPosition.y;
			newPositionOfCube.z = startPosition.z;
			transform.position = newPositionOfCube;
			prevTouch = currentTouch;
		}
	}

	//Move the linecontroller based on the distance of the cube to its starting position. And applies this movement to the conveyorController so it can do its teleport calculations
	void MoveLineBasedOnCube()
	{
		//based on direction and distance, move cube away from start position. to a max
		int directionSign;
		if ((transform.position - startPosition).x < 0)
		{
			directionSign = 1;
		} else {
			directionSign = -1;
		}
		float distance = Vector3.Distance(transform.position,startPosition);
		currentSpeed = distance;
		Vector3 newPositionOfLine = lineController.position;
		newPositionOfLine.x += distance * directionSign * Time.deltaTime;
		Vector3 lerpPosition = Vector3.Lerp(lineController.position,newPositionOfLine,Time.deltaTime);
		ConveyorController.Instance.MoveConveyorBelt(lineController.position.x - lerpPosition.x);
		lineController.position = newPositionOfLine;
	}
}
