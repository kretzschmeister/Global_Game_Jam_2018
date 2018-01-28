using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {

	public string variable;
	public int pickUpBonus;


	void OnTriggerEnter2D (Collider2D col){
		if (col.gameObject.tag == "Player") {
			//FindObjectOfType<AudioManager>().Play("PickUp");
			switch(variable){
				case "key":
					GameVariables.keyCount += 1;
                    FindObjectOfType<AudioManager>().Play("pick up key");
					Destroy (gameObject);
					break;
				case "gem":
					GameVariables.gemCount += 1;
                    FindObjectOfType<AudioManager>().Play("gem");
                    Destroy(gameObject);
					break; 
			}
		}
	}
}
