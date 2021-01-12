using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipVideo : MonoBehaviour
{
    private void Update()
    {
        // Skip with spacebar
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Menu");
        }
    }
    

}
