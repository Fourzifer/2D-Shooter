using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthPickup : MonoBehaviour
{
    public HealthBar healthBar;
    public GameObject health;

    public void Update()
    {
          
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.currentHealth = player.currentHealth +5;
            healthBar.SetHealth(player.currentHealth);
            Destroy(health);
        }
    }
}
