using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy;
    private float enemyXPos;
    private float enemyYPos;
    private float enemySpawnTimer;

    // Start is called before the first frame update
    void Start()
    {
        enemySpawnTimer = Random.Range(3, 4);
        InvokeRepeating("SpawnEnemy", 4.0f, enemySpawnTimer);
    }

    private void SpawnEnemy()
    {
        bool enemySpawned = false;
        while (!enemySpawned)
        {
            enemyXPos = Random.Range(-25, 25);
            enemyYPos = Random.Range(-25, 25);

            Vector3 enemyPosition = new Vector3(enemyXPos, enemyYPos, 0f);

            Instantiate(enemy, enemyPosition, Quaternion.identity);

            enemySpawned = true;
            Debug.Log("Spawned");
        }
    }
}
