using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class scoreEndGame : MonoBehaviour
{
    // private ErrorCounting errorCounting;
    GameObject errorCountingScore;
    ErrorCounting errorCounting;
    public Text text;
    public GameObject scoreCanvas;

    void Start()
    {
        errorCountingScore = GameObject.Find("ErrorCountingScore");
        if (errorCountingScore == null)
            Debug.Log("error");
        else
        {
            errorCounting = errorCountingScore.GetComponent<ErrorCounting>();
            int numErrorDirections = errorCounting.GetErrorDirections();
            int numCollisions = errorCounting.GetNumCollisions();
            int numTrafficSign = errorCounting.GetNumErrorTrafficSign();
            int numTrafficLaws = errorCounting.GetNumErrorTrafficLaws();
            //Debug.Log("GetErrorDirections:" + numErrorDirections);
            string newString = "Error Directions: " + numErrorDirections + "\nCollisions: " + numCollisions
                + "\nError Traffic Sign: " + numTrafficSign + "\nError Traffic Laws: " + numTrafficLaws;
            text.text = newString;
            scoreCanvas.SetActive(true);
        }
    }
}
    