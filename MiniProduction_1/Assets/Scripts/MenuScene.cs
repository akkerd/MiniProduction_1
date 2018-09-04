using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScene : MonoBehaviour {

    public SettingsMenu settingsMenu;
    public GameObject credits;

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
    }
    public void OnCreditsClick()
    {
        credits.SetActive(true);
    }
}
