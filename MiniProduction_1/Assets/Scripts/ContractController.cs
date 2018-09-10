using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContractController : Manager<ContractController> {

	Contract[] contracts;
	int currectAcceptedContract = -1;

	void Start()
	{
		contracts = new Contract[3];
		AddContract(new Contract(3));
		AddContract(new Contract(4));

		AddContract(new Contract(2));

	}

	public void AddContract(Contract newContract)
	{
		for (int i = 0; i < contracts.Length; i++)
		{
			if (contracts[i] == null)
			{
				contracts[i] = newContract;
				return;
			}
			if (contracts[i].isCompleted)
			{
				contracts[i] = newContract;
			}
		}
	}

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
	public Contract[] GetActiveContracts()
	{
		return contracts;
	}
	public int GetNumberOfActiveContracts()
	{
		return contracts.Length;
	}

}
