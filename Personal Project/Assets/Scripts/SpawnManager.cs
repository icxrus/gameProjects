using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public GameObject player;
    public int width = 5;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", 7, 4);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnRandomAnimal()
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
