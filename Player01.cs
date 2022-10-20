using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; 
using System;

public class Player01 : MonoBehaviour
{

    GameBehaviour jogo;

    PlayerColisor colisorInferior;

    PlayerColisor colisorFrontal;

    PlayerColisor colisorTraseiro;

    Rigidbody2D rb;

    Animator animator;

    bool isJumping = false;

    bool isDead = false;

    public float Velocidade = 3f;

    public float jumpForce = 100f;

    SpriteRenderer renderer01;

    Vector2 move;

    // Start e chamado antes da atualizacao do primeiro quadro
    void Start()
    {   
        
        jogo = GameObject.Find("Main Camera").GetComponent<GameBehaviour>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        renderer01 = GetComponent<SpriteRenderer>();
        colisorInferior = GetComponentsInChildren<PlayerColisor>()[0];
        colisorInferior.OnTriggerEnterAction = delegate(Collider2D obj){
            if (obj.CompareTag("PontoFraco")){
                obj.GetComponentInParent<Enemy>().Morrer();
                
            }
        };
        colisorFrontal = GetComponentsInChildren<PlayerColisor>()[1];
        colisorTraseiro = GetComponentsInChildren<PlayerColisor>()[2];
        
    }

    // Update e chamado uma vez por frame
    void FixedUpdate()
    {   

        

        if(jogo.jogoExecutando == false || this.isDead == true ){
            animator.SetFloat("Velocidade",0f);
            rb.velocity = new Vector2(0f,rb.velocity.y);
            return;
        }
        Vector3 direction = new Vector3(move.x,0f,0f);
        transform.position += direction*Time.deltaTime*Velocidade;
        
        if(direction[0] > 0){
           
            renderer01.flipX = false;
            animator.SetFloat("Velocidade", 1);

        }else if(direction[0] < 0){
            animator.SetFloat("Velocidade", 1);
            renderer01.flipX = true;

        }else if(direction[0] == 0){
            
            animator.SetFloat("Velocidade", 0);
            
        }
        //Move();
        
        isJumping = !colisorInferior.colidindo;

       

      //  float velocidadeX = Math.Abs(this.rb.velocity.x);
        
       
        
        animator.SetBool("Pulo", isJumping);

    }
    /*void Move(){
        
        

        
        //transform.position += direction*Time.deltaTime*Velocidade;

        if(direction[0] > 0){
           
            renderer01.flipX = false;
            animator.SetFloat("Velocidade", 1);

        }else if(direction[0] < 0){
            animator.SetFloat("Velocidade", 1);
            renderer01.flipX = true;

        }else if(direction[0] == 0){
            
            animator.SetFloat("Velocidade", 0);}

    }*/
    public void moveContext(InputAction.CallbackContext value){
        move = value.ReadValue<Vector2>();

    }

    public void Pulo(InputAction.CallbackContext value) {

		if(value.started && isJumping == false && colisorFrontal.colidindo == false){
        
        rb.AddForce (new Vector2 (0, jumpForce),ForceMode2D.Impulse); 
        }
        
        
        //rb.velocity = new Vector2 (rb.velocity.x, 0);
		
		
	}
    float GetAbsVelocity()
    {   
        
        return Mathf.Abs(rb.velocity.x);
    }

    bool IsJumping()
    {
        return isJumping;
    }

    bool IsDead()
    {
        return isDead;
    }
    public void Morrer(){
        if(this.isDead == false ){
        this.isDead = true;
        animator.SetBool("Morto",this.isDead);
        Destroy(this.gameObject,1);
    }
    
    }
}
