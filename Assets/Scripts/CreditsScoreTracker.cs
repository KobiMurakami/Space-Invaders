using System;
using System.Collections;
using System.Collections.Generic;
using Palmmedia.ReportGenerator.Core.Common;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CreditsScoreTracker : MonoBehaviour
{
    public TextMeshProUGUI ScoreScoreText;
    public TextMeshProUGUI HighScoreScoreText;
    // Start is called before the first frame update
    void Start()
    {
        int highScore = PlayerPrefs.GetInt("HiScore", -1);
        if(highScore == -1) {
            Debug.Log("No high score set yet, defaulting to 0000");
            HighScoreScoreText.text = "0000";
        }
        else {
            Debug.Log("High score detected, setting to " + highScore);
            String highScoreText = highScore.ToString("D4");
            HighScoreScoreText.text = highScoreText;
        }

        int score = PlayerPrefs.GetInt("LastScore", -1);
        if(highScore == -1) {
            Debug.Log("No score detected, defaulting to 0000");
            ScoreScoreText.text = "0000";
        }
        else {
            Debug.Log("Score detected, setting to " + score);
            String scoreText = score.ToString("D4");
            ScoreScoreText.text = scoreText;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
