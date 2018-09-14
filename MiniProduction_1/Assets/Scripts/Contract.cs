using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contract {

	public string description;
	public Stack[] stacks;
	Sleeve[] sleeveRewards;
	public bool isCompleted = false;
	public bool haveBeenShown = false;

	public int id;
	
	public Contract(int numberOfStacks)
	{
		stacks = new Stack[numberOfStacks];
		for (int i = 0; i < numberOfStacks; i++)
		{
			stacks[i] = new Stack(i.ToString());
		}
	}
	public Contract(int newId, string newDescription, Stack[] stacksForContract, Sleeve[] rewardSleeves)
	{
		id = newId;
		description = newDescription;
		stacks = stacksForContract;
		sleeveRewards = rewardSleeves;
	}

	public Sleeve RewardSleeve(int sleeveNumberToReward)
	{
		return sleeveRewards[sleeveNumberToReward];
	}

	public int GetNumberOfStacks()
	{
		return stacks.Length;
	}
	public Stack[] GetStacks()
	{
		return stacks;
	}
	
}
