using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : MonoBehaviour
{
    private float speed;
    private bool isActive = true;
    protected int score_points;

    // Start is called before the first frame update
    public void Start()
    {
        speed = -65.0f;
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
    }

    public abstract void Activate(Collider2D collision);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "OffsideZone")
        {
            isActive = false;
        }
        else if (collision.gameObject.name == "racket")
        {
            GameObject.Find("ui_lifes_powerupacc").GetComponent<LifesManager>().IncreasePowerUpsActive();
            ScoreManager.score += score_points;
            Activate(collision);
            isActive = false;
        }
    }

    public void Remove()
    {
        Destroy(gameObject);
    }

    public bool IsActive()
    {
        return isActive;
    }
}
