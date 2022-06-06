using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankingTable : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    private List<Entry> highscoreEntryList;
    private List<Transform> highscoreEntryTransformList;
    private Text myScoreText;
    private Dictionary<string, int> dictionaryRanking;

    void Awake()
    {
        int myScore = 60;
        GameObject progress;
        GeneralProgress generalProgress;
        progress = GameObject.Find("Progress");
        if (progress != null)
        {
            generalProgress = progress.GetComponent<GeneralProgress>();
            dictionaryRanking = generalProgress.getGradeDictionary();
            myScore = generalProgress.getGradeUser();
        }
        myScoreText = GameObject.Find("myScore").GetComponent<Text>();
        myScoreText.text = "My Score: " + myScore.ToString();

        entryContainer = transform.Find("EntryContainer");
        entryTemplate = entryContainer.Find("EntryTemplate");

        entryTemplate.gameObject.SetActive(false);

        //create the highscoreEntryList from firebase
        highscoreEntryList = new List<Entry>();
        foreach (KeyValuePair<string, int> kvp in dictionaryRanking)
        {
            highscoreEntryList.Add(new Entry { userName = kvp.Key, score = kvp.Value });
        }
        //sorting
        for (int i = 0; i < highscoreEntryList.Count; i++)
        {
            for (int j = i + 1; j < highscoreEntryList.Count; j++)
            {
                if (highscoreEntryList[j].score > highscoreEntryList[i].score)
                {
                    Entry tmp = highscoreEntryList[i];
                    highscoreEntryList[i] = highscoreEntryList[j];
                    highscoreEntryList[j] = tmp;
                }
            }
        }
        //top ten 
        List<Entry> topTen = new List<Entry>();
        int numIterations = Math.Min(10, highscoreEntryList.Count);
        for (int i=0; i< numIterations; i++)
        {
            topTen.Add(new Entry { userName = highscoreEntryList[i].userName, score = highscoreEntryList[i].score } );
        }
        //create the table
        highscoreEntryTransformList = new List<Transform>();
        foreach (Entry scoreEntry in topTen)
        {
            CreateErrorEntryTransform(scoreEntry, entryContainer, highscoreEntryTransformList);
        }
    }

    //create the table
    private void CreateErrorEntryTransform(Entry highscoreEntry, Transform container, List<Transform> transformList)
    {
        float templateHeight = 55f;
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        string rankString = "";
        switch (rank)
        {
            default:
                rankString = rank + "TH"; break;
            case 1: rankString = "1ST"; break;
            case 2: rankString = "2ND"; break;
            case 3: rankString = "3RD"; break;

        }

        entryTransform.Find("rank text").GetComponent<Text>().text = rankString;

        string name = highscoreEntry.userName;
        int score = highscoreEntry.score;

        entryTransform.Find("user name text").GetComponent<Text>().text = name;
        entryTransform.Find("score text").GetComponent<Text>().text = score.ToString();
        entryTransform.Find("background").gameObject.SetActive(rank % 2 == 1);

        switch (rank)
        {
            default:
                entryTransform.Find("trophy").gameObject.SetActive(false); break;
            case 1:
                entryTransform.Find("trophy").GetComponent<Image>().color = new Color32(255, 215, 0, 255); break;
            case 2:
                entryTransform.Find("trophy").GetComponent<Image>().color = new Color32(211, 211, 211, 255); break;
            case 3:
                entryTransform.Find("trophy").GetComponent<Image>().color = new Color32(184, 115, 51, 255); break;
        }

        transformList.Add(entryTransform);
    }

    private class Entry
    {
        public string userName;
        public int score;
    }
}
