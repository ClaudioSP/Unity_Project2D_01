using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBehaviour : MonoBehaviour
{
   public int Moedas = 0;
   public bool jogoExecutando = true;

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
    Moedas++;
   }
}
