using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayerBack : MonoBehaviour {

	public HealthController.HitZone zone;
	bool isMoving = false;
	
	public Vector3 startPosition;
	Quaternion startRotation;
	float moveSpeed = 10;
	// Use this for initialization
	void Start () {
		startPosition = transform.localPosition;
		startRotation = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		if (isMoving)
		{
			if (transform.localPosition != startPosition)
				transform.localPosition = Vector3.MoveTowards(transform.localPosition,startPosition,Time.deltaTime*moveSpeed);
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

	public void OnCollisionEnter(Collision other)
	{
		if (gameObject.name == "Player") {return;}
			HealthController.Instance.EnemyTakeDamage(zone);
	}
}
