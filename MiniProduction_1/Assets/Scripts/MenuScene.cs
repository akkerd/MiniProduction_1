using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScene : MonoBehaviour {

    public SettingsMenu settingsMenu;
    public GameObject credits;
    public GameObject mainButtons;
    public GameObject backButton;
    public GameObject confirmExit;

    // Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape) )
        {
            OnQuitClick();
        }
	}

    public void OnPlayClick()
    {
        Debug.Log("Pushed button");
        AkSoundEngine.PostEvent("play_menu_select",gameObject);
        SceneManager.LoadScene(1);
        
    }

    public void OnQuitClick()
    {
        Debug.Log("Show confirmation screen");
        AkSoundEngine.PostEvent("play_menu_select", gameObject);
        confirmExit.SetActive(true);
    }
    public void OnSettingsClick()
    {
        AkSoundEngine.PostEvent("play_menu_select", gameObject);
        settingsMenu.ChangeSettingsMenu();
        mainButtons.SetActive(false);
        backButton.SetActive(true);
    }
    public void OnCreditsClick()
    {
        AkSoundEngine.PostEvent("play_menu_select", gameObject);
        credits.SetActive(true);
    }
    public void OnBackClick()
    {
        AkSoundEngine.PostEvent("play_menu_select", gameObject);
        settingsMenu.ChangeSettingsMenu();
        backButton.SetActive(false);
        mainButtons.SetActive(true);
    }

    public void OnYesClick()
    {
        Debug.Log("Quit Game");
        AkSoundEngine.PostEvent("play_menu_select",gameObject);
        Application.Quit();
    }
    public void OnNoClick()
    {
        Debug.Log("Back to Menu");
        confirmExit.SetActive(false);
        AkSoundEngine.PostEvent("play_menu_select", gameObject);
    }
}
