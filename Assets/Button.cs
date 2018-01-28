using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour {
    public GameObject platform;
    SpriteRenderer spriteRenderer;
    public Sprite buttonUpSprite;
    public Sprite buttonDownSprite;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = buttonUpSprite;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        

    }
   
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Frienemy") {
           if(platform!=null) platform.GetComponent<MovePingPong>().move = true;

            spriteRenderer.sprite = buttonDownSprite;

        }
    }
}
