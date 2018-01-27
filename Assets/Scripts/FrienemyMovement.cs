using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrienemyMovement : MonoBehaviour
{
    public bool friend = true;
    public float damage = 10;
    float nTimer;
    GameObject player;
    Rigidbody2D rb;
    public float speed = 1, nspeed;
    Vector2 movement;
    Vector2 direction;
    Animator anim;
    public bool follow = false;
    public float range = 0.25f, distance;
    public float moveX = 0, moveY = 0;
    public float timer = 2;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        nspeed = speed;
        nTimer = timer;
        timer = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Signals.friend = friend;
        

        Movement();
       if (follow && Signals.wayToGo<=0)
        {
            speed = nspeed;
        }
      

    }
    void Movement()
    {
        moveX = Signals.wayToGo * direction.x;
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
    void DamagePlayer(float damage) {
        FindObjectOfType<SwitchBar>().SpendPoints(damage);
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(!friend){
            if (collision.gameObject.tag == "Player") {
                timer -= Time.deltaTime;
                if (timer <= 0) {
                    DamagePlayer(damage);
                    timer = nTimer;
                }
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        //enemy doesnt move when clos
        if (collision.gameObject.tag == "Signal")
        {
            if (distance >= range || !friend)
            {
                follow = false;
                speed = nspeed;
            }
            else
            {
                speed = 0;
                follow = true;
            }

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Signal")
        {
            speed = 0;
            follow = false;
        }
    }
}
