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

    private int currentScene;

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
            switch (currentScene)
            {
                case 0:
                    print("Level 1 Spawn");
                    enemyXPos = Random.Range(-25, 25);
                    enemyYPos = Random.Range(-25, 25);
                    break;
                case 1:
                    print("Level 2 Spawn");
                    enemyXPos = Random.Range(-25, 25);
                    enemyYPos = Random.Range(-25, 25);
                    break;
                case 2:
                    print("Level 3");
                    break;
                case 3:
                    print("Level 4");
                    break;
                case 4:
                    print("Level 5");
                    break;
                default:
                    enemyXPos = Random.Range(-25, 25);
                    enemyYPos = Random.Range(-25, 25);
                    print("default spawn");
                    break;
            }



            Vector3 enemyPosition = new Vector3(enemyXPos, enemyYPos, 0f);

            Instantiate(enemy, enemyPosition, Quaternion.identity);

            enemySpawned = true;
            Debug.Log("Spawned");
        }
    }
}
