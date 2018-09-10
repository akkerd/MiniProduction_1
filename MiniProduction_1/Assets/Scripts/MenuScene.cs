using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScene : MonoBehaviour {

    public SettingsMenu settingsMenu;
    public GameObject credits;
    public GameObject mainButtons;
    public GameObject backButton;

	public void OnPlayClick()
    {
        Debug.Log("Pushed button");
        SceneManager.LoadScene(1);
        
    }

    public void OnQuitClick()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
    public void OnSettingsClick()
    {
        settingsMenu.ChangeSettingsMenu();
        mainButtons.SetActive(false);
        backButton.SetActive(true);
    }
    public void OnCreditsClick()
    {
        credits.SetActive(true);
    }
    public void OnBackClick()
    {
        settingsMenu.ChangeSettingsMenu();
        backButton.SetActive(false);
        mainButtons.SetActive(true);
    }
}
