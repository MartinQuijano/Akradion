using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int currentLevel;
    public LevelManager lvlmanager;
    public Player player;

    public GameObject gameOverMenu;
    public GameObject victoryMenu;
    private bool running;
    private bool playerAlive;

    protected AudioSource audioSrc;
    public AudioClip offsideClip;

    public UI_InputWindow inputWindow;

    private void Start()
    {
       // PlayerPrefs.DeleteAll();
        gameOverMenu.SetActive(false);
        victoryMenu.SetActive(false);
        currentLevel = 1;
        lvlmanager.BuildLevel(currentLevel); 
        audioSrc = GetComponent<AudioSource>();
        running = false;
        playerAlive = true;
    }

    private void Update()
    {
        running = lvlmanager.GetIsCurrentLvlBuilt();

        if (running && playerAlive)
        {
            if (lvlmanager.GetBallsCount() == 0)
            {
                audioSrc.PlayOneShot(offsideClip, 0.7f);
                player.DiscountLife();
                if (player.GetLifes() > 0)
                {
                    Racket racket = GameObject.FindWithTag("racket").GetComponent<Racket>();
                    racket.Shrink();
                    lvlmanager.SpawnNewBall();
                    lvlmanager.ClearPowerUps();
                }
                else
                {
                    lvlmanager.ClearLevel();
                    gameOverMenu.SetActive(true);
                    playerAlive = false;
                    running = false;
                    inputWindow.Show();
                    inputWindow.GetComponent<UI_InputWindow>().SetScoreText(ScoreManager.score.ToString());
                }

            }


            if (lvlmanager.GetBlockCount() <= 0 && running)
            {
                currentLevel++;
                if (lvlmanager.MoreLevels())
                {
                    lvlmanager.ClearLevel();
                    lvlmanager.ClearPowerUps();
                    lvlmanager.BuildLevel(currentLevel);
                }
                else
                {
                    running = false;
                    lvlmanager.ClearLevel();
                    lvlmanager.ClearPowerUps();
                    victoryMenu.SetActive(true);
                    playerAlive = false;
                    inputWindow.Show();
                    inputWindow.GetComponent<UI_InputWindow>().SetScoreText(ScoreManager.score.ToString());
                }
            }
        }

    }

    public int GetCurrentLevel()
    {
        return currentLevel;
    }
}
