using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBonusPoints : PowerUp
{
    public GameObject bonusPointEffect;

    new void Start()
    {
        base.Start();
    }

    public override void Activate(Collider2D collision)
    {
        Instantiate(bonusPointEffect, new Vector2(-45, 280), Quaternion.identity);
    }

}