using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSlow : PowerUp
{

    new void Start()
    {
        base.Start();
        score_points = 200;
    }

    public override void Activate(Collider2D collision)
    {
        Ball inGameBall = GameObject.FindWithTag("ball").GetComponent<Ball>();
        inGameBall.SetSpeed(inGameBall.GetSpeed() * 0.85f);
        inGameBall.UpdateColliderRadius();
    }

}