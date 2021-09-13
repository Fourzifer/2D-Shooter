using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static int enemiesLeft = 3;
    [SerializeField]
    private int enemyHealth;

    // Start is called before the first frame update
    void Start()
    {
        //enemyHealth = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
            enemiesLeft--;
        }
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "PlayerBullet")
        {
            enemyHealth--;
        }
    }
}