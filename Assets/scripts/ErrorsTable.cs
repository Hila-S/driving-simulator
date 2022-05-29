using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ErrorsTable : MonoBehaviour
{
    GameObject errorCountingScore;
    ErrorCounting errorCounting;

    private int instructionErrors = 0;
    private int signErrors = 0;
    private int pedestrianErrors = 0;
    private int lightErrors = 0;
    private int speedErrors = 0;
    private int collisionErrors = 0;
    private int laneErrors = 0;

    private Transform entryContainer; 
    private Transform entryTemplate;
    private List<ErrorEntry> errorEntryList;
    private List<Transform> errorEntryTransformList;

    private void Awake()
    {
        errorCountingScore = GameObject.Find("ErrorCountingScore");
        if (errorCountingScore == null)
            Debug.Log("error");
        else
        {
            errorCounting = errorCountingScore.GetComponent<ErrorCounting>();
            instructionErrors = errorCounting.GetInstructionErrors();
            signErrors = errorCounting.GetSignErrors();
            pedestrianErrors = errorCounting.GetPedestrianErrors(); 
            lightErrors = errorCounting.GetLightErrors();
            speedErrors = errorCounting.GetSpeedErrors();
            collisionErrors = errorCounting.GetCollisionErrors();
            laneErrors = errorCounting.GetLaneErrors();
        }   
        entryContainer = transform.Find("ErrorsEntryContainer");
        entryTemplate = entryContainer.Find("ErrorsEntryTemplate");

        entryTemplate.gameObject.SetActive(false);

        errorEntryList = new List<ErrorEntry>()
        {
            new ErrorEntry{errorsNum = instructionErrors},
            new ErrorEntry{errorsNum = signErrors},
            new ErrorEntry{errorsNum = pedestrianErrors},
            new ErrorEntry{errorsNum = lightErrors},
            new ErrorEntry{errorsNum = speedErrors},
            new ErrorEntry{errorsNum = collisionErrors},
            new ErrorEntry{errorsNum = laneErrors}
        };

        errorEntryTransformList = new List<Transform>();
        foreach(ErrorEntry errorEntry in errorEntryList)
        {
            CreateErrorEntryTransform(errorEntry, entryContainer, errorEntryTransformList);
        }

        int scoreGame = Math.Max(0, 100 - instructionErrors - 2 * signErrors - 5 * pedestrianErrors 
            - 4 * lightErrors - 2 * speedErrors - 2 * collisionErrors - 3 * laneErrors);
        string highscoreString = "80"; // firebase
        int highscore = 0;
        Int32.TryParse(highscoreString, out highscore);
        if (scoreGame > highscore)
        {
            // firebase
        }

    }

    private void CreateErrorEntryTransform(ErrorEntry errorEntry, Transform container, List<Transform> transformList) {
        float templateHeight = 70f;
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        int category = transformList.Count + 1;
        string categoryString = "";
        switch (category)
        {
            case 1: categoryString = "Following directions"; break;
            case 2: categoryString = "Following traffic signs"; break;
            case 3: categoryString = "Attention to pedestrians"; break;
            case 4: categoryString = "Following traffic lights"; break;
            case 5: categoryString = "Speed limit"; break;
            case 6: categoryString = "Collisions with sidewalk"; break;
            case 7: categoryString = "Following lanes correctly"; break;

        }

        entryTransform.Find("error type text").GetComponent<Text>().text = categoryString;

        int errorsNum = errorEntry.errorsNum;
        entryTransform.Find("num of errors text").GetComponent<Text>().text = errorsNum.ToString();
        entryTransform.Find("background").gameObject.SetActive(category % 2 == 1);
        transformList.Add(entryTransform);
    }

    private class ErrorEntry
    {
        public int errorsNum;
    }
}
