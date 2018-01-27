using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{


    public float maxSpeed;
    Rigidbody2D myRB;

    //variables for happy/sad switch
    bool switchState = false;
    public float timer =4;
    float nTimer;
    float currentScale;
	//public static float move;
    Animator anim;
    public bool moving = false;
    //variables for platform check
    private bool grounded = false;
    public Transform groundCheck;
    private float groundCheckradius = 0.4f;
    public LayerMask groundLayer;
    public float jumpHeight;
    public float nextJump;
    
    void Start()
    {
        currentScale = transform.localScale.x;
        anim = GetComponent<Animator>();
        nTimer = timer;
        //states = GetComponent<enumScript> ();
        myRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {

        timer -= Time.deltaTime;
        //	grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckradius, groundLayer);
        float move = Input.GetAxis("Horizontal");
        
        myRB.velocity = new Vector2(move * maxSpeed, myRB.velocity.y);
        Animation();

        //if ( Input.Getaxis("X" && happy == true) ---> Sad
        //if ( Input.Getaxis("X" && sad   == true) ---> happy
        if ((Input.GetAxis("X") > 0 || Input.GetKeyDown(KeyCode.F)) && timer<=0 && SwitchBar.switchPoints >=0)
        {
            timer = nTimer;
            if (Signals.t)
            {
                Signals.t = false;
               // Debug.Log("false");
            }
            else
            {
                Signals.t = true;
                Debug.Log("true");
            }

            //TODO: Switch states, happy for 4 seconds minimum. Timer so you cant keep switching
        }
        else if (Input.GetAxis("Options") > 0)
        {

            //TODO: Let it go to the menu 
        }
        else if (Input.GetAxis("Square") > 0)
        {

            // this is an extra functional button
            //TODO: Add the extra functionality ! Maybe a door ?
        }
    }
    void Animation() {
        if (myRB.velocity.x != 0)
        {
            moving = true;
        }
        else
        {
            moving = false;
        }
        if (myRB.velocity.x > 0)
        {
            transform.localScale = new Vector3(currentScale * -1, currentScale, 1);
        }
        else if (myRB.velocity.x < 0)
        {

            transform.localScale = new Vector3(currentScale, currentScale, 1);
        }
        anim.SetBool("Moving", moving);
    }
}
