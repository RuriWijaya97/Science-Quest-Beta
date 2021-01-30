using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseManager : MonoBehaviour
{
	public GameObject panelPause;

	public void pauseControl() {
		if (Time.timeScale == 1) {
			panelPause.SetActive (true);
			Time.timeScale = 0;
		} else {
			Time.timeScale = 1;
			panelPause.SetActive (false);
			
		}
	}
	public void MenuSelect() {
		SceneManager.LoadScene ("NewMainMenuScene");
		Time.timeScale = 1;
		panelPause.SetActive (false);
	}	
}
