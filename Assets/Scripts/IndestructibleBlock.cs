using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndestructibleBlock : Block
{
    public AudioClip bounce_audio;
    protected void Start()
    {
        isActive = true;
        health = 100;
        score_points = 0;
    }

    
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
    }

    protected override void OnCollisionEnter2D(Collision2D colInfo)
    {
    }

    public override void SetActiveToFalse()
    {

    }
}
