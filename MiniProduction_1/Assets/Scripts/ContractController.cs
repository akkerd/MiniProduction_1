using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContractController : Manager<ContractController> {

	Contract[] contracts;
	int currectAcceptedContract = -1;

	public void AcceptContract(int acceptedContractPositionInArray)
	{
		currectAcceptedContract = acceptedContractPositionInArray;
	}

	public void FinishContract()
	{
		SleeveController.Instance.AddSleeves(GetCurrentContract().GetNumberOfStacks());
		SleeveController.Instance.UpdateSleevesInConveyor();
		currectAcceptedContract = -1;
		//ActivateScoringThang
	}
	public Contract GetCurrentContract()
	{
		if (currectAcceptedContract == -1)
		{
			return null;
		}
		return contracts[currectAcceptedContract];
	}

}
