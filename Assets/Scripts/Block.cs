using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Block : MonoBehaviour
{
    protected bool isActive;
    protected int health;
    protected int score_points;

    public string[] sprites;

    protected abstract void OnCollisionEnter2D(Collision2D colInfo);

    protected abstract void OnTriggerEnter2D(Collider2D collision);

    public void Remove()
    {
        Destroy(gameObject);
    }

    public bool IsActive()
    {
        return isActive;
    }

    public virtual void SetActiveToFalse()
    {       
        isActive = false;
    }
}
