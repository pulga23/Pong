using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    [SerializeField]
    float velocidade = 5f;

    bool bolaLancada = false;
    float tempo = 0f;

       // Update is called once per frame
    void Update()
    {
        
       
        // 2 segundos de espera até lançar a bola 
       if (bolaLancada == false) 
       {
            tempo += Time.deltaTime; //contar o tempo total
            if(tempo>= 2f) //verdade quando passam 2 segundos
            {
                bolaLancada = true;
                GetComponent<Rigidbody2D>().velocity = velocidade * Random.insideUnitCircle; //bola lançada com uma direção aleatoria 
                
            } 
       }

       
    }
}
