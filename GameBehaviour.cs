using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class GameBehaviour : MonoBehaviour
{
   public int moedas = 0;
   public bool jogoExecutando = true;
   public Text MoedaTxt;
   void Start(){
      GameObject inicio = GameObject.Find("Inicio");
      if (inicio == null){
         throw new UnityException("Ponto inicial Não Existe!");
      }
      GameObject player =GameObject.Find("Player");
      if (player == null){
         throw new UnityException("Player não existe!");
      }
      player.transform.position = new Vector3(inicio.transform.position.x,inicio.transform.position.y,player.transform.position.z);
      


         }
        
   public void AddMoeda(){
    moedas++;
    print(moedas);
    MoedaTxt.text = moedas.ToString();
   }
}
