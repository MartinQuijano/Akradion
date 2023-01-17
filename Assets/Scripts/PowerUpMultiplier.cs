using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class PowerUpMultiplier : PowerUp
{
    public GameObject ball;

    new void Start()
    {
        base.Start();
        score_points = 150;
    }

    public override void Activate(Collider2D collision)
    {
        Ball originalBall = GameObject.FindWithTag("ball").GetComponent<Ball>();
        Vector2 positionOfBall = originalBall.transform.position;
        Vector2 velocityOfBall = originalBall.GetComponent<Rigidbody2D>().velocity;

        float speed = originalBall.GetSpeed();

        Vector2 velocity1 = new Vector2(velocityOfBall.x + 40, velocityOfBall.y);
        Vector2 velocity2 = new Vector2(velocityOfBall.x - 40, velocityOfBall.y);

        GameObject ball1 = Instantiate(ball, positionOfBall, Quaternion.identity);
        GameObject ball2 = Instantiate(ball, positionOfBall, Quaternion.identity);

        LevelManager lvlManager = GameObject.FindWithTag("lvlManager").GetComponent<LevelManager>();
        lvlManager.DisablePowerUps();
        lvlManager.AddBall(ball1);
        lvlManager.AddBall(ball2);

        Ball ball1Ball = ball1.GetComponent<Ball>();
        Ball ball2Ball = ball2.GetComponent<Ball>();

        ball1Ball.SetSpeed(speed);
        ball1Ball.SetVelocity(velocity1);
        ball2Ball.SetSpeed(speed);
        ball2Ball.SetVelocity(velocity2);

    }
}
