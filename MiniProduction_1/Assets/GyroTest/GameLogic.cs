using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : Manager<GameLogic> {

	[SerializeField]
	GameObject draggableObject;
	bool isPlayerAttacking;
	public float playerAttackTimeAmount;
	public float timeBetweenAttacks;
	float currentTime;

	public bool isEnemyHit;
	public bool playerReachedApex;
	protected override void onAwake()
	{
		CalculateEuclidean(10,20);
		isPlayerAttacking = true;
		playerReachedApex = false;
		isEnemyHit = false;
	}
	void Update()
	{	
		
		currentTime += Time.deltaTime;

		if (isPlayerAttacking)
		{
			if (currentTime > playerAttackTimeAmount)
			{
				//Time is up for the player Attack
				NextRound();
				draggableObject.SetActive(false);
			}
		} else {
			if (currentTime > timeBetweenAttacks)
			{
				//Player can now attack
				NextRound();
				draggableObject.SetActive(true);
				isEnemyHit = false;
				/*
				int tempRandomNumber = Random.Range(0,100);
				if (tempRandomNumber > 75)
				{
					HealthController.Instance.PlayerTakeDamage(0.35f);
				} else if (tempRandomNumber > 50)
				{
					HealthController.Instance.PlayerTakeDamage(0.15f);
				}
				 */
				 HealthController.Instance.PlayerTakeDamage();
			}
		}
	}

	void NextRound()
	{
		isPlayerAttacking = !isPlayerAttacking;
		currentTime = 0.0f;
	}

	public void PlayerAttacked()
	{
		if (isPlayerAttacking)
		{
			NextRound();
			draggableObject.SetActive(false);
			playerReachedApex = false;

		} 
	}
	
	int CalculateEuclidean(int a, int b)
	{
		int t = 0;
		do{
			t = b;
			b = a % b;
			a = t;
		} while(b != 0);
		return a;
	}
	
}
