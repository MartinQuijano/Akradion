using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static int score;
    private int display_score;

    public TMPro.TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<TMPro.TextMeshProUGUI>();
        score = 0;
        display_score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (display_score < score)
        {
            display_score += 10;
            scoreText.text = "Score: " + display_score;
        }
    }
}
