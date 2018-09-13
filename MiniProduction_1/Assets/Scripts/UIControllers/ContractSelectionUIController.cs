using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ContractSelectionUIController : Manager<ContractSelectionUIController> {

	[SerializeField]
	GameObject contractScreen;
	[SerializeField]
	Sprite unactiveInfoSprite;
	[SerializeField]
	Sprite activeInfoSprite;
	[SerializeField]
	GameObject[] contracts;
	[SerializeField]
	
	GameObject[] exclamationMarks;

	[SerializeField]
	RectTransform activeContractMarker;
	[Header("ContractInfoPopup")]
	[SerializeField]
	GameObject contractInfoScreen;
	[SerializeField]
	GameObject StackTableScreen;
	
	[SerializeField]
	Text totalNumberOfSleeves;
	[SerializeField]
	Text[] sleeves;

	[SerializeField]
	Button acceptButton;
	[SerializeField]
	Button contractInfoButton;

	int currentViewedContract = 0;

	void Start()
	{
		//Setup Listeners on contract Images
		for (int i = 0; i < contracts.Length; i++)
		{
			contracts[i].GetComponent<OnClickTester>().numberToRespond = i;
		}
	}
	public void OpenContractScreen()
	{
		if(contractScreen.activeSelf)
		{
			contractScreen.SetActive(false);
			contractInfoButton.GetComponent<Image>().sprite = unactiveInfoSprite;
		}
		else
		{
			contractScreen.SetActive(true);
			contractInfoButton.GetComponent<Image>().sprite = activeInfoSprite;
			UpdateContracts();
		}
	}

	public void InteractionWithContract(int positionOfContract)
	{
		currentViewedContract = positionOfContract;
		contractInfoScreen.SetActive(true);
		Contract contractToShow = ContractController.Instance.GetActiveContracts()[positionOfContract];
		ShowContract(contractToShow);
	}

	
	public void UpdateContracts()
	{
			
		Contract[] tempContracts = ContractController.Instance.GetActiveContracts();
		activeContractMarker.gameObject.SetActive(false);

		for (int i = 0; i < contracts.Length; i++)
		{
			if (tempContracts[i] != null)
			{
				contracts[i].gameObject.SetActive(true);
				if (tempContracts[i].haveBeenShown)
				{
					//exclamationMarks[i].SetActive(false);
				} else {
					//exclamationMarks[i].SetActive(true);
				}
				if (i == ContractController.Instance.GetNumberOfCurrentActiveContract())
				{
					activeContractMarker.position = contracts[i].transform.position;
					activeContractMarker.gameObject.SetActive(true);
				}				
			} else {
				contracts[i].SetActive(false);
				//exclamationMarks[i].SetActive(false);
			}
		}
	}

	public void ShowContract(Contract contractToShow)
	{
		Stack[] tempStacks = contractToShow.GetStacks();
		totalNumberOfSleeves.text = tempStacks.Length.ToString();
		for (int i = 0; i < sleeves.Length; i++)
		{
			if (i < contractToShow.GetNumberOfStacks())
			{
				sleeves[i].gameObject.SetActive(true);
				sleeves[i].text = tempStacks[i].stackName;
			} else {
				sleeves[i].gameObject.SetActive(false);
			}
		}
		if (ContractController.Instance.GetCurrentContract() == null)
		{
			acceptButton.interactable = true;
		} else {
			acceptButton.interactable = false;
		}
		contractToShow.haveBeenShown = true;
	}

	public void AcceptContract()
	{
		ContractController.Instance.AcceptContract(currentViewedContract);
		CloseContractInfoScreen();
		CloseContractScreen();
		StackTableScreen.SetActive(true);
	}
	public void CloseContractScreen()
	{
		contractScreen.SetActive(false);
		contractInfoScreen.SetActive(false);
	}
	public void CloseContractInfoScreen()
	{
		contractInfoScreen.SetActive(false);
		UpdateContracts();
	}
}
