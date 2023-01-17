using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int lifes;
    private int max_lifes;

    void Start()
    {
        max_lifes = 5;
        lifes = 3;
    }

    public int GetLifes()
    {
        return lifes;
    }

    public void IncreaseLifesByOne()
    {
        if(lifes < max_lifes)
            lifes++;
    }

    public void DiscountLife()
    {
        if (lifes > 0)
        {
            lifes--;
        }
    }
}
