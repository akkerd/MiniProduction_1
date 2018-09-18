using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(ContainerContracts))]
public class SaveLoadController : Manager<SaveLoadController> {

	ContainerContracts container;
	int maxAvalibleContracts = 3;
	int lastAddedContract;
	int lastAddedSleeve;
	int totalNumberOfSleeves = 11;
	protected override void onAwake()
	{
		base.onAwake();
		//DontDestroyOnLoad(this);
		container = GetComponent<ContainerContracts>();
		container.Setup();
		//Debug.Log("Sup");
	}
	
	
	void Start()
	{
		ResetAllContracts();
		Setup();
	}

	public void Setup()
	{
		//CompleteFirstContract
		PlayerPrefs.SetInt("Contract0",1);
		//Setup Contracts
		int acceptedContracks = 0;
		for (int i = 0; i < container.contracts.Length; i++)
		{
			if (!ContractCompletionCheck(i))
			{
				ContractController.Instance.AddContract(container.contracts[i]);
				if ( acceptedContracks ==ContractController.Instance.GetActiveContracts().Length)
				{
					lastAddedContract = i;
					break;
				}
			}
		}
		//Setup Avaliable Sleeves
		
		int currentSleeve= 0;
		for (int i = 0; i < container.contracts.Length; i++)
		{
			if (ContractCompletionCheck(i))
			{
				for (int j = 0; j < container.numberOfSleevesInContract[i]; j++)
				{
					if (PlayerPrefs.GetInt("Sleeve" + currentSleeve.ToString(),0) == 0)
					{
						SleeveController.Instance.AddSleeve(container.contracts[i].RewardSleeve(j));
						currentSleeve++;
					}
				}
			} else {
				currentSleeve += container.numberOfSleevesInContract[i];
			}
		}

		SleeveController.Instance.UpdateSleevesInConveyor();
	}
	bool ContractCompletionCheck(int contractNumberToCheck)
	{
		int temp = PlayerPrefs.GetInt("Contract" + contractNumberToCheck.ToString(),0);
		if (temp == 0)
		{
			//Debug.Log("Contract " + contractNumberToCheck + ": Incomplete");
			return false;
		} else {
			//Debug.Log("Contract " + contractNumberToCheck + ": Complete");
			return true;
		}
	}

	public void CompleteContract(int contractID)
	{
		PlayerPrefs.SetInt("Contract" + contractID.ToString(),1);
	}
	public void UseSleeve(int sleeveId)
	{
		PlayerPrefs.SetInt("Sleeve" + sleeveId.ToString(),1);
	}
	public void ResetAllContracts()
	{
		for (int i = 0; i < container.contracts.Length; i++)
		{
			PlayerPrefs.SetInt("Contract" + i.ToString(),0);
		}
		int maxNumberOfSleeves = 0;
		for (int i = 0; i < container.numberOfSleevesInContract.Length; i++)
		{
			maxNumberOfSleeves += container.numberOfSleevesInContract[i];
		}
		for (int i = 0; i < maxNumberOfSleeves; i++)
		{
			PlayerPrefs.SetInt("Sleeve" + i.ToString(),0);
		}
		PlayerPrefs.SetInt("Contract0",1);

	}

	public void LoadGame()
	{
		

		//ContractController.Instance.AddContract();
	}
	
}
