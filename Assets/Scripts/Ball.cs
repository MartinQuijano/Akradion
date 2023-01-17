using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 120.0f;
    public bool isActive;
    public bool isPaused;
    private int damage;
    private Rigidbody2D myRdbd;

    public string[] sprites;

    void Awake()
    {
        myRdbd = GetComponent<Rigidbody2D>();
        isActive = true;
        isPaused = false;
        damage = 1;
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Launch();

        }

        if (transform.position.x < -103 || transform.position.x > 104)
        {
            isActive = false;
        }
            
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "OffsideZone")
        {
            isActive = false;
        }
        else if (col.gameObject.name == "racket")
        {
            Collider2D collider = col.collider;

            // Get contact point
            Vector2 contactPoint = col.GetContact(0).point;

            // Get center of racket
            Vector2 racket_center = collider.bounds.center;

            if ((contactPoint.y - 3.8f) > racket_center.y)
            {
                // Calculate hit factor
                float x = HitFactor(transform.position, col.transform.position, col.collider.bounds.size.x);

                // Calculate direction, set length to 1
                Vector2 dir = new Vector2(x, 1).normalized;
                dir.y = 1; // establecido para que no se reduzca la velocidad de y al contacto con racket

                // Set Velocity with dir * speed. With speed increased by 0.25%
                speed = speed + (speed * 0.025f);
                GetComponent<Rigidbody2D>().velocity = dir * speed;

                UpdateColliderRadius();
            }

        }

        if (myRdbd.velocity.x > speed)
        {
            myRdbd.velocity = new Vector2(speed, myRdbd.velocity.y);
        }

    }

    public void UpdateColliderRadius()
    {
        CircleCollider2D[] myColliders = GetComponents<CircleCollider2D>();
        myColliders[0].radius = -0.5f + (speed * 0.05f);
    }

    float HitFactor(Vector2 ballPos, Vector2 racketPos, float racketWidth)
    {
        float returnValue;
        // 1  -0.5  0  0.5   1  <- x value
        // ===================  <- racket

        
        if ((ballPos.x - racketPos.x) < 0)
            returnValue = ((ballPos.x - racketPos.x) / racketWidth) - 0.25f;
        else
            returnValue = ((ballPos.x - racketPos.x) / racketWidth) + 0.25f;
        return returnValue;
    }

    public void Launch()
    {
        if (isPaused != true)
        {
            float random_xdir = Random.Range(-0.5f, 0.5f);
            isPaused = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(random_xdir * speed, speed);
        }
    }

    public void Stop()
    {
        if (isPaused != false)
        {
            isPaused = false;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }

    public void Restart()
    {
        Stop();
        transform.position = new Vector2(0, -87);
    }

    public bool IsActive()
    {
        return isActive;
    }

    public void Remove()
    {
        Destroy(gameObject);
    }

    public int GetDmg()
    {
        return damage;
    }

    public void SetDmg(int dmg)
    {
        damage = dmg;
    }

    public void SetSpriteToRender(int index)
    {
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/" + sprites[index]);
    }

    public float GetSpeed()
    {
        return speed;
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
        UpdateVelocity();
    }

    private void UpdateVelocity()
    {
        int factor = 1;
        if (GetComponent<Rigidbody2D>().velocity.y < 0)
            factor = -1;
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, speed * factor);
    }

    public void SetVelocity(Vector2 newVelocity)
    {
        GetComponent<Rigidbody2D>().velocity = newVelocity;
    }

    public void SetDirection(Vector2 newDir)
    {
        GetComponent<Rigidbody2D>().velocity = newDir * speed;
    }
}
