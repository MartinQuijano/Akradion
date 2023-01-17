using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RandomPowerUpDrop : MonoBehaviour
{
    public List<GameObject> powerUps;
    
    private int[] table =
    {       
        22, // Expand
        17, // Slow
        16, // Multiply
        15, // Empower
        14, // Bonus points
        11, // Explosion
        5  // Extra life
    };

    public int total;
    public int randomNumber;

    public bool IsBlockDropping()
    {
        int randomDropNumber = Random.Range(0, 100);
        if (randomDropNumber <= 35)
            return true;
        else
            return false;
    }


    public GameObject GetRandomPowerUp()
    {
        total = 0;
        GameObject powerUpToDrop = null;

        foreach (var item in table)
        {
            total += item;
        }

        randomNumber = Random.Range(0, total);

        bool isDropFound = false;
        int index = 0;

        while (!isDropFound && index < table.Length)
        {
            
            if (randomNumber <= table[index])
            {
                powerUpToDrop = powerUps.ElementAt(index);
                isDropFound = true;
            }
            else
            {
                randomNumber -= table[index];
            }
            index++;
        }

        return powerUpToDrop;
    }

}
