using System;
using System.Collections;
using System.Collections.Generic;
using Palmmedia.ReportGenerator.Core.Common;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ScoreTracker : MonoBehaviour
{
    public TextMeshProUGUI CurrentScoreText;
    public TextMeshProUGUI HiScoreScoreText;

    // Start is called before the first frame update
    void Start()
    {
        Enemy.OnEnemyDied += EnemyOnOnEnemyDied;
        Player.OnPlayerDied += PlayerOnOnPlayerDied;
        int highScore = PlayerPrefs.GetInt("HiScore", -1);
        if(highScore == -1) {
            Debug.Log("No high score set yet, defaulting to 0000");
            HiScoreScoreText.text = "0000";
        }
        else {
            Debug.Log("High score detected, setting to " + highScore);
            String scoreText = highScore.ToString("D4");
            HiScoreScoreText.text = scoreText;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void EnemyOnOnEnemyDied(String type) {
        String scoreText = CurrentScoreText.text;
        int oldScore = Int32.Parse(scoreText);

        int score = 0;
        if(type.Equals("red")) {
            score = oldScore + 20;
        }
        if(type.Equals("blue")) {
            score = oldScore + 10;
        }
        if(type.Equals("green")) {
            score = oldScore + 5;
        }
        if(type.Equals("yellow")) {
            score = oldScore + 50;
        }


        String newScoreText = "";
        Debug.Log("New Score Recieved: " + score);

        newScoreText = score.ToString("D4");
        CurrentScoreText.text = newScoreText;
    }

    void PlayerOnOnPlayerDied() {
        Debug.Log("You Lost!");
        String scoreText = CurrentScoreText.text;
        Debug.Log("Fetching Score to Compare: " + scoreText);
        int score = Int32.Parse(scoreText);
        int highScore = PlayerPrefs.GetInt("HiScore", -1);
        Debug.Log("Comparing: " + score + " vs " + highScore);
        if(score > highScore || highScore == -1) {
            PlayerPrefs.SetInt("HiScore", score);
            PlayerPrefs.Save();
            Debug.Log("New High Score Set: " + score);
        }
    }
}
