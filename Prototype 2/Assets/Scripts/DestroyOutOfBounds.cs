using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{

    private float topBound = 30;
    private float lowerBound = -10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Destroys Animals and Food if they go out of the play area
        if (transform.position.z > topBound) {
            Destroy(gameObject); 
        } else if (transform.position.z < lowerBound) {
            Destroy(gameObject);
        }
        {
            // Game over message if animals reach bottom of screen
            Debug.Log("Game Over!");
            Destroy(gameObject);
        }


    }
}
