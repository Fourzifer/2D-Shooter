using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInstantiatable : MonoBehaviour
{
    [SerializeField]
    private int enemyHealth;

    public static Transform player;
    private float moveSpeed = 5f;
    public static Vector2 movement;
    private Rigidbody2D rb;

    private Vector3 lastPosition;

    public static int enemiesLeft;
    public static int totalEnemies;

    public GameObject energyPrefab;

    private EnemyShooting enemyShooting;

    private void Awake()
    {
        totalEnemies++;
    }

    // Start is called before the first frame update
    void Start()
    {
        enemyShooting = GetComponent<EnemyShooting>();
        rb = this.GetComponent<Rigidbody2D>();
        enemiesLeft = totalEnemies;
        //Energy.neededEnergy = totalEnemies;
        player = GameObject.Find("PlayerShip").transform;
        //Invoke("StartShooting", 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth <= 0)
        {
            lastPosition = transform.position;
            Destroy(gameObject);
            //enemiesLeft--;
            //Debug.Log("Enemies left: " + enemiesLeft);
            Instantiate(energyPrefab, lastPosition, Quaternion.identity);
        }

        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
        //Debug.Log(Vector2.Distance(movement, player.position));
    }

    //void StartShooting()
    //{
    //    if (Mathf.Abs(movement.x - transform.position.x) < 10)
    //    {
    //        Debug.Log("Did the thing");

    //        enemyShooting.InvokeRepeating("Shoot", 0, 0.2f);
    //    }

    //    else
    //    {
    //        Debug.Log("Not in range");
    //        return;
    //    }
    //}

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