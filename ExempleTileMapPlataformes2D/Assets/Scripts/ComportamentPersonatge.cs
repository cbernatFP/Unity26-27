using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportamentPersonatge : MonoBehaviour
{
   
    public float speed = 5f;
    public float jumpSpeed = 10f;

    private Rigidbody2D rb;
    private SpriteRenderer sp;
    //private CapsuleCollider2D cc;
    private BoxCollider2D cc;


    private Vector2 input;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        //cc = GetComponent<CapsuleCollider2D>();
        cc = GetComponent<BoxCollider2D>();


    }

    void Update()
    {
        // Llegim les tecles cada frame
        input.x = Input.GetAxisRaw("Horizontal"); // Esquerra/Dreta
        input.y = Input.GetAxisRaw("Vertical"); // Up/Down

        if (input.x == -1)
        {
            sp.flipX = true;
        }
        else if (input.x == 1)
        {
            sp.flipX = false;
        }

        if (Input.GetKeyDown(KeyCode.Space)  && cc.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            rb.velocity += new Vector2(0f, jumpSpeed);
        }


    }

    void FixedUpdate()
    {
        // Movem el Rigidbody (física estable)
        rb.velocity = new Vector2(input.x * speed, rb.velocity.y);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("11");
        GameObject obj = collision.gameObject;  //l'objecte amb el que hem col.lisionat
        if (obj.CompareTag("Enemy") || obj.CompareTag("Silver") || obj.CompareTag("Bronze"))
        {
            Destroy(collision.gameObject);
            Debug.Log("222");

        }
        /*else if (obj.CompareTag("Spike"))
        {
            Destroy(gameObject);
        }*/
    }

}


