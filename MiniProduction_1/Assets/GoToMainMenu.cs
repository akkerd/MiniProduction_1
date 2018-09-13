using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMainMenu : MonoBehaviour {

	[SerializeField]
	GameObject confirmationWindow;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void MainMenu()
	{
		SceneManager.LoadScene(0);
	}

	public void CloseConfirmationWindow()
	{
		confirmationWindow.SetActive(false);
	}

	public void OpenConfirmationWindow()
	{
		confirmationWindow.SetActive(true);
	}
}
