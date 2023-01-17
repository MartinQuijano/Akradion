using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    public string[] backgrounds;
    private GameManager gameManager;
    protected SpriteRenderer mySpriteRenderer;

    private void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        if(gameManager.GetCurrentLevel() < 9)
            mySpriteRenderer.sprite = Resources.Load<Sprite>("Sprites/" + backgrounds[0]);
        else if(gameManager.GetCurrentLevel() < 17)
            mySpriteRenderer.sprite = Resources.Load<Sprite>("Sprites/" + backgrounds[1]);
        else if (gameManager.GetCurrentLevel() < 24)
            mySpriteRenderer.sprite = Resources.Load<Sprite>("Sprites/" + backgrounds[2]);
    }
}
