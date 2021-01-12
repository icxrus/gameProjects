using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCount : MonoBehaviour
{

    public int score;
    public TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        UpdateScore(0);
    }

    // Score System
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
        if (score > PlayerPrefs.GetInt("BestScore"))
            PlayerPrefs.SetInt("BestScore", score);
    }
}
