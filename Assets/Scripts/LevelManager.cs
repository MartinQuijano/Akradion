using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LevelManager : MonoBehaviour
{
    private int[,] blockMap;
    private string[] levelPaths;

    private int inicioX;
    private int inicioY;
    private int current_level;

    public GameObject racket;

    public GameObject block_red;
    public GameObject block_blue;
    public GameObject block_yellow;
    public GameObject block_pink;
    public GameObject block_green;
    public GameObject block_grey;
    public GameObject block_gold;
    public GameObject block_hmov_gold;
    public GameObject block_hmov_grey;
    public GameObject ball;
    public GameObject powerup_placeholder;

    private LinkedList<GameObject> blocks;
    private LinkedList<GameObject> extras;
    private LinkedList<GameObject> blocks_toremove;

    private LinkedList<GameObject> balls;
    private LinkedList<GameObject> balls_toremove;

    private LinkedList<GameObject> powerups;
    private LinkedList<GameObject> powerups_toremove;

    public RandomPowerUpDrop randomPowerUpDrop;
    public bool arePowerUpsEnabled;

    private bool isCurrentLvlBuilt = false;

    void Start()
    {
        extras = new LinkedList<GameObject>();
        blocks = new LinkedList<GameObject>();
        blocks_toremove = new LinkedList<GameObject>();
        balls = new LinkedList<GameObject>();
        balls_toremove = new LinkedList<GameObject>();
        powerups = new LinkedList<GameObject>();
        powerups_toremove = new LinkedList<GameObject>();

        arePowerUpsEnabled = true;

        inicioX = -96;
        inicioY = 112;

        levelPaths = new string[24];
        levelPaths[0] = "Assets/Resources/Levels/level1.txt";
        levelPaths[1] = "Assets/Resources/Levels/level2.txt";
        levelPaths[2] = "Assets/Resources/Levels/level3.txt";
        levelPaths[3] = "Assets/Resources/Levels/level4.txt";
        levelPaths[4] = "Assets/Resources/Levels/level5.txt";
        levelPaths[5] = "Assets/Resources/Levels/level6.txt";
        levelPaths[6] = "Assets/Resources/Levels/level7.txt";
        levelPaths[7] = "Assets/Resources/Levels/level8.txt";
        levelPaths[8] = "Assets/Resources/Levels/level9.txt";
        levelPaths[9] = "Assets/Resources/Levels/level10.txt";
        levelPaths[10] = "Assets/Resources/Levels/level11.txt";
        levelPaths[11] = "Assets/Resources/Levels/level12.txt";
        levelPaths[12] = "Assets/Resources/Levels/level13.txt";
        levelPaths[13] = "Assets/Resources/Levels/level14.txt";
        levelPaths[14] = "Assets/Resources/Levels/level15.txt";
        levelPaths[15] = "Assets/Resources/Levels/level16.txt";
        levelPaths[16] = "Assets/Resources/Levels/level17.txt";
        levelPaths[17] = "Assets/Resources/Levels/level18.txt";
        levelPaths[18] = "Assets/Resources/Levels/level19.txt";
        levelPaths[19] = "Assets/Resources/Levels/level20.txt";
        levelPaths[20] = "Assets/Resources/Levels/level21.txt";
        levelPaths[21] = "Assets/Resources/Levels/level22.txt";
        levelPaths[22] = "Assets/Resources/Levels/level23.txt";
        levelPaths[23] = "Assets/Resources/Levels/level24.txt";
    }

    public void BuildLevel(int lvlIndex)
    {
        isCurrentLvlBuilt = false;
        balls.AddFirst(Instantiate(ball, new Vector2(0, -87), Quaternion.identity));
        current_level = lvlIndex;
        lvlIndex--;
        blockMap = LoadLevel(lvlIndex);
        GenerateLevel();
        isCurrentLvlBuilt = true;
    }

    void Update()
    {
        if (GetBallsCount() == 1 && powerups.Count == 0)
        {
            arePowerUpsEnabled = true;
        }

        foreach (GameObject blockObj in blocks)
        {
            Block blk = blockObj.GetComponent<Block>();
            if (!blk.IsActive())
            {
                if (arePowerUpsEnabled)
                {
                    if (randomPowerUpDrop.IsBlockDropping())
                    {
                        arePowerUpsEnabled = false;
                        powerups.AddFirst(Instantiate(randomPowerUpDrop.GetRandomPowerUp(), blk.transform.position, Quaternion.identity));
                    }
                    
                }

                blocks_toremove.AddFirst(blockObj);
            }
        }

        foreach (GameObject blockObj in blocks_toremove)
        {
            blocks.Remove(blockObj);
            blockObj.GetComponent<Block>().Remove();
        }
        blocks_toremove.Clear();

        foreach (GameObject ballObj in balls)
        {
            Ball blk = ballObj.GetComponent<Ball>();
            if (!blk.IsActive())
            {
                balls_toremove.AddFirst(ballObj);
            }
        }

        foreach (GameObject ballObj in balls_toremove)
        {
            balls.Remove(ballObj);
            ballObj.GetComponent<Ball>().Remove();
        }
        balls_toremove.Clear();

        foreach (GameObject powerupObj in powerups)
        {
            PowerUp blk = powerupObj.GetComponent<PowerUp>();
            if (!blk.IsActive())
            {
                powerups_toremove.AddFirst(powerupObj);
            }
        }

        foreach (GameObject powerupObj in powerups_toremove)
        {
            powerups.Remove(powerupObj);
            powerupObj.GetComponent<PowerUp>().Remove();
        }
        powerups_toremove.Clear();

    }

    int[,] LoadLevel(int lvlIndex)
    {
        string input = File.ReadAllText(levelPaths[lvlIndex]);
        int i = 0;
        // int j = 0;
        int j;
        int[,] result = new int[17, 13];
        foreach (var row in input.Split('\n'))
        {
            j = 0;
            foreach (var col in row.Trim().Split(','))
            {
                result[i, j] = int.Parse(col.Trim());
                j++;
            }
            i++;
        }
        return result;
    }

    void GenerateLevel()
    {
        for (int i = 0; i < blockMap.GetLength(0); i++)
        {
            for (int j = 0; j < blockMap.GetLength(1); j++)
            {
                int valueOfBlock = blockMap[i, j];
                switch (valueOfBlock)
                {
                    case 0:
                        break;
                    case 1:
                        blocks.AddFirst(Instantiate(block_red, new Vector2(inicioX + (j * 16), inicioY - (i * 8)), Quaternion.identity));
                        break;
                    case 2:
                        blocks.AddFirst(Instantiate(block_green, new Vector2(inicioX + (j * 16), inicioY - (i * 8)), Quaternion.identity));
                        break;
                    case 3:
                        blocks.AddFirst(Instantiate(block_pink, new Vector2(inicioX + (j * 16), inicioY - (i * 8)), Quaternion.identity));
                        break;
                    case 4:
                        blocks.AddFirst(Instantiate(block_yellow, new Vector2(inicioX + (j * 16), inicioY - (i * 8)), Quaternion.identity));
                        break;
                    case 5:
                        blocks.AddFirst(Instantiate(block_blue, new Vector2(inicioX + (j * 16), inicioY - (i * 8)), Quaternion.identity));
                        break;
                    case 6:
                        blocks.AddFirst(Instantiate(block_grey, new Vector2(inicioX + (j * 16), inicioY - (i * 8)), Quaternion.identity));
                        break;
                    case 7:
                        blocks.AddFirst(Instantiate(block_hmov_grey, new Vector2(inicioX + (j * 16), inicioY - (i * 8)), Quaternion.identity));
                        break;
                    case 8:
                        extras.AddFirst(Instantiate(block_gold, new Vector2(inicioX + (j * 16), inicioY - (i * 8)), Quaternion.identity));
                        break;
                    case 9:
                        extras.AddFirst(Instantiate(block_hmov_gold, new Vector2(inicioX + (j * 16), inicioY - (i * 8)), Quaternion.identity));
                        break;
                }
            }
        }
    }

    public int GetBlockCount()
    {
        return blocks.Count;
    }

    public int GetBallsCount()
    {
        return balls.Count;
    }

    public void ClearBalls()
    {
        foreach (GameObject ballObj in balls)
        {
            Ball blk = ballObj.GetComponent<Ball>();
            balls_toremove.AddFirst(ballObj);
        }

        foreach (GameObject ballObj in balls_toremove)
        {
            ballObj.GetComponent<Ball>().Remove();
            balls.Remove(ballObj);
        }
        balls_toremove.Clear();
    }

    public void ClearLevel()
    {
        ClearBalls();
        foreach (GameObject blockObj in blocks)
        {
            blocks_toremove.AddFirst(blockObj);
        }

        foreach (GameObject blockObj in blocks_toremove)
        {
            blocks.Remove(blockObj);
            blockObj.GetComponent<Block>().Remove();
        }

        blocks_toremove.Clear();

        foreach (GameObject blockObj in extras)
        {
            blocks_toremove.AddFirst(blockObj);
        }

        foreach (GameObject blockObj in blocks_toremove)
        {
            extras.Remove(blockObj);
            blockObj.GetComponent<Block>().Remove();
        }

        blocks_toremove.Clear();

        ClearPowerUps();
        racket.GetComponent<Racket>().Shrink();
    }

    public void ClearPowerUps()
    {
        foreach (GameObject powerupObj in powerups)
        {
            powerups_toremove.AddFirst(powerupObj);
        }

        foreach (GameObject powerupObj in powerups_toremove)
        {
            powerups.Remove(powerupObj);
            powerupObj.GetComponent<PowerUp>().Remove();
        }
        powerups_toremove.Clear();
    }

    public bool MoreLevels()
    {
        return current_level < levelPaths.Length;
    }

    public void SpawnNewBall()
    {
        balls.AddFirst(Instantiate(ball, new Vector2(0, -87), Quaternion.identity));
    }

    public void AddBall(GameObject newBall)
    {
        balls.AddFirst(newBall);
    }

    public bool GetIsCurrentLvlBuilt()
    {
        return isCurrentLvlBuilt;
    }

    public void EnablePowerUps()
    {
        arePowerUpsEnabled = true;
    }

    public void DisablePowerUps()
    {
        arePowerUpsEnabled = false;
    }
}
