using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = 5f;
    public Camera cam;
    Vector2 moveInput;
    Vector2 mousePos;

    public static int maxHealth = 10;
    public int currentHealth;


    public HealthBar healthBar;
    public GameObject deathEffect;
    public GameObject lifeBar;

    public InGameMenu Menu;
    public InGameMenu CloneMenu;

    private int currentScene;
    public GameObject playerShip;

    public GameObject gameManager;
    public Lives lifeManager;

    private bool invincible;

    //public SpriteFlash spriteFlash;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        currentScene = SceneManager.GetActiveScene().buildIndex;
        invincible = false;
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
            lifeManager.lifeAmount--;
            FindObjectOfType<AudioManager>().Play("Death");
            gameManager.GetComponent<GameManager>().PlayerDeath();
            Instantiate(deathEffect, transform.position, Quaternion.identity);

            invincible = true;
            Invoke("resetInvulnerability", 5);
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

    void resetInvulnerability()
    {
        invincible = false;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (!invincible && (other.gameObject.tag == "EnemyBullet" || other.gameObject.tag == "DamageCollider"))
        {
            currentHealth--;
            healthBar.SetHealth(currentHealth);
            FindObjectOfType<AudioManager>().Play("Hit");

            CinemachineShake.Instance.ShakeCamera(5f, .1f);
        }       
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "HealthPickup" && currentHealth != maxHealth)
        {
            currentHealth++;
            healthBar.SetHealth(currentHealth);
            FindObjectOfType<AudioManager>().Play("Pickup3");
            Destroy(other.gameObject);

            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
        }
    }
}