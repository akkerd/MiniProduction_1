using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour {

	Vector3 startPosition;
	Vector3 currentEndPosition;
	float speed = 1;

	// Use this for initialization
	void Awake () {
		startPosition = transform.localPosition;
		currentEndPosition = startPosition;
		currentEndPosition.y += 1;
	}
	
	// Update is called once per frame
	void Update () {
		MoveBody();
	}
	void MoveBody()
	{
		//Debug.Log(Vector3.Distance(transform.position,currentEndPosition));
		if (Vector3.Distance(transform.localPosition,currentEndPosition) == 0|| Mathf.Infinity == Vector3.Distance(transform.localPosition,currentEndPosition))
		{
			currentEndPosition.y *= -1;
		}
		Vector3 newPosition = Vector3.MoveTowards(transform.localPosition,currentEndPosition,Time.deltaTime* speed);
		transform.localPosition = newPosition;
	}
	public void OnCollisionEnter(Collision other)
	{
		GameLogic.Instance.isEnemyHit = true;
	}
}
