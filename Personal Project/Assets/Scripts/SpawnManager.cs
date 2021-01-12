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
        // Repeat spawns
        InvokeRepeating(nameof(SpawnRandomAnimal), 5, 4);
        Invoke(nameof(SpawnEnemy), delay);
    }

    // Objects Random spawn and location
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

    //Rock spawn point and speed
    void SpawnEnemy()
    {
            for (int i = 0; i < 1; i++)
            {
                int enemyIndex = Random.Range(0, enemyPrefabs.Length);
                float insLocation = Random.Range(-width, width + 1);

                Vector3 spawnPos = new Vector3(insLocation, transform.position.y, transform.position.z);
                Instantiate(enemyPrefabs[enemyIndex], spawnPos, player.transform.rotation);

            }

        Invoke(nameof(SpawnEnemy), delay);

        if (delay > 1)
        {
            delay -= 0.25f;
        }
    }
}
