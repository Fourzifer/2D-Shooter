using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationaryEnemy : MonoBehaviour
{
    [SerializeField]
    private int enemyHealth;

    public Transform player;
    private float moveSpeed = 5f;
    private Vector2 movement;
    private Rigidbody2D rb;

    private Vector3 lastPosition;

    public static int enemiesLeft;
    public static int totalEnemies;

    public GameObject energyPrefab;

    private void Awake()
    {
        totalEnemies++;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        enemiesLeft = totalEnemies;
        Energy.neededEnergy = totalEnemies;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth <= 0)
        {
            lastPosition = transform.position;
            Destroy(gameObject);
            enemiesLeft--;
            Debug.Log("Enemies left: " + enemiesLeft);
            Instantiate(energyPrefab, lastPosition, Quaternion.identity);
        }

        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
    }

    private void FixedUpdate()
    {
        moveCharacter(movement);
    }

    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "PlayerBullet")
        {
            enemyHealth--;
        }
    }
}