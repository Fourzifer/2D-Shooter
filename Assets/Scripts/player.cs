using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = 5f;
    public Camera cam;
    Vector2 moveInput;
    Vector2 mousePos;

    public static int maxHealth = 10;
    public static int currentHealth;

    public HealthBar healthBar;
    public GameObject deathEffect;

    public InGameMenu Menu;
    public InGameMenu CloneMenu;

    private int currentScene;
    public GameObject playerShip;

    public GameObject gameManager;


    //public SpriteFlash spriteFlash;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        currentScene = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        //WASD MOVEMENT
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        //MOUSE MOVEMENT
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        //Player death
        if (currentHealth <= 0)
        {
            gameManager.GetComponent<GameManager>().PlayerDeath();
            Enemy.totalEnemies = 0;
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Energy.currentEnergy = 0;
        }

        if (Input.GetButtonDown("Cancel"))
        {
            CloneMenu = Instantiate(Menu);
        }
    }

    private void FixedUpdate()
    {
        //WASD MOVEMENT
        rb.AddForce(moveInput * moveSpeed * 100 * Time.deltaTime, ForceMode2D.Force);

        //MOUSE MOVEMENT
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "EnemyBullet" || other.gameObject.tag == "DamageCollider")
        {
            currentHealth--;
            healthBar.SetHealth(currentHealth);
            CinemachineShake.Instance.ShakeCamera(5f, .1f);
            //spriteFlash.Flash();
            //SpriteFlash.GetComponent<SpriteFlash>.Flash();
        }       
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "HealthPickup" && currentHealth != maxHealth)
        {
            currentHealth++;
            healthBar.SetHealth(currentHealth);
            Destroy(other.gameObject);

            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
        }
    }
}