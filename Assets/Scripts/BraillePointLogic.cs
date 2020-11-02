using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BraillePointLogic : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public bool isActive;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer.color = Color.black;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            InvertColor();
        }
    }

    void InvertColor()
    {
        if(spriteRenderer.color == Color.black)
        {
            isActive = true;
            spriteRenderer.color = Color.white;
        }
        else
        {
            isActive = false;
            spriteRenderer.color = Color.black;
        }
    }
}
