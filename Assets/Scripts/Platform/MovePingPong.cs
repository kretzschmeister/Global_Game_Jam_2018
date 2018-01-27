


/* This class is a simple class to move, 
 * A rigidbody object over a set amount of time.
 * it uses public booleans so you can adjust the 
 * x and y pingpongs in the inspector
 * also if it moves x or y or both
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePingPong : MonoBehaviour
{

    //TODO: Replace with other Rigid body
    //Rigidbody2D platformRB;
    public float moveTime = 1;
    bool moveBack;
    private Vector3 startPos;
    public bool movingX;
    public bool movingY;
    public bool startLeft = false, startDown =false;
    public float moveLength = 1;
    // Use this for initialization
    void Start()
    {

        //TODO: replace with other rigidbody
        //platformRB = GetComponent<Rigidbody2D> ();
        startPos = transform.position;
    }

    // Dont mess with this code , go into the inspector.
    void Update()
    {

        if (movingX)
        {
            if (startLeft)
            {
                transform.position = new Vector2(-PingPong(Time.time * moveTime, -startPos.x, -startPos.x + moveLength), transform.position.y);
            }
            else
            {
                transform.position = new Vector2(PingPong(Time.time * moveTime, startPos.x, startPos.x + moveLength), transform.position.y);
            }

        }
        if (movingY)
        {

            if (startDown)
            {
                transform.position = new Vector2(transform.position.x, -PingPong(Time.time * moveTime, -startPos.y, -startPos.y + moveLength));
            }
            else
            {
                transform.position = new Vector2(transform.position.x, PingPong(Time.time * moveTime, startPos.y, startPos.y + moveLength));
            }
        }
    }
    float PingPong(float t, float minLength, float maxLength)
    {
        return Mathf.PingPong(t, maxLength - minLength) + minLength;
    }
}
