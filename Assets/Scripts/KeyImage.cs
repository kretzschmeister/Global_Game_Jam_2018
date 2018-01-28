using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyImage : MonoBehaviour {
    // Use this for initialization
    Image image;
    public bool key;
    public Sprite keySprite;
    public Sprite noKeySprite;
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       /* if (key)
        {
            GameVariables.keyCount = 1;
        }
        else {

            GameVariables.keyCount = 0;
        }*/
        if (GameVariables.keyCount >= 1)
        {


            image.sprite = keySprite;
        }
        else {

            image.sprite = noKeySprite;
        }

    }
}
