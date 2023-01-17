using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class GenericBlock : Block
{
    protected SpriteRenderer mySpriteRenderer;
    public AudioClip bounce_sound;


    // Start is called before the first frame update
    protected void Awake()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        isActive = true;
        health = 1;
        score_points = 50;
    }

    protected override void OnCollisionEnter2D(Collision2D colInfo)
    {
        if (colInfo.collider.tag == "ball")
        {
            AudioSource.PlayClipAtPoint(bounce_sound, new Vector3(0, 0, 0));
            Ball ball = colInfo.gameObject.GetComponent<Ball>();
            health = health - ball.GetDmg();
            if (health <= 0)
            {
                ScoreManager.score += score_points;
                isActive = false;
            }
            else
            {
                if (health == 2)
                    mySpriteRenderer.sprite = Resources.Load<Sprite>("Sprites/" + sprites[1]);
                else if (health == 1)
                    mySpriteRenderer.sprite = Resources.Load<Sprite>("Sprites/" + sprites[2]);
                ScoreManager.score += 10;
            }
        }
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ball")
        {
            isActive = false;
        }
    }




}