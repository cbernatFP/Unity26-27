using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    public int hitPoints = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Brick")
            Destroy(collision.gameObject);
       
    }
}
