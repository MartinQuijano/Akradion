using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpLife : PowerUp
{

    new void Start()
    {
        base.Start();
        score_points = 300;
    }

    public override void Activate(Collider2D collision)
    {
        Player player = GameObject.FindWithTag("player").GetComponent<Player>();
        player.IncreaseLifesByOne();
    }
}
