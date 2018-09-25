using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : Manager<HealthController> {
	public enum HitZone {Head,Stomach,Groin};
	[SerializeField]
	public Image playerHealth;
	[SerializeField]
	public Image enemyHealth;

	float enemyFloat;
	float playerFloat;

	protected override void onAwake()
	{
		playerFloat = 100.0f;
		enemyFloat = 100.0f;
	}

	public void EnemyTakeDamage(HitZone zone)
	{
		if (GameLogic.Instance.isEnemyHit /*|| GameLogic.Instance.playerReachedApex*/) {return;}
		GameLogic.Instance.isEnemyHit = true;
		switch (zone)
		{
			case HitZone.Head:
			enemyFloat -= CalculatePlayerDamage(2.0f);
			break;
			case HitZone.Stomach:
			enemyFloat -=CalculatePlayerDamage(1.5f);
			break;
			case HitZone.Groin:
			enemyFloat -= CalculatePlayerDamage(1.0f);
			break;
		}
		UpdateUI();
		
	}
	float CalculateEnemyDamage()
	{
		float damage = (StatsController.Instance.strenghtEnemy + Random.Range(-1,1));
		//float reduction = ((StatsController.Instance.defense)*0.06f)/(1+0.06f*(StatsController.Instance.defense));
		float reduction = StatsController.Instance.defense / 100.0f;
		if (damage < 1)
		{
			damage = 1;
		}
		return (damage -(damage * reduction));
		
	}
	float CalculatePlayerDamage(float multiplier)
	{
		float damage = (StatsController.Instance.strenght + Random.Range(-1,1));
		//float reduction = ((StatsController.Instance.defenseEnemy)*0.06f)/(1+0.06f*(StatsController.Instance.defenseEnemy));
		float reduction = StatsController.Instance.defenseEnemy / 100.0f;
		if (damage < 1)
		{
			damage = 1;
		}
		return (damage -(damage * reduction)) * multiplier;
	}

	void CheckForHealthLowerThanZero()
	{
		bool change = false;
		if (playerFloat < 0)
		{
			change = true;
			Debug.Log("Player Lost");
		} else if (enemyFloat < 0)
		{
			change = true;
			Debug.Log("Enemy Lose");
		}

		if (change)
		{
			playerFloat = 100.0f;
			enemyFloat = 100.0f;
		}
	}

	public void PlayerTakeDamage(float amount)
	{
		//playerFloat -= amount;
		playerFloat -= CalculateEnemyDamage();
		//=((armor)*0.06)/(1+0.06*(armor))
		//Debug.Log(((80)*0.06)/(1+0.06*(80)));
		UpdateUI();
	}
	public void PlayerTakeDamage()
	{
		playerFloat -= CalculateEnemyDamage();
		
		UpdateUI();
	}
	
	void UpdateUI()
	{
		CheckForHealthLowerThanZero();
		playerHealth.fillAmount = playerFloat / 100.0f;
		enemyHealth.fillAmount = enemyFloat / 100.0f;

		Debug.Log("Player Health: " + playerFloat + " EnemyHealth: " + enemyFloat);
	}
}
