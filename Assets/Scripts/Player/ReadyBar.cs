using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReadyBar : MonoBehaviour {
    float switchPoints;
    public Slider switchSlider;                                 // Reference to the UI's health bar.
    public float flashSpeed = 5f;                               // The speed the damageImage will fade at.
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
    // Use this for initialization
    void Start () {
        
        
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        switchPoints = FindObjectOfType<Player_Controller>().timer*25;
        switchSlider.value = switchPoints;
	}
    
}
