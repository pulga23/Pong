using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    [SerializeField]
    float velocidade = 5f;

    bool bolaLancada = false;
    float tempo = 0f;

    float larguracamera;

    int pontosesquerda = 0; 
    int pontosdireita = 0;
     

    // Update is called once per frame
    void Update()
    {
        larguracamera = Camera.main.orthographicSize * Camera.main.aspect; //altura da cam x ratio 
       
        // 2 segundos de espera até lançar a bola 
       if (bolaLancada == false)
       {
            GetComponent<Rigidbody2D>().velocity = velocidade * Vector2.zero; //velocidade da bola posta a zero
            transform.position = 0f * Vector3.forward; //bola volta para posição incial
            tempo += Time.deltaTime;
            if(tempo>= 2f)
            {
                bolaLancada = true;
                GetComponent<Rigidbody2D>().velocity = velocidade * Random.insideUnitCircle; //bola lançada com uma direção aleatoria 
                tempo = 0f;

            } 
       }

       //recomeçar quanto toca nas paredes laterais
       if (transform.position.x >= larguracamera) //bola toca parede da direita 
       {
            pontosesquerda += 1;
            Debug.Log("A pontuação é:");
            Debug.Log("Jodador 1- " + pontosesquerda + "-" + pontosdireita + " -Jogador 2");
            bolaLancada = false;
       }
       else if (transform.position.x <= -larguracamera) //bola toca parede da esquerda
       {
            pontosdireita += 1;
            Debug.Log("A pontuação é:");
            Debug.Log("Jodador 1- " + pontosesquerda + "-" + pontosdireita + " -Jogador 2");
            bolaLancada = false;
       }

    }
}
