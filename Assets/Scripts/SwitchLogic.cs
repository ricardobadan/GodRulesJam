using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchLogic : MonoBehaviour
{

    public Sprite[] sprites;
    public SpriteRenderer spriteRenderer;
    bool canSwitch;
    public bool isActive;
    void Start()
    {
        spriteRenderer.sprite = sprites[0];
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.R) && canSwitch)
        {
            if (spriteRenderer.sprite == sprites[0])
            {
                isActive = true;
                spriteRenderer.sprite = sprites[1];
            }
            else if (spriteRenderer.sprite == sprites[1])
            {
                isActive = false;
                spriteRenderer.sprite = sprites[0];
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        canSwitch = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canSwitch = false;
    }

}
