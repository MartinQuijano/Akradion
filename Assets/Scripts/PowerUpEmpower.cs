using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpEmpower : PowerUp
{
    public GameObject ballEmpBuff;

    new void Start()
    {
        base.Start();
        score_points = 200;
    }

    public override void Activate(Collider2D collision)
    {
        Instantiate(ballEmpBuff, new Vector2(0, 0), Quaternion.identity);
    }

}
