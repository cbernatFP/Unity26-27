using System;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    public int hits = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Brick") { 
            Destroy(collision.gameObject);
            hits++;
        }
        Debug.Log("Hits: " + hits);
    }
}
