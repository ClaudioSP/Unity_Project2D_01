using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundBehaviour : MonoBehaviour
{
    public float fluxoRio =0.1f;
    public Renderer quad;
    void Update(){
            Vector2 offsetRio = new Vector2(fluxoRio*Time.deltaTime,0);
            quad.material.mainTextureOffset += offsetRio;
         }
}
