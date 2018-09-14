using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContractController : Manager<ContractController> {

	Contract[] contracts;
	int currectAcceptedContract = -1;

	public Sleeve[] choosenSleevesForContract;
	int acceptedSleeves = 0;
	public bool isContractDone = false;
	
	protected override void onAwake()
	{
		base.onAwake();
		contracts = new Contract[3];
	}
	
	public void Reset()
	{
		contracts = new Contract[3];
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
		isContractDone = false;
		currectAcceptedContract = acceptedContractPositionInArray;
		choosenSleevesForContract = new Sleeve[contracts[acceptedContractPositionInArray].GetStacks().Length];
        StackDeliveryController.Instance.ShowStacks();
    }

	public void FinishContract()
	{
		SaveLoadController.Instance.CompleteContract(contracts[currectAcceptedContract].id);
		currectAcceptedContract = -1;
		for (int i = 0; i < choosenSleevesForContract.Length; i++)
		{
			SaveLoadController.Instance.UseSleeve(choosenSleevesForContract[i].id);
		}
		SaveLoadController.Instance.Setup();
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
	public int GetNumberOfCurrentActiveContract()
	{
		return currectAcceptedContract;
	}
	public Contract[] GetActiveContracts()
	{
		return contracts;
	}
	public int GetNumberOfActiveContracts()
	{
		return contracts.Length;
	}
	public void AcceptSleeveForContract(Sleeve acceptedSleeve, int arrayPosition)
	{
		choosenSleevesForContract[arrayPosition] = acceptedSleeve;
		
	}
	public Sleeve GetSleeveInPosition(int arrayPosition)
	{
		acceptedSleeves++;
		if (acceptedSleeves == choosenSleevesForContract.Length)
		{
			isContractDone = true;
		}
		return choosenSleevesForContract[arrayPosition];	
	}

}
