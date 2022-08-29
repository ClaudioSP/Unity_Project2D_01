using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    public float Velocidade = 4f;

    public float jumpForce = 100f;

    SpriteRenderer renderer01;

    // Start e chamado antes da atualizacao do primeiro quadro
    void Start()
    {   
        
        jogo = GameObject.Find("Main Camera").GetComponent<GameBehaviour>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        renderer01 = GetComponent<SpriteRenderer>();
        colisorInferior = GetComponentsInChildren<PlayerColisor>()[0];
        colisorFrontal = GetComponentsInChildren<PlayerColisor>()[1];
        colisorTraseiro = GetComponentsInChildren<PlayerColisor>()[2];
        
    }

    // Update e chamado uma vez por frame
    void Update()
    {

        if(jogo.jogoExecutando == false){
            animator.SetFloat("Velocidade",0f);
            rb.velocity = new Vector2(0f,rb.velocity.y);
            return;
        }

        Move();
        
        isJumping = !colisorInferior.colidindo;

        if (Input.GetButtonDown("Jump") && isJumping == false )
        {  
        Pulo();
        }

        float velocidadeX = Math.Abs(this.rb.velocity.x);
        
       
        
        animator.SetBool("Pulo", isJumping);

    }
    void Move(){

        Vector2 dir = Vector2.zero;
        if (Input.GetKey(KeyCode.A) == true && colisorTraseiro.colidindo ==false)
        {
            dir.x = -1;
        }
        else if (Input.GetKey(KeyCode.D) == true && colisorFrontal.colidindo ==false)
        {
            dir.x = 1;
        }
      
        Vector2 vel = rb.velocity;
        vel.x = dir.x * Velocidade;
        rb.velocity = vel;
        animator.SetFloat("Velocidade", GetAbsVelocity());
     
        if (rb.velocity.x > 0)
        {
            renderer01.flipX = false;
        }
        else if (rb.velocity.x < 0)
        {
            renderer01.flipX = true;
        }
        float velocidadeX = Math.Abs(this.rb.velocity.x);
        


       /* Vector3 movimento = new Vector3(Input.GetAxis("Horizontal"),0f,0f);
        transform.position += movimento*Time.deltaTime*Velocidade;
        if(movimento[0] > 0){
            renderer.flipX = false;

        }else if(movimento[0] < 0){
            renderer.flipX = true;
        }*/

    }

    private void Pulo() {
		
        rb.AddForce (new Vector2 (0, jumpForce),ForceMode2D.Impulse);
        
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
}
