using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   
    Rigidbody2D rb;
    Animator animador;
    public int direcao = 1;
    public float velocidade =2f;
    public bool vivo =true ;


    void Start()
    {
      rb = GetComponent<Rigidbody2D>();
      animador = GetComponent<Animator>();    
    }
 
    void FixedUpdate()
    {
        if(vivo == true){
            rb.velocity = new Vector2(velocidade * direcao,rb.velocity.y);
           
        }else{
            rb.velocity =Vector2.zero;
            rb.AddForce(new Vector2(0,5));
            Destroy(this.gameObject,3);
           

            
        }

       animador.SetFloat("velocidade",Mathf.Abs(rb.velocity.x));

    } 

    public void Morrer(){
        if (vivo){
            vivo = false;
            GetComponent<CapsuleCollider2D>().enabled = false;
            animador.SetBool("morto",true );
           /* rb.velocity =Vector2.zero;
            rb.AddForce(new Vector2(0,5));*/
            
        }


    }
    void OnTriggerExit2D(Collider2D colidindo){
        if (colidindo.CompareTag("Plataforma") && vivo){
            direcao = direcao*-1;
            rb.velocity = new Vector2(0,rb.velocity.y);
            this.transform.localScale = new Vector3(
                this.transform.localScale.x*-1,
                this.transform.localScale.y,
                this.transform.localScale.x*-1);
        }

       } 
    void OnCollisionEnter2D(Collision2D player){

        if(player.gameObject.CompareTag("Player01")&& vivo == true){
            player.gameObject.GetComponent<Player01>().Morrer();
        }

    }   
}
