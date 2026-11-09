using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Aquest script el porta la bola PROTAGONISTA.
// Cada cop que xoca amb una bola marcada amb l'etiqueta (Tag) "Moneda",
// la destrueix. Les parets i rampes no es destrueixen perque no tenen
// aquesta etiqueta.
public class DestructorBoles : MonoBehaviour
{
    int contMonedes = 0;

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
        if (objecteCollisionat.gameObject.tag == "Moneda")
        {
            contMonedes++;
            Destroy(objecteCollisionat.gameObject);
            Debug.Log("Monedes agafades: " + contMonedes);
        }
    }
}
