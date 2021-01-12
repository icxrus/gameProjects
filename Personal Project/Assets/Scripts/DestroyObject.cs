using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    Renderer thisRenderer;

    void Start()
    {
        thisRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
        // Destroy Object when outside of camera area   
        if (!thisRenderer.isVisible)
        {

             Destroy(gameObject, 2f);
        }
    }
}