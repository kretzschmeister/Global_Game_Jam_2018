using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSwitch : MonoBehaviour {


	public string level ; 
	// Use this for initialization

	void OnTriggerEnter2D (Collider2D colider){
		if (colider.gameObject.tag == "Player"){
			Application.LoadLevel (level);
		}
	}
}
