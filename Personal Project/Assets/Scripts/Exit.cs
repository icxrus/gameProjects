﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    public static Exit Instance;

    void Awake()
    {
        Instance = this;
    }

    // Exit Game
    public void DoExitGame()
    {
        Application.Quit();
        Debug.Log("Quit the game!");
    }
}
