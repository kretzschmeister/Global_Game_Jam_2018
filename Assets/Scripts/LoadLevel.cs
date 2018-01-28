using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour {

    // Use this for initialization
    public void LoadScene(string destinationLevel)
    {
        SceneManager.LoadScene(destinationLevel);
        GameVariables.keyCount = 0;
        GameVariables.gemCount = 0;
        GameVariables.lives = 3;
    }
    void ExitGame()
    {
        Application.Quit();
    }
}
