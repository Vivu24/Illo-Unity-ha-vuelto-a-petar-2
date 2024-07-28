using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventoJefe2 : MonoBehaviour
{

    [SerializeField] GameObject punto2;
    private Vector3 p2pos;

    public float distancia = 10f;
    public float velocidad = 2f;
    public float tiempoEspera = 2f;

    private Vector3 posicionInicial;
    private Vector3 posicionObjetivo;
    public bool volviendo = false;
    public float tiempo = 0f;
    private float contadorEspera = 0f;

    [SerializeField] private AudioClip[] _audios;
    private AudioSource _audioSource;
    private bool _talking = false;

    void Start()
    {
        p2pos = punto2.transform.position;
        posicionInicial = p2pos;

        posicionObjetivo = posicionInicial + Vector3.left * distancia;

        _audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {

        tiempo += Time.deltaTime * velocidad / distancia;

        if (!volviendo)
        {

            transform.position = Vector3.Lerp(posicionInicial, posicionObjetivo, tiempo);

            if (transform.position == posicionObjetivo)
            {

                if (!_talking)
                {
                    ChooseAudio();
                }

                if (contadorEspera <= 0f)
                {
                    contadorEspera = _audioSource.clip.length;
                }
                else
                {

                    contadorEspera -= Time.deltaTime;

                    if (contadorEspera <= 0f)
                    {

                        tiempo = 0f;
                        volviendo = true;
                        _talking = false;
                        GameManager.Instance.bossActive = false;
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


            }
        }
    }

    private void ChooseAudio()
    {
        int rnd = Random.Range(0, 5);
        _audioSource.clip = _audios[rnd];
        _audioSource.Play();
        _talking = true;
    }

}
