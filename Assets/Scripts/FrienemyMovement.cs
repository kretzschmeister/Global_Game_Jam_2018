using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrienemyMovement : MonoBehaviour
{
    float m;
    public bool friend = true, danger =false;
    public bool runningAway = false;
    public float damage = 10;
    bool moving = false;
    float nTimer;
    GameObject player;
    Rigidbody2D rb;
    public float speed = 1, nspeed;
    Vector2 movement;
    Vector2 direction;
    Animator anim;
    float currentScale;
    bool sound = true;
    public  float wayToGo;
    public bool follow = false;
    public float range = 0.25f, distance, rangeT = 3;
    public float moveX = 0, moveY = 0;
    public float timer = 2;
    public float scaryTime = 1;
    float nScaryTime;
    // Use this for initialization
    void Start()
    {
        currentScale = transform.localScale.x;
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        nspeed = speed;
        nTimer = timer;
        nScaryTime = scaryTime;
        timer = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Signals.friend = friend;
        State();
        if (danger) {
            if (sound)
            {
                m -= Time.deltaTime;
                if (m <= 0)
                {
                    sound = false;
                    FindObjectOfType<AudioManager>().Play("Alert");
                    m = 5;
                }
            }
            scaryTime -= Time.deltaTime;
            if (scaryTime <= 0) {
                danger = false;
                scaryTime = nScaryTime;
            }
        }
        Movement();
        if (follow && wayToGo < 0)
        {
            speed = nspeed;
        }
        if (distance >= rangeT )
        {
            speed = 0;
        }
                                                                     
        Animation();
    }
    void Animation()
    {
        if (speed > 0)
        {
            moving = true;
        }
        else
        {
            moving = false;
        }
        if (moveX > 0)
        {
            transform.localScale = new Vector3(currentScale * -1, currentScale, 1);
        }
        else if (moveX < 0) {

            transform.localScale = new Vector3(currentScale , currentScale, 1);
        }
        anim.SetBool("Run", danger);
        anim.SetBool("Moving", moving);
    }
    void Movement()
    {
        moveX = wayToGo * direction.x;
        moveY = rb.velocity.y;
        direction = player.transform.position - gameObject.transform.position;
        distance = direction.magnitude;
        movement = new Vector2(moveX, moveY);
        rb.angularVelocity = 0;
        movement.Normalize();
        rb.velocity = speed * movement;


    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, range);
    }
    void DamagePlayer(float damage)
    {
        FindObjectOfType<SwitchBar>().SpendPoints(damage);
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Signal")
        {
            if (runningAway) danger = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!friend)
        {
            if (collision.gameObject.tag == "Player")
            {
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    DamagePlayer(damage);
                    timer = nTimer;
                }
            }
        }
        //enemy doesnt move when clos
        if (collision.gameObject.tag == "Signal")
        {
            if (distance >= range || !friend)
            {
                
                follow = false;
                Debug.Log("1");
                speed = nspeed;
            }
            else
            {
                speed = 0;
                follow = true;
                Debug.Log("2");
            }

        }
    }
    void State() {
        switch (FindObjectOfType<Signals>().state)
        {
            case "Happy":
                if (friend)
                {
                    wayToGo = 1;
                    runningAway = false;
                }
                else
                {
                    wayToGo = 0;
                }

               
                //Debug.Log("happy");
                break;
            case "Sad":
                if (friend)
                {
                    wayToGo = -1;
                    runningAway = true;
                }
                else
                {
                    wayToGo = 1;
                    runningAway = false;
                }

                //Debug.Log("sad");
                break;
            default:
                break;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Signal")
        {
            sound = true;
            speed = 0;
            follow = false;
        }
    }
}
