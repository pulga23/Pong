using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
   [SerializeField]
    float velocidade = 0.5f;

    [SerializeField]
    float AlturaPaddle=1;

    [SerializeField]
    KeyCode upKey = KeyCode.UpArrow;

    [SerializeField]
    KeyCode downKey = KeyCode.DownArrow;
   

    // Update is called once per frame
    void Update()
    {
       //movimento paddle
        if(Input.GetKey(upKey)) 
        {
            //Sobe
            transform.position += velocidade * Vector3.up * Time.deltaTime; //  igual a transform.position = transform.position + velocidade * Vector3.up;
            
        }
       
        else if (Input.GetKey(downKey)) 
        {
            //Desce
            transform.position += velocidade * Vector3.down *Time.deltaTime;
        }

       
        float AlturaCamara = Camera.main.orthographicSize;
        
        // Verificar Limites com ifs 
         if (transform.position.y >= AlturaCamara - (AlturaPaddle*0.5f))
        {
             Vector3 posicaoAux = transform.position; //variavel auxiliar pq unity nao deixa alterar y no transform.postion 
             posicaoAux.y = AlturaCamara - (AlturaPaddle * 0.5f);
             transform.position = posicaoAux;
        }

        if (transform.position.y <= -AlturaCamara +0.5f)
        {
             Vector3 posicaoAux = transform.position; 
             posicaoAux.y = -AlturaCamara + (AlturaPaddle * 0.5f);
             transform.position = posicaoAux;
        }
         

        //Verificar Limites com clamps
        //Vector3 posicaoAux = transform.position;
        //posicaoAux.y = Mathf.Clamp(posicaoAux.y, - AlturaCamara + (AlturaPaddle*0.5), AlturaCamara - (AlturaPaddle*0.5));
        //transform.position = posicaoAux;




    }
}
