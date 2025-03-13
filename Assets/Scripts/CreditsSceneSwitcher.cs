using System;
using System.Collections;
using System.Collections.Generic;
using Palmmedia.ReportGenerator.Core.Common;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreditsSceneSwitcher : MonoBehaviour
{
    public float timeSinceCreditsStart;
    // Start is called before the first frame update
    void Start()
    {
        timeSinceCreditsStart = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - timeSinceCreditsStart >= 6) {
            SceneManager.LoadScene("Title");
        }
    }
}
