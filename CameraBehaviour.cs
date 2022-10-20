using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{  //[SerializeField]
   // private float maximoX=33.35f;
    [SerializeField]
    private float minimoX=-2.53f;
    //[SerializeField]
    //private float maximoY;
    [SerializeField]
    private float minimoY;

    public Transform player;

    //public Vector2 offset = new Vector2(0,-3);
    
    
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    void Update()
    { 
         if(player == null ){
           return; 
        }
        
        Vector3 pos = this.transform.position;
        
        pos.x = player.position.x;

        pos.y = player.position.y;

        //pos.y = pos.y <= maximoY? maximoY : pos.y;
        pos.y = pos.y <= minimoY? minimoY : pos.y;
        //pos.x = pos.y <= maximoX? maximoX : pos.x;
        pos.x = pos.x <= minimoX? minimoX : pos.x;

        this.transform.position = pos;
    }
}
