using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpExpand : PowerUp
{
    new void Start()
    {
        base.Start();
        score_points = 150;
    }

    public override void Activate(Collider2D collision)
    {
        Racket racket = GameObject.FindWithTag("racket").GetComponent<Racket>();
        racket.Expand();
    }
}
