using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public Transform shootingBullet;
    public GameObject enemyBullet;
    private float shootTimer;
    private float initialShot;

    public float bulletForce = 20f;

    private void Start()
    {
        shootTimer = Random.Range(0.2f, 1f);
        initialShot = Random.Range(0.2f, 1f);
        InvokeRepeating("Shoot", initialShot, shootTimer);
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(enemyBullet, shootingBullet.position, shootingBullet.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(shootingBullet.up * bulletForce, ForceMode2D.Impulse);
    }
}
