using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSpawnManager : MonoBehaviour
{ 
    public healthPickup health;
    [SerializeField]  
    private float healthXPos;
    private float healthYPos;
    private float healthSpawnTimer;

    // Start is called before the first frame update
    void Start()
    {
        healthSpawnTimer = Random.Range(10, 10);
        InvokeRepeating("SpawnHealth", 4.0f, healthSpawnTimer);
    }

    private void SpawnHealth()
    {
        bool healthSpawned = false;
        while (!healthSpawned)
        {
            healthXPos = Random.Range(-25, 25);
            healthYPos = Random.Range(-25, 25);

            Vector3 healthPosition = new Vector3(healthXPos, healthYPos, 0f);

           Instantiate(health, healthPosition, Quaternion.identity);

            healthSpawned = true;
            Debug.Log("Spawned");
        }
    }
}
