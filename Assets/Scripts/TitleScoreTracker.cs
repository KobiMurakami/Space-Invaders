using System;
using System.Collections;
using System.Collections.Generic;
using Palmmedia.ReportGenerator.Core.Common;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TitleScoreTracker : MonoBehaviour
{
    public TextMeshProUGUI HiScoreScoreText;
    // Start is called before the first frame update
    void Start()
    {
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
}
