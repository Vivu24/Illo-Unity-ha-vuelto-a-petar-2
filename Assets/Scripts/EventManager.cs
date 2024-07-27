using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class EventManager : MonoBehaviour

{

    public int numOfEvent;
    [SerializeField] private GameObject _mosca;
    [SerializeField] private GameObject _gatito;
    [SerializeField] private GameObject _jefe1;
    [SerializeField] private GameObject _jefe2;
    [SerializeField] private GameObject _jefe3;
    [SerializeField] private GameObject _luz;
    private Vector3 p1pos;
    private Vector3 p2pos;
    private Vector3 p3pos;

    [SerializeField] private Transform _flyTr;



    public void ChangeEvent(int n)
    {
        numOfEvent = 1;
        Debug.Log("EVENTO");
        switch (numOfEvent)
        {
            case 1:
                MoscaEvent();
                break;
            case 2:
                GatitoEvent();
                break;
            case 3:
                JefeEvent();
                break;
            case 4:
                LuzEvent();
                break;
      
        }
    }

    private void MoscaEvent()
    {
        Instantiate(_mosca, _flyTr);
    }

    private void GatitoEvent()
    {

    }

    private void JefeEvent()
    {
        RndInitialPoint();
    }

    private void LuzEvent()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        ChangeEvent(3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void RndInitialPoint()
    {
        int rnd = Random.Range(0, 7);
        if (rnd == 0)
        {
            _jefe1.SetActive(true);
            _jefe1.GetComponent<EventoJefe>().volviendo = false;
            _jefe1.GetComponent<EventoJefe>().tiempo = 0f;
          
        }
        else if (rnd == 1)
        {
            _jefe2.SetActive(true);
            _jefe2.GetComponent<EventoJefe2>().volviendo = false;
            _jefe2.GetComponent<EventoJefe2>().tiempo = 0f;
        }
        else if(rnd == 2)
        {
            _jefe3.SetActive(true);
            _jefe3.GetComponent<EventoJefe3>().volviendo = false;
            _jefe3.GetComponent<EventoJefe3>().tiempo = 0f;
        }
        else if (rnd == 3)
        {
            _jefe1.SetActive(true);
            _jefe1.GetComponent<EventoJefe>().volviendo = false;
            _jefe1.GetComponent<EventoJefe>().tiempo = 0f;

            _jefe2.SetActive(true);
            _jefe2.GetComponent<EventoJefe2>().volviendo = false;
            _jefe2.GetComponent<EventoJefe2>().tiempo = 0f;
        }
        else if (rnd == 4)
        {
            _jefe2.SetActive(true);
            _jefe2.GetComponent<EventoJefe2>().volviendo = false;
            _jefe2.GetComponent<EventoJefe2>().tiempo = 0f;

            _jefe3.SetActive(true);
            _jefe3.GetComponent<EventoJefe3>().volviendo = false;
            _jefe3.GetComponent<EventoJefe3>().tiempo = 0f;
        }
        else if (rnd == 5)
        {
            _jefe1.SetActive(true);
            _jefe1.GetComponent<EventoJefe>().volviendo = false;
            _jefe1.GetComponent<EventoJefe>().tiempo = 0f;

            _jefe3.SetActive(true);
            _jefe3.GetComponent<EventoJefe3>().volviendo = false;
            _jefe3.GetComponent<EventoJefe3>().tiempo = 0f;
        }
        else if (rnd == 6)
        {
            _jefe1.SetActive(true);
            _jefe1.GetComponent<EventoJefe>().volviendo = false;
            _jefe1.GetComponent<EventoJefe>().tiempo = 0f;

            _jefe2.SetActive(true);
            _jefe2.GetComponent<EventoJefe2>().volviendo = false;
            _jefe2.GetComponent<EventoJefe2>().tiempo = 0f;

            _jefe3.SetActive(true);
            _jefe3.GetComponent<EventoJefe3>().volviendo = false;
            _jefe3.GetComponent<EventoJefe3>().tiempo = 0f;
        }

    }


}
