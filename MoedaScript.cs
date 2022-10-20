using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoedaScript : MonoBehaviour
{   
    SpriteRenderer renderizar;
    AudioSource moedaAudio;
    bool ProntoPraRemover = false;
    void Start(){

        renderizar = GetComponent<SpriteRenderer>();
        moedaAudio = GetComponent<AudioSource>();

    }
    void Update(){
        if(ProntoPraRemover ==true && moedaAudio.isPlaying== false){
            Destroy(this.gameObject);
        }
    }
   
    void OnTriggerEnter2D(Collider2D colisao){
        if(colisao.CompareTag("Player01")== true && ProntoPraRemover == false){
            moedaAudio.Play();
            GameObject.Find("Main Camera").GetComponent<GameBehaviour>().AddMoeda();
            ProntoPraRemover = true;
            renderizar.enabled = false;   
        }

    }
        
    
}
