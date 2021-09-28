using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting_old : MonoBehaviour
{
    public Transform shootingBullet;
    public GameObject playerBullet;

    public float bulletForce = 20f;
    private float destroyDelay = 0.5f;

    private float timeBtwShots;
    private float startTimeBtwShots = 0.3f;

    private void Start()
    {
        timeBtwShots = startTimeBtwShots;
    }
    // Update is called once per frame
    void Update()
    {
        if (timeBtwShots <= 0 && Input.GetButton("Fire1")) 
        {
            Shoot();
            FindObjectOfType<AudioManager>().Play("Bullet");

            timeBtwShots = startTimeBtwShots;
        }

        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(playerBullet, shootingBullet.position, shootingBullet.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(shootingBullet.up * bulletForce, ForceMode2D.Impulse);
        Destroy(bullet, destroyDelay);
    }
}
