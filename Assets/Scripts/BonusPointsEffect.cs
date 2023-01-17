using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using UnityEngine;

public class BonusPointsEffect : MonoBehaviour
{
    private int duration = 3;
    public TMPro.TextMeshProUGUI bonusPoints;
    private string textToDisplay = "+1000";

    void Start()
    {
        transform.SetParent(GameObject.Find("Panel").transform, false);

        bonusPoints.text = textToDisplay;
        StartCoroutine(FadeTo(0.0f, 2.0f));     
    }

    IEnumerator FadeTo(float aValue, float aTime)
    {
        ScoreManager.score += 1000;
        float alpha = bonusPoints.color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            UnityEngine.Debug.Log(t);
            transform.position = new Vector2(transform.position.x + 0.2f, transform.position.y);
            Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha, aValue, t));
            bonusPoints.color = newColor;
            yield return null;
        }
        BonusPointsDestroy();
       
    }

    private void BonusPointsDestroy()
    {
        
       Destroy(gameObject);
    }
}
