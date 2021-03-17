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
            tempo += Time.deltaTime;
            if(tempo >= 2f)
            {
                bolaLancada = true;
                Lancarbola();
            } 
       }

       //recomeçar quanto toca nas paredes laterais
       if (transform.position.x >= larguracamera)
       {
            pontosesquerda += 1;
            Lancarbola();
       }
       else if (transform.position.x <= -larguracamera)
       {
            pontosdireita += 1;
            Lancarbola();
       }

        

    }
    //Laçamento da bola
    void Lancarbola()
    {
        transform.position = 0f * Vector3.forward;
        GetComponent<Rigidbody2D>().velocity = velocidade * Random.insideUnitCircle;
        Debug.Log("A pontuação é:");
        Debug.Log("Jodador 1- " + pontosesquerda + "-" + pontosdireita + " -Jogador 2");
    }
}
