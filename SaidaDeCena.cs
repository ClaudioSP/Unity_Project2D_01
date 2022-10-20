using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaidaDeCena : MonoBehaviour
{

    public string reiniciarNivel = null;
    public string proximoNivel = null;
    public float LoadDelay = 3f;
    private float contador = 0f;
    private bool loadProximoNivel = false;
    
    
   
    void Update()
    {
        
        if(loadProximoNivel == true||GameObject.Find("Player") == null){
            contador += Time.deltaTime;
            if(contador >= LoadDelay){
                loadProximoNivel = false;
                SceneManager.LoadScene(proximoNivel);
            }
        }
    }
    void OnTriggerEnter2D(Collider2D colidindo){
        if (colidindo.CompareTag("Player01")){
           GameBehaviour jogo = GameObject.Find("Main Camera").GetComponent<GameBehaviour>(); 
           if (jogo.jogoExecutando ==true){
            jogo.jogoExecutando = false;
            if (string.IsNullOrEmpty(proximoNivel)== false){
                loadProximoNivel = true;
}

           }
        }
    }
}
