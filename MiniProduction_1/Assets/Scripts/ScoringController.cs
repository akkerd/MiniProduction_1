using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoringController : Manager<ScoringController> {

	public void CalculateReport(Sleeve[] sleevesInStackCombinedOrder)
	{
		Contract completedContracts = ContractController.Instance.GetCurrentContract();
		Stack[] stacks = completedContracts.GetStacks();
		int[] matchPercentage = new int[stacks.Length];
		for (int i = 0; i < stacks.Length; i++)
		{
			matchPercentage[i] = CompareStackAndSleeve(stacks[i],sleevesInStackCombinedOrder[i]);
		}
		DisplayReport(matchPercentage);
	}
	int CompareStackAndSleeve(Stack stack, Sleeve sleeve)
	{
		//
		float matchPercentage = 0;
		int[] sleeveStats;
		int[] stackStats = stack.GetStats();
		sleeve.GetStats(out sleeveStats);

		for (int i = 0; i < 5; i++)
		{
			if (i == 0)
			{
				matchPercentage += CompareStatWithRange(sleeveStats[i],stackStats[0],stackStats[1]);
			}
			matchPercentage += CompareStatWithRange(sleeveStats[i],stackStats[i*2],stackStats[(i*2) +1]);
		}

		//Sex check
		if (stack.GetIsFemale() != sleeve.GetIsFemale())
		{
			matchPercentage -= 50;
		}
		return Mathf.CeilToInt(matchPercentage);
	}

	float CompareStatWithRange(int stat,int lowRange, int highRange)
	{
		if (stat >= lowRange && stat <= highRange)
		{
			return 20.0f;
		}

		float distanceFromLow = lowRange - stat;
		float distanceFromHigh = stat - highRange;

		float temp = 20 - Mathf.Min(distanceFromHigh,distanceFromLow);

		return Mathf.Max(temp,0);
	}

	void DisplayReport(int[] percentages)
	{
		ScoringUIController.Instance.ShowScoringScreen(percentages);

	}
}
