using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrienemyMovement : MonoBehaviour
{
    GameObject player;
    Rigidbody2D rb;
    public float speed = 1;
    Vector2 movement;
    Vector2 direction;
    Animator anim;
    public float range = 0.25f, distance;
     public float moveX = 0, moveY = 0;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
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
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Signal")
        {
            if (distance >= range)
            {
                moveX = Signals.wayToGo * direction.x;
            }
            else {
                moveX = 0;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Signal")
        {
            moveX = 0;
        }
    }
}
