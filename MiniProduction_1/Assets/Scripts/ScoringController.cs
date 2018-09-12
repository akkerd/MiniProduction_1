using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoringController : Manager<ScoringController> {

	public void CalculateReport(int[] stackCombinations)
	{
		ScoringUIController.Instance.ShowScoringScreen();
	}
}
