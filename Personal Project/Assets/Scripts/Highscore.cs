using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Highscore : MonoBehaviour
{

    public TextMeshProUGUI highScore;

    // Start is called before the first frame update
    void Start()
    {
        highScore.text = "Highscore: " + PlayerPrefs.GetInt("BestScore");
    }


}
