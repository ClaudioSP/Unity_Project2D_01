using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cx_Moedas : MonoBehaviour
{   
    
    AudioSource audio01;
    Animator animador;
    public bool on = false;    
   
    void Start()
    {
        animador = GetComponent<Animator>();
        audio01 = GetComponent<AudioSource>();
    }   

  
    void OnTriggerEnter2D( Collider2D colidindo){
        if (colidindo.CompareTag("Player01")&& on == false){
            on = true;
            animador.SetBool("On",on);
            audio01.PlayDelayed(0.2f);
            GameObject.Find("Main Camera").GetComponent<GameBehaviour>().AddMoeda();
        }

    }






}
