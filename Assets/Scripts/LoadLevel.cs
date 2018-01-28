using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour {
    public string scene1, scene2, scene3,scene4;
    // Use this for initialization
    private void FixedUpdate()
    {
        if (Input.GetAxis("Square") > 0)
        {
            LoadScene(scene1);
            // this is an extra functional button
            //TODO: Add the extra functionality ! Maybe a door ?
        }
        else if (Input.GetAxis("Triangle") > 0)
        {
            LoadScene(scene2);
            // this is an extra functional button
            //TODO: Add the extra functionality ! Maybe a door ?
        }
        else if (Input.GetAxis("Circle") > 0)
        {
            LoadScene(scene3);
            // this is an extra functional button
            //TODO: Add the extra functionality ! Maybe a door ?
        }
        else if (Input.GetAxis("X") > 0)
        {
            LoadScene(scene4);
            // this is an extra functional button
            //TODO: Add the extra functionality ! Maybe a door ?
        }
    }
    public void LoadScene(string destinationLevel)
    {
        SceneManager.LoadScene(destinationLevel);
        GameVariables.keyCount = 0;
        GameVariables.gemCount = 0;
        Signals.t = false;
        GameVariables.lives = 3;
    }
    void ExitGame()
    {
        Application.Quit();
    }
}
