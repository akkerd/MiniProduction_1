using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScene : MonoBehaviour {

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
}
