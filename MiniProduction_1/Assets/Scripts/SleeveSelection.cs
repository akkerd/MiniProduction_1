using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class SleeveSelection : Manager<SleeveSelection>, IPointerClickHandler
{
	[SerializeField]
	GameObject sleeveInfoBackground;
	Color startColor;
	[SerializeField]
	GameObject sleeveInfoText; 
	[SerializeField]
	Button sleeveAcceptButton;

	[SerializeField]
	ConveyorSleeve bodyBag;
	[SerializeField]
	MoveSleeveForwardScript moveSleeveForward;
	
	[SerializeField]
	GameObject[] sleeveStats;

	int currentPositionOfUnzippedSleeves = 0;

	void Start()
	{
		moveSleeveForward.Setup();
		startColor = sleeveInfoBackground.GetComponent<Image>().color;
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
		
		if (ConveyorController.Instance.currentCenterOfLevelSleeves >= SleeveController.Instance.GetActiveSleeves().Length 
            || SleeveController.Instance.GetActiveSleeves()[ConveyorController.Instance.currentCenterOfLevelSleeves].isEmpty
        ) {
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

            //Might be unnessesary until movement script have been collider dependent
            TouchInputController.Instance.ResetCubePosition();

			float[] stats;
			bool isMale;
			SleeveController.Instance.GetActiveSleeves()[ConveyorController.Instance.currentCenterOfLevelSleeves].GetVisibleStats(out stats, out isMale);

			// For each stat, take each of the values in order and change the display
			// Text stats
			sleeveStats[0].GetComponent<Text>().text = stats[0].ToString();
			sleeveStats[1].GetComponent<Text>().text = stats[1].ToString();
			
			// Bar stats
			sleeveStats[2].GetComponent<Image>().fillAmount = stats[2];
			sleeveStats[3].GetComponent<Image>().fillAmount = stats[3];
			sleeveStats[4].GetComponent<Image>().fillAmount = stats[4];
			for( int i = 0; i < sleeveStats.Length; i++ )
			{
				//Debug.Log(stats[i]);
			}

            sleeveInfoBackground.SetActive(true);
            sleeveInfoText.gameObject.SetActive(true);

        } else {
			sleeveAcceptButton.interactable = false;
		}
	}
	public void CloseSleeveInfo()
	{
		//Debug.Log("AcceptSleeve");
		//CancelInvoke("ChangeColor");
		//sleeveInfoBackground.GetComponent<Image>().color = startColor;
		sleeveInfoBackground.SetActive(false);
	}
	public void AcceptSleeve()
	{
		//Debug.Log("AcceptSleeve");
		Invoke("CloseSleeveInfo",1.0f);
		//InvokeRepeating("ChangeColor",0.05f,0.05f);
		sleeveInfoText.gameObject.SetActive(false);
		sleeveAcceptButton.interactable = false;
		MoveSleeveForward();
	}
	void ChangeColor()
	{
		Color tempColor = sleeveInfoBackground.GetComponent<Image>().color;
		tempColor.a -= 0.05f;
		sleeveInfoBackground.GetComponent<Image>().color = tempColor;
	}
	void MoveSleeveForward()
	{
		ConveyorController.Instance.HideCenter();
		bodyBag.gameObject.SetActive(true);
		//Add the real center to the bodybag
		bodyBag.AddSleeve( SleeveController.Instance.GetActiveSleeves()[ConveyorController.Instance.currentCenterOfLevelSleeves],-1);
		ContractController.Instance.AcceptSleeveForContract(SleeveController.Instance.GetActiveSleeves()[ConveyorController.Instance.currentCenterOfLevelSleeves],currentPositionOfUnzippedSleeves);
		currentPositionOfUnzippedSleeves++;
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
		return sleeveInfoBackground.activeSelf;
	}
}
