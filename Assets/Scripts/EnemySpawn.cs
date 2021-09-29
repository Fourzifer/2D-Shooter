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
    public float maxSpawned;

    //private int currentScene;

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
            switch (SceneTransition.currentScene)
            {
                case 2:
                    print("Level 1 Spawn");
                    enemyXPos = Random.Range(-50, 25);
                    enemyYPos = Random.Range(-25, 25);
                    break;
                case 3:
                    print("Level 2 spawn");
                    enemyXPos = Random.Range(-45, 25);
                    enemyYPos = Random.Range(-50, 80);
                    break;
                case 5:
                    print("Level 4 spawn");
                    enemyXPos = Random.Range(-50, 25);
                    enemyYPos = Random.Range(-80, 30);
                    break;
                default:
                    print("No enemy spawn range");
                    break;
            }

            enemySpawned = true;
            print("Spawned");

            Vector3 enemyPosition = new Vector3(enemyXPos, enemyYPos, 0f);

            if (BulletEnemy.currentEnemies <= maxSpawned)
            {
                Instantiate(enemy, enemyPosition, Quaternion.identity);

                print("Spawned");
                Debug.Log("Max spawned: " + maxSpawned);
                Debug.Log("Current spawned: " + BulletEnemy.currentEnemies);
            }

        }
    }
}
