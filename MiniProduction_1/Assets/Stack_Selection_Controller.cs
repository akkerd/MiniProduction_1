using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stack_Selection_Controller : MonoBehaviour {


	[SerializeField]
	Sprite Non_Selected_Image;
	[SerializeField]
	Sprite Selected_Image;
	[SerializeField]
	GameObject[] Stack_Buttons;

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
}
