using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SwitchBar : MonoBehaviour {
    public static float switchPoints;
    public Slider switchSlider;                                 // Reference to the UI's health bar.
    public float flashSpeed = 5f;                               // The speed the damageImage will fade at.
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
    public Image damageImage;                                   // Reference to an image to flash on the screen on being hurt.

    public bool damaged;
    // Use this for initialization
    void Start () {
        FillBar();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		switchSlider.value = switchPoints;
        if (switchPoints <= 0) GameOver();
        if (damaged)
        {
            // ... set the colour of the damageImage to the flash colour.
            damageImage.color = flashColour;
        }
        // Otherwise...
        else
        {
            // ... transition the colour back to clear.
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }

        // Reset the damaged flag.
        damaged = false;
    }
    public void SpendPoints(float spend) {
        
        switchPoints -= spend;
        
    }
    void GameOver() {
        FillBar();
        SceneManager.LoadScene("Game Over");
    }
    void FillBar() {
        switchPoints = GameVariables.signalSwitcherPoints;
    }
}
