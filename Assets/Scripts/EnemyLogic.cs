using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    Transform playerTransform;
    public float minDistance;
    public float chaseSpeed;
    CameraShake camShake;
    public GameObject bloodPrefab;
    SpriteRenderer spriteRenderer;
    Animator anim;
   
   
    private void Awake()
    {
        anim = GetComponent<Animator>();
        camShake = GameObject.FindGameObjectWithTag("CameraShake").GetComponent<CameraShake>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        Invoke("Evaporate", 8f);
    }
    private void FixedUpdate()
    {
        LookAtPlayer();
        ChasePlayer();
    }
    void ChasePlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, chaseSpeed * Time.deltaTime);
    }

    void LookAtPlayer()
    {
        Vector3 difference = playerTransform.position - transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ - 90f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            GameLogic.killCount++;
            camShake.CamShake();
            AudioManager.instance.Play("Blood");
            Instantiate(bloodPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    void Evaporate()
    {
        anim.SetTrigger("canEvaporate");
    }

   
}
