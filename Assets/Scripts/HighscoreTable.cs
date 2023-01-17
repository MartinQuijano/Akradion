using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class HighscoreTable : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    private List<Transform> highscoreEntryTransformList;

    private void Awake()
    {
        entryContainer = transform.Find("highscoreEntryContainer");
        entryTemplate = entryContainer.Find("highscoreEntryTemplate");

        entryTemplate.gameObject.SetActive(false);

        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        if (highscores == null)
            highscores = InitializeHighscores();

        jsonString = PlayerPrefs.GetString("highscoreTable");
        highscores = JsonUtility.FromJson<Highscores>(jsonString);


        for (int i = 0; i < highscores.highscoreEntryList.Count; i++)
        {
            for (int j = i + 1; j < highscores.highscoreEntryList.Count; j++)
            {
                if (highscores.highscoreEntryList[j].score > highscores.highscoreEntryList[i].score)
                {
                    HighscoreEntry tmp = highscores.highscoreEntryList[i];
                    highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
                    highscores.highscoreEntryList[j] = tmp;
                }
            }
        }

        highscoreEntryTransformList = new List<Transform>();

        foreach (HighscoreEntry highscoreEntry in highscores.highscoreEntryList)
        {
            CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
        }
    }

    private Highscores InitializeHighscores()
    {
        Highscores highscores = new Highscores();
        highscores.highscoreEntryList = new List<HighscoreEntry>();

        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
        return highscores;
    }

    public void AddHighscoreEntry(int score, string playerName)
    {
        HighscoreEntry highscoreEntry = new HighscoreEntry { score = score, playerName = playerName };

        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        if (highscores == null)
            highscores = InitializeHighscores();

        highscores.highscoreEntryList.Add(highscoreEntry);

        if (ThereAreMoreThanTenEntries(highscores))
        {
            RemoveEntryWithLessScore(highscores);
        }

        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
    }

    private bool ThereAreMoreThanTenEntries(Highscores highscores)
    {
        if (highscores.highscoreEntryList.Count > 10)
            return true;
        else
            return false;
    }

    private void RemoveEntryWithLessScore(Highscores highscores)
    {
        for (int i = 0; i < highscores.highscoreEntryList.Count; i++)
        {
            for (int j = i + 1; j < highscores.highscoreEntryList.Count; j++)
            {
                if (highscores.highscoreEntryList[j].score > highscores.highscoreEntryList[i].score)
                {
                    HighscoreEntry tmp = highscores.highscoreEntryList[i];
                    highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
                    highscores.highscoreEntryList[j] = tmp;
                }
            }
        }

        highscores.highscoreEntryList.RemoveAt(10);
    }

    private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList)
    {
        float templateHeight = 30f;
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        int score = highscoreEntry.score;
        entryTransform.Find("scoreText").GetComponent<TMPro.TextMeshProUGUI>().text = score.ToString();

        string name = highscoreEntry.playerName;
        entryTransform.Find("nameText").GetComponent<TMPro.TextMeshProUGUI>().text = name;

        transformList.Add(entryTransform);
    }
}
