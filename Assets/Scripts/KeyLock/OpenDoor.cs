using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D col){
		if (col.gameObject.tag == "Player" && GameVariables.keyCount > 0) {
		//destroy key and give key to player. 
			GameVariables.keyCount -=1;
			Destroy (gameObject);
			//FindObjectOfType<AudioManager> ().Play ("OpenDoor");
		}
	}
}
