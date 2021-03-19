using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    [SerializeField]
    float velocidade = 5f;

    bool bolaLancada = false;
    float tempoinicial = 0f;
    float temporelancar = 0f;
    float tempo = 0f;

    float larguracamera;

    int pontosesquerda = 0; 
    int pontosdireita = 0;
    
    // Start is called before the first frame update
    void Start()
    {
      //  if (Random.value < 0.5f)
        //{
          //  GetComponent<Rigidbody2D>().velocity = velocidade * Vector2.right;
        //}
        //else 
       // {
         //   GetComponent<Rigidbody2D>().velocity = velocidade * Vector2.left;
        //}
        
    }
    

    // Update is called once per frame
    void Update()
    {
        larguracamera = Camera.main.orthographicSize * Camera.main.aspect; //altura da cam x ratio 
        
       if (bolaLancada == false)
       {
            GetComponent<Rigidbody2D>().velocity = velocidade * Vector2.zero;
            transform.position = 0f * Vector3.forward;
            tempo += Time.deltaTime;
            if(tempo>= 2f)
            {
                bolaLancada = true;
                GetComponent<Rigidbody2D>().velocity = velocidade * Random.insideUnitCircle; //bola lançada com uma direção aleatoria 
                Debug.Log("A pontuação é:");
                Debug.Log("Jodador 1- " + pontosesquerda + "-" + pontosdireita + " -Jogador 2");
                tempo = 0f;

            } 
       }

       //recomeçar quanto toca nas paredes laterais
       if (transform.position.x >= larguracamera)
       {
            pontosesquerda += 1;
            bolaLancada = false;
       }
       else if (transform.position.x <= -larguracamera)
       {
            pontosdireita += 1;
            bolaLancada = false;
       }

        

    }
    //Laçamento da bola
    /*void Lancarbola()
    {
        GetComponent<Rigidbody2D>().velocity = velocidade * Vector2.zero;
        transform.position = 0f * Vector3.forward; //bola volta a posição inicial
      
        
            temporelancar += Time.deltaTime;
        
      
        
            transform.position = 0f * Vector3.forward; //bola volta a posição inicial
            GetComponent<Rigidbody2D>().velocity = velocidade * Random.insideUnitCircle; //bola lançada com uma direção aleatoria 
            Debug.Log("A pontuação é:");
            Debug.Log("Jodador 1- " + pontosesquerda + "-" + pontosdireita + " -Jogador 2");
            temporelancar = 0f;
        
        
    }*/
}
