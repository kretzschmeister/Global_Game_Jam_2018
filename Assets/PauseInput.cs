using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseInput : MonoBehaviour {

    public string sceneCross, sceneTriangle, sceneSquare, sceneCircle;
    // Use this for initialization
    private void FixedUpdate()
    {
        if (FindObjectOfType<PauseGame>().paused)
        {
            if (Input.GetAxis("Square") > 0)
            {
                LoadScene(sceneSquare);
                // this is an extra functional button
                //TODO: Add the extra functionality ! Maybe a door ?
            }
            else if (Input.GetAxis("Triangle") > 0)
            {
                LoadScene(sceneTriangle);
                // this is an extra functional button
                //TODO: Add the extra functionality ! Maybe a door ?
            }
            else if (Input.GetAxis("Circle") > 0)
            {
                LoadScene(sceneCircle);
                // this is an extra functional button
                //TODO: Add the extra functionality ! Maybe a door ?
            }
            else if (Input.GetAxis("X") > 0)
            {
                Scene loadedLevel = SceneManager.GetActiveScene();
                LoadScene(loadedLevel.name);
                // this is an extra functional button
                //TODO: Add the extra functionality ! Maybe a door ?
            }
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
}
