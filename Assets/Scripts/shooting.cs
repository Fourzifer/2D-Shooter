using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public Transform shootingBullet;
    public GameObject playerBullet;

    public float bulletForce = 20f;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) 
        {
            Shoot();
            //FindObjectOfType<AudioManager>().Play("Bullet");
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(playerBullet, shootingBullet.position, shootingBullet.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(shootingBullet.up * bulletForce, ForceMode2D.Impulse);
    }
}
