using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour {


	public float maxSpeed;
	Rigidbody2D myRB;

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
		float move	= Input.GetAxis ("Horizontal");
		myRB.velocity = new Vector2 (move * maxSpeed, myRB.velocity.y);
	}
}
