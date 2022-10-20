using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerColisor : MonoBehaviour
{
    public bool colidindo = false;    
    public Action<Collider2D> OnTriggerEnterAction;

    void OnTriggerEnter2D(Collider2D colisor)
    {
        if (colisor.CompareTag("Plataforma") == true)
        {
            colidindo = true;
        }
        if(OnTriggerEnterAction != null){
            OnTriggerEnterAction(colisor);
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
