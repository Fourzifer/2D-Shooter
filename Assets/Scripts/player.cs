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

    private int currentScene;

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

        if (currentHealth <= 0)
        {
            Enemy.totalEnemies = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Energy.currentEnergy = 0;
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