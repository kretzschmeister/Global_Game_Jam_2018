using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signals : MonoBehaviour
{
    public float spendPoints = 1;
    public string state;
    public static bool t = true, friend;
    public static float wayToGo;
    public float timer = 1, nTimer;
    // Use this for initialization
    void Start()
    {
        nTimer = timer;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        state = ChangeState(t);
        StateText.state = state;
        switch (state)
        {
            case "Happy":
                if (friend)
                {
                    wayToGo = 1;
                }
                else
                {
                    wayToGo = 0;
                }
                
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    FindObjectOfType<SwitchBar>().SpendPoints(spendPoints);
                    timer = nTimer;
                }
                //Debug.Log("happy");
                break;
            case "Sad":
                if (friend)
                {
                    wayToGo = -1;
                }
                else
                {
                    wayToGo = 1;
                }

                //Debug.Log("sad");
                break;
            default:
                break;
        }


    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Frienemy") {

        }
    }
    public string ChangeState(bool activeState)
    {
        string state;
        if (activeState)
        {
            state = "Happy";
        }
        else
        {
            state = "Sad";
        }

        return state;
    }
}
