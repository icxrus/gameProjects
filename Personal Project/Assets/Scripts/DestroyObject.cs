using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{


    void Update()
    {
        // Destroy the object
        Destroy(gameObject, 7);
    }
}
