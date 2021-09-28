using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketEnemy : MonoBehaviour
{

    [SerializeField]
    private int enemyHealth;
    private Rigidbody2D rb;
    public SpriteRenderer sr;

    public static int enemiesLeft;
    public static int totalEnemies;

    public GameObject energyPrefab;
    public GameObject deathEffect;

    private Vector3 lastPosition;

    public float bulletForce = 20f;

    public float shootingDistance;

    private float timeBtwShots;
    public float startTimeBtwShots;

    public GameObject projectile;
    private Transform player;

    public Transform shootingBullet;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = this.GetComponent<Rigidbody2D>();

        timeBtwShots = startTimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
            return;

        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;

        //Shoot if close to player
        if (timeBtwShots <= 0 && Vector2.Distance(transform.position, player.position) <= shootingDistance)
        {
            //Old rotation
            //Instantiate(projectile, transform.position, transform.rotation);
            //New rotation
            GameObject bullet = Instantiate(projectile, shootingBullet.position, shootingBullet.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(shootingBullet.up * bulletForce, ForceMode2D.Impulse);

            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }

        if (enemyHealth <= 0)
        {
            FindObjectOfType<AudioManager>().Play("Death2");
            lastPosition = transform.position;
            Destroy(gameObject);
            Instantiate(deathEffect, lastPosition, Quaternion.identity);
            Instantiate(energyPrefab, lastPosition, Quaternion.identity);
        }
    }

    private void DecreaseOpacity()
    {
        sr.color = new Color(1f, 1f, 1f, .1f);
        Invoke("IncreaseOpacity", 0.1f);
        Debug.Log("Decrease Opacity");
    }

    private void IncreaseOpacity()
    {
        sr.color = new Color(1f, 1f, 1f, 1f);
        Debug.Log("Increase Opacity");
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "PlayerBullet")
        {
            FindObjectOfType<AudioManager>().Play("Hit2");
            enemyHealth--;
            Invoke("DecreaseOpacity", 0f);
        }
    }
}