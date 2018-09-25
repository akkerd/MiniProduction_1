using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	Vector3 prevLocation;
	float furthestToTheLeft;
	float startXForFurthers;
	public bool isMoving = false;

	void Start()
	{
		startXForFurthers = transform.position.x -1;
		furthestToTheLeft = startXForFurthers;
	}
	void Update()
	{
		if (transform.position.x < furthestToTheLeft)
		{
			furthestToTheLeft = transform.position.x;
			isMoving =true;
		}
		if (isMoving)
		{
			if (transform.position.x > furthestToTheLeft)
			{
				GameLogic.Instance.playerReachedApex = true;
				isMoving = false;
			furthestToTheLeft = startXForFurthers;


			}
		}
		
	}
}
