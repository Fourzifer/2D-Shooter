using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossEnemy : MonoBehaviour
{

    [SerializeField]
    private Rigidbody2D rb, rb2;
    [SerializeField] private SpriteRenderer sr;

    public int enemyHealth;
    public static int enemyMaxHealth = 100;

    public static int enemiesLeft;
    public static int totalEnemies;

    public BossHealthBar HealthBar;

    public Animator transitionAnim;
    public GameObject deathEffect;

    private Vector3 lastPosition;

    public float speed;
    public float stoppingDistance;
    public float retreatDistance;
    public float shootingDistance;

    private float timeBtwShots;
    public float startTimeBtwShots;

    public GameObject projectile;
    private Transform player;

    public Transform shootingBullet1, shootingBullet2;
    public float bulletForce = 20f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = this.GetComponent<Rigidbody2D>();
        rb2 = this.GetComponent<Rigidbody2D>();

        timeBtwShots = startTimeBtwShots;

        enemyHealth = enemyMaxHealth;
        HealthBar.SetMaxHealth(enemyMaxHealth);

    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
            return;

        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;

        //Move towards player
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        //Stop at a distance away from player
        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }
        //Move away from player
        else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }

        //Shoot if close to player
        if (timeBtwShots <= 0 && Vector2.Distance(transform.position, player.position) <= shootingDistance)
        {
            GameObject bullet = Instantiate(projectile, shootingBullet1.position, shootingBullet1.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(shootingBullet1.up * bulletForce, ForceMode2D.Impulse);

            GameObject bullet2 = Instantiate(projectile, shootingBullet2.position, shootingBullet2.rotation);
            Rigidbody2D rb2 = bullet2.GetComponent<Rigidbody2D>();
            rb2.AddForce(shootingBullet2.up * bulletForce, ForceMode2D.Impulse);

            timeBtwShots = startTimeBtwShots;
        }

        else
        {
            timeBtwShots -= Time.deltaTime;
        }

        if (enemyHealth <= 0)
        {
            StartCoroutine(TheEnd());
        }
    }

    private void DecreaseOpacity()
    {
        sr.color = new Color(1f, 1f, 1f, .1f);
        Invoke("IncreaseOpacity", 0.1f);
    }

    private void IncreaseOpacity()
    {
        sr.color = new Color(1f, 1f, 1f, 1f);
    }

    IEnumerator TheEnd()
    {
        transitionAnim.SetTrigger("fadeOut");
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "PlayerBullet")
        {
            FindObjectOfType<AudioManager>().Play("Hit2");
            enemyHealth--;
            HealthBar.SetHealth(enemyHealth);
            Invoke("DecreaseOpacity", 0f);
        }
    }
}