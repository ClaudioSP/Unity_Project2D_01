using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColisor : MonoBehaviour
{
    public bool colidindo = false;
    
    void OnTriggerEnter2D(Collider2D colisor)
    {
        if (colisor.CompareTag("Plataforma") == true)
        {
            colidindo = true;
        }
    }

    void OnTriggerExit2D(Collider2D colisor)
    {
        if (colisor.CompareTag("Plataforma") == true)
        {
            colidindo = false;
        }
    }
}
