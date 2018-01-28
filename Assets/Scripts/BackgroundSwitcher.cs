using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundSwitcher : MonoBehaviour
{

    // Use this for initialization
    Image image;

    public bool positive;
    public Sprite selectedSprite;
    public Sprite unselectedSprite;

    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (FindObjectOfType<Signals>().state)
        {
            case "Happy":
                if (positive)
                {
                    image.sprite = selectedSprite;
                }
                else
                {
                    image.sprite = unselectedSprite;
                }

                break;
            case "Sad":
                if (!positive)
                {
                    image.sprite = selectedSprite;
                }
                else
                {
                    image.sprite = unselectedSprite;
                }

                break;
            default:
                break;
        }

    }
}
