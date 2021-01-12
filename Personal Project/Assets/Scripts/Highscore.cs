using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Highscore : MonoBehaviour
{

    public TextMeshProUGUI highScore;

    // Highscore system
    void Start()
    {
        highScore.text = "Highscore: " + PlayerPrefs.GetInt("BestScore");
    }


}
