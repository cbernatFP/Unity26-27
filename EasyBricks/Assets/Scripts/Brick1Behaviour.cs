using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick1Behaviour : MonoBehaviour
{
    int hits = 0;
    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        hits++;
        if (hits == 1) {
            sr.color = new Color32(255, 97, 169, 255);
        }
        else if (hits == 2) {
            sr.color = new Color32(255, 34, 136, 255);
        }
        else if (hits == 3) {
            Destroy(gameObject);
        }
    }
}
