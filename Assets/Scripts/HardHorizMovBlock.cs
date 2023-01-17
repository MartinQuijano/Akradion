using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardHorizMovBlock : Block
{
    protected SpriteRenderer mySpriteRenderer;
    public AudioClip bounce_sound;
    private int direction;
    private int speed;

    // Start is called before the first frame update
    protected void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        isActive = true;
        health = 3;
        score_points = 100;
        int randomNumber = Random.Range(0, 1);
        if (randomNumber == 0)
            direction = 1;
        else 
            direction = -1;
        speed = 40;
    }

    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(direction, 0) * speed;
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
                ScoreManager.score += 50;
            }
        }
        else if(colInfo.collider.tag == "wall" || colInfo.collider.tag == "block")
        {
            direction *= -1;
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
