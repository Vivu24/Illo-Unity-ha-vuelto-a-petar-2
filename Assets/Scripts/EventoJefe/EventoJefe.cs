using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventoJefe : MonoBehaviour
{
    [SerializeField] GameObject punto1;
    private Vector3 p1pos;

    public float distancia = 10f;   
    public float velocidad = 2f;    
    public float tiempoEspera = 2f; 

    private Vector3 posicionInicial;
    private Vector3 posicionObjetivo;
    public bool volviendo = false;
    public float tiempo = 0f;
    private float contadorEspera = 0f;

    void Start()
    {
       p1pos = punto1.transform.position;
        posicionInicial = p1pos;
       
        posicionObjetivo = posicionInicial + Vector3.right * distancia;
    }

    void Update()
    {
       
        tiempo += Time.deltaTime * velocidad / distancia;

        if (!volviendo)
        {
            
            transform.position = Vector3.Lerp(posicionInicial, posicionObjetivo, tiempo);

            if (transform.position == posicionObjetivo)
            {
                
                if (contadorEspera <= 0f)
                {
                    contadorEspera = tiempoEspera;
                }
                else
                {
                   
                    contadorEspera -= Time.deltaTime;

                    if (contadorEspera <= 0f)
                    {
                        
                        tiempo = 0f; 
                        volviendo = true;
                    }
                }
            }
        }
        else
        {
            
            transform.position = Vector3.Lerp(posicionObjetivo, posicionInicial, tiempo);

            if (transform.position == posicionInicial)
            {
             
                gameObject.SetActive(false);
                //enabled = false;
                //Destroy(gameObject);
               
               
               
            }
        }
    }

    private void ChooseBoss()
    {
       
    }

}
