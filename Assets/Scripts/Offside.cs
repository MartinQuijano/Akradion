using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Offside : MonoBehaviour
{
    public GameManager gameManager;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.transform.name == "ball")
        {
            //gameManager.OffsideHandler();
        }
    }
}
