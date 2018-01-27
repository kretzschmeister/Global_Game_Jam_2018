using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SwitchBar : MonoBehaviour {
    public float switchPoints;
    public Slider switchSlider;                                 // Reference to the UI's health bar.
    public float flashSpeed = 5f;                               // The speed the damageImage will fade at.
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
    // Use this for initialization
    void Start () {
        FillBar();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		switchSlider.value = switchPoints;
        if (switchPoints <= 0) GameOver();
	}
    public void SpendPoints(float spend) {
        
        switchPoints -= spend;
    }
    void GameOver() {
        SceneManager.LoadScene("Game Over");
    }
    void FillBar() {
        switchPoints = GameVariables.signalSwitcherPoints;
    }
}
