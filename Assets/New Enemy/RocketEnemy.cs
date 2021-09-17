using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketEnemy : MonoBehaviour
{

    [SerializeField]
    private int enemyHealth;
    private Rigidbody2D rb;
    public static int enemiesLeft;
    public static int totalEnemies;

    public GameObject energyPrefab;

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
            lastPosition = transform.position;
            Destroy(gameObject);
            Instantiate(energyPrefab, lastPosition, Quaternion.identity);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "PlayerBullet")
        {
            enemyHealth--;
            //SpriteFlash.Flash();
        }
    }
}