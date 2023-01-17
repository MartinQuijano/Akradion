using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpExplosion : PowerUp
{

    new void Start()
    {
        base.Start();
        score_points = 150;
    }

    public override void Activate(Collider2D collision)
    {
        GameObject[] blocksToRandomDestroy = GameObject.FindGameObjectsWithTag("block");
        int amountOfBlocks = blocksToRandomDestroy.Length;
        int indexOfBlockToDestroy;

        for (int i = 0; i < 3; i++)
        {
            indexOfBlockToDestroy = Random.Range(0, amountOfBlocks);
            blocksToRandomDestroy[indexOfBlockToDestroy].GetComponent<Block>().SetActiveToFalse();
        }

    }
}
