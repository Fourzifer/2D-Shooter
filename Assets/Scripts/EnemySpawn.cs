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
        enemySpawnTimer = Random.Range(3, 5);
        InvokeRepeating("SpawnEnemy", 4.0f, enemySpawnTimer);
    }

    private void SpawnEnemy()
    {
        bool enemySpawned = false;
        while (!enemySpawned)
        {
            //-28, 28
            enemyXPos = Random.Range(-10, 10);
            //-26, 28
            enemyYPos = Random.Range(-10, 10);

            Vector3 enemyPosition = new Vector3(enemyXPos, enemyYPos, 0f);

            Instantiate(enemy, enemyPosition, Quaternion.identity);

            enemySpawned = true;
            Debug.Log("Spawned");
        }
    }
}
