using UnityEngine;

// Un únic script enlloc dels 3 scripts de Bricks. Una mica més complicat
public class BrickBehaviour : MonoBehaviour
{
    int hits = 0;
    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        // Brick1 aguanta 3 cops, Brick2 en aguanta 2 i Brick3 només 1
        if (CompareTag("Brick1")) {
            hits = 0;
        }
        else if (CompareTag("Brick2")) {
            hits = 1;
        }
        else if (CompareTag("Brick3")) {
            hits = 2;
        }
        //UpdateColor();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        hits++;
        if (hits >= 3) {
            Destroy(gameObject);
        }
        else {
            UpdateColor();
        }
    }

    private void UpdateColor() {
        if (hits == 1) {
            sr.color = new Color32(255, 97, 169, 255);
        }
        else if (hits == 2) {
            sr.color = new Color32(255, 34, 136, 255);
        }
    }
}
