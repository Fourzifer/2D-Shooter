using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;

    private Transform player;
    private Vector2 target;
    public int enemyType;

    private int destroyDelay = 3;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        switch (enemyType)
        {
            case 0:
                transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
                break;
            case 1:
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
                Destroy(gameObject, destroyDelay);
                break;
            default:
                transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
                break;
        }

        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyProjectile();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DestroyProjectile();
        }
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
