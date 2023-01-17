using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallEmpowerBuff : MonoBehaviour
{
    private int duration = 4;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("ball"))
        {
            CircleCollider2D[] myColliders = obj.GetComponents<CircleCollider2D>();
           
            myColliders[0].enabled = true;
            obj.GetComponent<Ball>().SetSpriteToRender(1);
        }
        StartCoroutine(BallEmpowerBuffTimer());
    }

    // Now run a timer
    IEnumerator BallEmpowerBuffTimer()
    {
        yield return new WaitForSeconds(duration);
        BallEmpowerBuffUndo();
    }

    //Now return the value back to original
    private void BallEmpowerBuffUndo()
    {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("ball"))
        {
            CircleCollider2D[] myColliders = obj.GetComponents<CircleCollider2D>();
            myColliders[0].enabled = false;
            obj.GetComponent<Ball>().SetSpriteToRender(0);
        }
        Destroy(gameObject);
    }


}
