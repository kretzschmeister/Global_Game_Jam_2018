using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour {


	public float maxSpeed;
	Rigidbody2D myRB;

	//variables for happy/sad switch
	bool switchState = false;

	public static float move;



	//variables for platform check
	private bool grounded = false;
	public  Transform groundCheck;
	private float groundCheckradius = 0.4f;
	public LayerMask groundLayer;
	public float jumpHeight;
	public float nextJump;

	void Start () {
	
		//states = GetComponent<enumScript> ();
		myRB = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void FixedUpdate(){
		
	//	grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckradius, groundLayer);
		 move	= Input.GetAxis ("Horizontal");
		myRB.velocity = new Vector2 (move * maxSpeed, myRB.velocity.y);


		//if ( Input.Getaxis("X" && happy == true) ---> Sad
		//if ( Input.Getaxis("X" && sad   == true) ---> happy
		if (Input.GetAxis ("X") >0) {

		//TODO: Switch states, happy for 4 seconds minimum. Timer so you cant keep switching
		}else if (Input.GetAxis ("Options") >0) {

		//TODO: Let it go to the menu 
		}else 	if (Input.GetAxis ("Square") >0) {

			// this is an extra functional button
		//TODO: Add the extra functionality ! Maybe a door ?
		}
	}
}
