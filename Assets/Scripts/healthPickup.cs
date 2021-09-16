using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthPickup : MonoBehaviour
{


    public void Update()
    {
          
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.currentHealth++;
            player.currentHealth=player.maxHealth;
            
            Debug.Log("Health picked up");
        }
    }
}
