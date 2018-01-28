using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour {

    // Use this for initialization

    /*
	void OntriggerStay2D(Collider2D col){
		if (col.gameObject.tag == "Platform") {
			transform.parent = col.transform;
		}
	}
		void OntriggerExit2D(Collider2D col){
		if (col.gameObject.tag == "Platform") {
			transform.parent = null;
		}

		}
	} */
    public bool collision;

	private GameObject target =null;
	private Vector3 offset;

	void Start(){
		target = null;

	}
    private void OnCollisionStay2D(Collision2D col)
    {

        target = col.gameObject;
        offset = target.transform.position - transform.position;
        collision = true;
    }
    private void OnCollisionExit2D(Collision2D col)
    {
        //Debug.Log("null");
        collision = false;
		target = null;
    }
    

	void Update(){
	
		if (target !=null){
			target.transform.position = transform.position + offset ;
          //  Debug.Log("move");
		}
	}
}