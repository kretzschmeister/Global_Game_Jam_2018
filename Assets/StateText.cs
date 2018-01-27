using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateText : MonoBehaviour {
    Text stateText;
    public static string state;
	// Use this for initialization
	void Start () {
        stateText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        stateText.text = state;
    }
}
