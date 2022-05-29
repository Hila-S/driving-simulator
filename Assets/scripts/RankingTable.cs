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

    void Awake()
    {
        int myScore = 85;
        myScoreText = GameObject.Find("myScore").GetComponent<Text>();
        myScoreText.text = "My Score: " + myScore.ToString();

        entryContainer = transform.Find("EntryContainer");
        entryTemplate = entryContainer.Find("EntryTemplate");

        entryTemplate.gameObject.SetActive(false);

        highscoreEntryList = new List<Entry>()
        {
            new Entry{userName = "a", score = 100},
            new Entry{userName = "b", score = 90},
            new Entry{userName = "c", score = 80},
            new Entry{userName = "d", score = 70},
            new Entry{userName = "e", score = 60},
            new Entry{userName = "f", score = 50},
            new Entry{userName = "g", score = 40},
            new Entry{userName = "h", score = 30},
            new Entry{userName = "i", score = 50},
            new Entry{userName = "j", score = 100},
        };

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

        highscoreEntryTransformList = new List<Transform>();
        foreach (Entry scoreEntry in highscoreEntryList)
        {
            CreateErrorEntryTransform(scoreEntry, entryContainer, highscoreEntryTransformList);
        }
    }

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
