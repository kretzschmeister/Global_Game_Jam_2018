using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadyText : MonoBehaviour
{

    Text readyText;
    // Use this for initialization
    void Start()
    {
        readyText = GetComponent<Text>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (FindObjectOfType<Player_Controller>().timer >=4)
        {

            readyText.text = "Ready!";

        }
        else
        {

            readyText.text = " ";
        }
    }
}
