using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    int contBalls = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D objecteCollisionat)
    {
        
            contBalls++;
            Destroy(objecteCollisionat.gameObject);
            Debug.Log("S'han escapat " + contBalls + " boles");

     

    }
}
