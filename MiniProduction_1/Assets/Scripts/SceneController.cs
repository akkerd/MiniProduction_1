using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneController : Manager<SceneController> {

	protected override void onAwake()
	{
		DontDestroyOnLoad(this);
	}
	public void LoadMainScene()
	{
		SceneManager.LoadScene(1,LoadSceneMode.Single);
		SceneManager.LoadScene(2,LoadSceneMode.Additive);
		SceneManager.UnloadSceneAsync("Menu");
	}
	public void UnloadMainScene()
	{
		SceneManager.UnloadSceneAsync("MainScene");
	}
}
