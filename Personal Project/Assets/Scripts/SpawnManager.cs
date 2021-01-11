using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public GameObject[] enemyPrefabs;
    public GameObject player;
    public int width = 5;
    public float delay = 7;

 
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", 5, 4);
        Invoke("SpawnEnemy", delay);
    }

    void SpawnRandomAnimal()
    {
        {

            for (int i = 0; i < 1; i++)
            {
                int animalIndex = Random.Range(0, obstaclePrefabs.Length);
                float insLocation = Random.Range(-width, width + 1);

                Vector3 spawnPos = new Vector3(insLocation, transform.position.y, transform.position.z);
                Instantiate(obstaclePrefabs[animalIndex], spawnPos, player.transform.rotation);

            }
        }

    }

    void SpawnEnemy()
    {
   

            for (int i = 0; i < 1; i++)
            {
                int enemyIndex = Random.Range(0, enemyPrefabs.Length);
                float insLocation = Random.Range(-width, width + 1);

                Vector3 spawnPos = new Vector3(insLocation, transform.position.y, transform.position.z);
                Instantiate(enemyPrefabs[enemyIndex], spawnPos, player.transform.rotation);

            }

        Invoke("SpawnEnemy", delay);

        if (delay > 1)
        {
            delay -= 0.25f;
        }
    }


}
