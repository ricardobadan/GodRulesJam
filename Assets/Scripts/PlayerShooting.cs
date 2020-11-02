using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce;
    public DialogManager dialogManager;

    void Start()
    {
        
    }
    void Update()
    {

        if (Input.GetButtonDown("Fire1") && dialogManager.canFire)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        AudioManager.instance.Play("Gunshot");
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb2d = bullet.GetComponent<Rigidbody2D>();
        rb2d.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
