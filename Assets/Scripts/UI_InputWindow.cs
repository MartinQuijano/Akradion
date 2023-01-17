using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_InputWindow : MonoBehaviour
{
    private Button saveButton;
    private Button cancelButton;
    private TMP_InputField inputField;
    public TMPro.TextMeshProUGUI scoreText;

    private HighscoreTable highscoreTable;

    public void Awake()
    {
        saveButton = transform.Find("saveButton").GetComponent<Button>();
        cancelButton = transform.Find("cancelButton").GetComponent<Button>();
        inputField = transform.Find("InputField").GetComponent<TMP_InputField>();
        highscoreTable = new HighscoreTable();
    }

    public void Show()
    {
        gameObject.SetActive(true);
        inputField.text = "Enter player name...";
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void SaveHighscore()
    {
        Hide();
        highscoreTable.AddHighscoreEntry(ScoreManager.score, inputField.text);
    }

    public void CancelHighscore()
    {
        Hide();
    }

    public void SetScoreText(string newScoreText)
    {
        scoreText.text = newScoreText;
    }

}
