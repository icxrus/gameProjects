using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject obstaclePrefab;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private float startDelay = 2;
    private float repeatDelay = 2;
    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        // Repeat obstacle spawn
        InvokeRepeating("SpawnObstacle", startDelay, repeatDelay);
        playerControllerScript =
            GameObject.Find("Player").GetComponent<PlayerController>();

    }

    // Stop spawning obstacle if game is over
    void SpawnObstacle () {
        if (playerControllerScript.gameOver == false) {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
    }
}
