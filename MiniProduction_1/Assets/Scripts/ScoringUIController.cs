using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoringUIController : Manager<ScoringUIController> {

	[SerializeField]
	GameObject scoringScreen;
	[SerializeField]
	Text[] stackCompletionFields;

	public void ShowScoringScreen()
	{
		scoringScreen.SetActive(true);
		Contract tempContract = ContractController.Instance.GetCurrentContract();
		for (int i = 0; i < stackCompletionFields.Length; i++)
		{
			if (i < tempContract.GetStacks().Length)
			{
				stackCompletionFields[i].gameObject.SetActive(true);
				//Implement measurement			
			} else {
				stackCompletionFields[i].gameObject.SetActive(false);
			}
		}
	}
	public void CloseScoringScreen()
	{
		scoringScreen.SetActive(false);
	}	

}
