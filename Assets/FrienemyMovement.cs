using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrienemyMovement : MonoBehaviour {

    Rigidbody2D rb;
    public float speed = 1;
    Vector2 movement;
    Animator anim;
    float moveX, moveY;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        moveX = Signals.wayToGo;
        movement = new Vector2(moveX, moveY);
        rb.angularVelocity = 0;
        movement.Normalize();
        rb.velocity = speed * movement;
	}
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Signal")
        {
            Debug.Log("works");
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {

    }
}
