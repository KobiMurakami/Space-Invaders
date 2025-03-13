using System;
using System.Collections;
using System.Collections.Generic;
using Palmmedia.ReportGenerator.Core.Common;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{
    public void OnButtonClick()
    {
        Debug.Log("Button Click Detected");
        SceneManager.LoadScene("Game");
    }
}
