using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stack_Selection_Controller : Manager<Stack_Selection_Controller>
{
	[SerializeField]
	Sprite Non_Selected_Image;
	[SerializeField]
	Sprite Selected_Image;
	[SerializeField]
	public GameObject[] Stack_Objects;
	[SerializeField]
	public GameObject[] Stack_Buttons;
	[SerializeField]
	GameObject StackInfo;
	//[SerializeField]
	//GameObject stackTitle;
	[SerializeField]
	GameObject stackText;
	private int previousIndex;

	// Use this for initialization
	void Start () {
		previousIndex = 3;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SwitchStackButtonColor(int index)
	{
		if ( index != previousIndex )
		{
			Stack_Buttons[previousIndex].GetComponent<Image>().sprite = Non_Selected_Image;

			previousIndex = index;
			Stack_Buttons[index].GetComponent<Image>().sprite = Selected_Image;
		}
	}

	public void CloseStackInfo()
	{
		StackInfo.SetActive(false);
	}

	public void OpenStackInfo(int index)
	{
		Contract currentContract = ContractController.Instance.GetCurrentContract();
		Stack clickedStack = currentContract.stacks[index];
		//stackTitle.GetComponent<Text>().text = clickedStack.stackName;
		stackText.GetComponent<Text>().text = clickedStack.description;
		StackInfo.SetActive(true);
	}
}
