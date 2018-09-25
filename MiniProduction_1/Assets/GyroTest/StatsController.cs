using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class StatsController : Manager<StatsController> {
	[Header("Player")]

	[Range(0,100)]
	public int strenght;
	[Range(0,100)]
	public int agility;
	[Range(0,100)]
	public int defense;

	[Header("Enemy")]
	[Range(0,100)]
	public int strenghtEnemy;
	[Range(0,100)]
	public int agilityEnemy;
	[Range(0,100)]
	public int defenseEnemy;

}
