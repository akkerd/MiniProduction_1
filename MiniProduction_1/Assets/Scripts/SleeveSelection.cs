using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class SleeveSelection : MonoBehaviour, IPointerClickHandler
{
	[SerializeField]
	GameObject sleeveInfoBackground;
	[SerializeField]

	Text sleeveInfoText; 

	[SerializeField]
	ConveyorSleeve bodyBag;
	[SerializeField]
	MoveSleeveForwardScript moveSleeveForward;
	void Start()
	{
		moveSleeveForward.Setup();
	}
    public void OnPointerClick(PointerEventData eventData)
    {
        ShowSleeveInfo();
    }

	void ShowSleeveInfo()
	{
		//Might be unnessesary until movement script have been collider dependent
		TouchInputController.Instance.ResetCubePosition();
		sleeveInfoBackground.SetActive(true);
		sleeveInfoText.gameObject.SetActive(true);
	}
	public void CloseSleeveInfo()
	{
		sleeveInfoBackground.SetActive(false);
	}
	public void AcceptSleeve()
	{
		Invoke("CloseSleeveInfo",1.0f);
		sleeveInfoText.gameObject.SetActive(false);
		MoveSleeveForward();
	}
	void MoveSleeveForward()
	{
		ConveyorController.Instance.HideCenter();
		bodyBag.gameObject.SetActive(true);
		//Add the real center to the bodybag
		bodyBag.AddSleeve( SleeveController.Instance.GetActiveSleeves()[ConveyorController.Instance.currentCenterOfLevelSleeves],-1);

		moveSleeveForward.MoveSleeveForward(TestWhenDoneMovingForward);
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
}
