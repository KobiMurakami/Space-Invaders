using System;
using System.Collections;
using System.Collections.Generic;
using Palmmedia.ReportGenerator.Core.Common;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameWinLoss : MonoBehaviour
{
    public int numberEnemiesKilled;
    public float timeSinceEnd;
    public Boolean playerDead = false;

    // Start is called before the first frame update
    void Start()
    {
        Player.OnPlayerDied += PlayerOnOnPlayerDied;
        Enemy.OnEnemyDied += EnemyOnOnEnemyDied;
        numberEnemiesKilled = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if((playerDead && Time.time - timeSinceEnd > 1) || (numberEnemiesKilled >= 8 && Time.time - timeSinceEnd > 1)) {
            SceneManager.LoadScene("Credits");
        }
    }

    void EnemyOnOnEnemyDied(String type) {
        numberEnemiesKilled += 1;
        timeSinceEnd = Time.time;
    }

    void PlayerOnOnPlayerDied() {
        Debug.Log("You Lost!");
        playerDead = true;
        timeSinceEnd = Time.time;
    }
}
