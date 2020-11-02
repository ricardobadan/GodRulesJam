using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    Vector2 movement;
    Vector2 mousePos;
    
    Rigidbody2D rb2d;
    public Camera cam;
    AudioSource audioSource;
    bool isPaused;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");    
        movement.y = Input.GetAxisRaw("Vertical");
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (movement != Vector2.zero)
        {
            if (audioSource.isPlaying)
            {
                return;
            }
            if (isPaused)
            {
                audioSource.UnPause();
                isPaused = false;
            }
            audioSource.Play();
        }
        else
        {
            if (audioSource.isPlaying)
            {
                audioSource.Pause();
                isPaused = true;
            }
        }
        
    }

    private void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position + movement * moveSpeed * Time.fixedDeltaTime);
        Vector2 lookDir = mousePos - rb2d.position;
        float angleToLook = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        rb2d.rotation = angleToLook;
    }
}
