using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GemsText : MonoBehaviour {
    Text gemsText;
	// Use this for initialization
	void Start () {
        gemsText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        gemsText.text = "" + GameVariables.gemCount;
    }
}
