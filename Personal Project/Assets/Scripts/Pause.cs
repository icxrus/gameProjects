using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject Canvas;
    bool Paused = false;


    void Start()
    {
        Canvas.gameObject.SetActive(false);
    }

    void Update() // Game Pause system
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
                if (Paused == true)
                {
                    Time.timeScale = 1.0f;
                    Canvas.gameObject.SetActive(false);
                    Cursor.lockState = CursorLockMode.Locked;
                    Paused = false;
                }
                else
                {
                    Time.timeScale = 0.0f;
                    Canvas.gameObject.SetActive(true);
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                    Paused = true;
                }
            
            
        }
        
    }

    public void OnResume() // Resume
    {
        Time.timeScale = 1.0f;
        Canvas.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }



}
