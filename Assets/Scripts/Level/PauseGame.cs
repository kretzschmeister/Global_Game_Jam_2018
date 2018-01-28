using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour {
	public bool paused;
	public bool missionHasEnded;
	public GameObject canvas, pauseMenu;
	public string menuToShow, buttonClicked;
	private bool m_isInUse = false;

	// Use this for initialization
	void Start () {
		menuToShow = "Pause";
	}

	// Update is called once per frame
	void Update () {
		//The Escape key or the 'P' key is used as a toggle to pause/unpause
		if (Input.GetKeyDown (KeyCode.Escape) || Input.GetAxisRaw ("Options") != 0) {
			menuToShow = "Pause"; //Reset the menu to show to the initial pause menu
			if (m_isInUse == false) {
				paused = !paused;
				m_isInUse = true;
			}	
		}

		if (Input.GetAxisRaw ("Options") == 0) {
			m_isInUse = false;
		}


		//Only when the mission has not ended is it possible to pauze or unpause the game
		if (!missionHasEnded) {
			if (paused) {
				canvas.SetActive (true);
				Time.timeScale = 0;
			} else {
				canvas.SetActive (false);
				Time.timeScale = 1;
			}
		}

		//Show correct canvas depending on the menuToShow variable
		switch (menuToShow) {
			case "Pause":
				pauseMenu.SetActive (true);
				break;
			case "Controls":
				pauseMenu.SetActive (false);
				break;
			case "Exit":
				pauseMenu.SetActive (false);

                
				break;
		}
	}



	/*The section below contains a large number of methods
     Each visible button in the pause menu executes one of the methods below
     To see which button executes which method, click on one of the buttons in the editor
     The method it executes can be found under "On Click()" in the "Button (Script)" component*/
	public void Resume () {
		paused = false;
	}

	public void Controls () {
		menuToShow = "Controls";
	}

	public void Back () {
		menuToShow = "Pause";
	}

	public void ReturnToMenu () {
		buttonClicked = "Return";
		menuToShow = "Exit";
	}

	public void QuitGame () {
		buttonClicked = "Quit";
		menuToShow = "Exit";
	}

	public void YesButton () {
		switch (buttonClicked) {
			case "Return":
           ///     MissionManagementScript.ResetMissionVariables();
             //   MissionManagementScript.MissionEnd("lose", true);
				break;
			case "Quit":
				Application.Quit ();
				break;
		}
	}

	public void NoButton () {
		menuToShow = "Pause";
	}
}
