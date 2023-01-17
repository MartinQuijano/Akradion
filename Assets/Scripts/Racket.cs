using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Racket : MonoBehaviour
{
    public float speed = 150;
    protected AudioSource audioSrc;
    public LevelManager lvlmng;

    private int expansionLevel;
    private int max_expand;

    private void Start()
    {
        expansionLevel = 1;
        max_expand = 3;
        audioSrc = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");

        GetComponent<Rigidbody2D>().velocity = Vector2.right * h * speed;
      
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "ball")
            audioSrc.Play();
    }

    public void Expand()
    {
        
        if (expansionLevel < max_expand)
        {
            expansionLevel++;
            if (expansionLevel == 2)
            {
                GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/racket_2_firstextended");
                gameObject.GetComponent<BoxCollider2D>().size = new Vector2(40.5f, 7.6f);

            } else if (expansionLevel == 3)
            {
                GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/racket_2_extended");
                gameObject.GetComponent<BoxCollider2D>().size = new Vector2(54.5f, 7.6f);
            }
            
        }
    }

    public void Shrink()
    {
        expansionLevel = 1;
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/racket_2");
        gameObject.GetComponent<BoxCollider2D>().size = new Vector2(30.5f, 7.6f);
    }

}