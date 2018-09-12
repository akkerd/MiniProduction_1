using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class SleeveSelection : Manager<SleeveSelection>, IPointerClickHandler
{
	[SerializeField]
	GameObject sleeveInfoUI;
	//Color startColor;
	//[SerializeField]
	//Text sleeveInfoText; 
	[SerializeField]
	Button sleeveAcceptButton;

	[SerializeField]
	ConveyorSleeve bodyBag;
	[SerializeField]
	MoveSleeveForwardScript moveSleeveForward;
	void Start()
	{
		moveSleeveForward.Setup();
		//startColor = sleeveInfoBackground.GetComponent<Image>().color;
	}
    public void OnPointerClick(PointerEventData eventData)
    {
		if (ContractController.Instance.GetCurrentContract() == null)
		{
			return;	
		}
		if (!ConveyorController.Instance.GetCenterConveyorSleeve().gameObject.activeSelf || UnsleeveManager.Instance.count == ContractController.Instance.GetCurrentContract().GetNumberOfStacks() || UnsleeveManager.Instance.isCurrentlyUnsleeving)
		{
			return;
		}
		
		if (SleeveController.Instance.GetActiveSleeves()[ConveyorController.Instance.currentCenterOfLevelSleeves].isEmpty)
		{
			ShowSleeveInfo(false);	
		} else {
        	ShowSleeveInfo(true);
		}
    }

	void ShowSleeveInfo(bool isAcceptPosible)
	{
		
		if (isAcceptPosible)
		{
			sleeveAcceptButton.interactable = true;
		} else {
			sleeveAcceptButton.interactable = false;
		}
		
		//Might be unnessesary until movement script have been collider dependent
		TouchInputController.Instance.ResetCubePosition();
		sleeveInfoUI.SetActive(true);
		//sleeveInfoText.gameObject.SetActive(true);
	}
	public void CloseSleeveInfo()
	{
		//CancelInvoke("ChangeColor");
		//sleeveInfoBackground.GetComponent<Image>().color = startColor;
		sleeveInfoUI.SetActive(false);
	}
	public void AcceptSleeve()
	{
		Invoke("CloseSleeveInfo",1.0f);
		//InvokeRepeating("ChangeColor",0.05f,0.05f);
		//sleeveInfoText.gameObject.SetActive(false);
		sleeveAcceptButton.interactable = false;
		MoveSleeveForward();
	}
	void ChangeColor()
	{
		Color tempColor = sleeveInfoUI.GetComponent<Image>().color;
		tempColor.a -= 0.05f;
		sleeveInfoUI.GetComponent<Image>().color = tempColor;
	}
	void MoveSleeveForward()
	{
		ConveyorController.Instance.HideCenter();
		bodyBag.gameObject.SetActive(true);
		//Add the real center to the bodybag
		bodyBag.AddSleeve( SleeveController.Instance.GetActiveSleeves()[ConveyorController.Instance.currentCenterOfLevelSleeves],-1);

		moveSleeveForward.MoveSleeveForward(UnsleeveManager.Instance.CreateBodybag);
	}
	void TestWhenDoneMovingForward()
	{
		Debug.Log("I did a thing");
	}
	void ResetCenterOfConveyor()
	{
		ConveyorController.Instance.ShowCenter();
		bodyBag.gameObject.SetActive(false);
	}
	public void CancelUnSleeving()
	{
		moveSleeveForward.MoveSleeveBackwards(ResetCenterOfConveyor);
	}
	public bool IsSleeveInfoVisible()
	{
		return sleeveInfoUI.activeSelf;
	}
}
