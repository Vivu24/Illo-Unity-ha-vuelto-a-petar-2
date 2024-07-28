using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

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
        if(SceneManager.GetActiveScene().name == "MainPrueba")
        {
            numOfEvent = n;
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
    }

    private void MoscaEvent()
    {
        Instantiate(_mosca, _flyTr);
        Debug.Log("MOSCA");
    }

    private void GatitoEvent()
    {
        if (!GameManager.Instance.catActive)
        {
            Debug.Log("gato");
            GameManager.Instance.catActive = true;
            _gatito.GetComponent<Gatete>().Enter();
        }
        else
        {
            ChangeEvent(Random.Range(1, 5));
        }
    }

    private void JefeEvent()
    {
        if (!GameManager.Instance.bossActive)
        {
            GameManager.Instance.bossActive = true;
            RndInitialPoint();
        }
        else
        {
            ChangeEvent(Random.Range(1, 5));
        }
    }

    private void LuzEvent()
    {
        _luz.GetComponent<LightController>().TurnOff();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ActiveJefe1()
    {
        _jefe1.SetActive(true);
        _jefe1.GetComponent<EventoJefe>().volviendo = false;
        _jefe1.GetComponent<EventoJefe>().tiempo = 0f;
    }

    private void ActiveJefe2()
    {
        _jefe2.SetActive(true);
        _jefe2.GetComponent<EventoJefe2>().volviendo = false;
        _jefe2.GetComponent<EventoJefe2>().tiempo = 0f;
    }

    private void ActiveJefe3()
    {
        _jefe3.SetActive(true);
        _jefe3.GetComponent<EventoJefe3>().volviendo = false;
        _jefe3.GetComponent<EventoJefe3>().tiempo = 0f;
    }

    private void GestionDialogJefe()
    {

    }

    private void ChooseDialogue(int jefe)
    {
        
    }


    private void RndInitialPoint()
    {
        int rnd = Random.Range(0, 7);
        if (rnd == 0)
        {
            ActiveJefe1();
          
        }
        else if (rnd == 1)
        {
            ActiveJefe2();
        }
        else if(rnd == 2)
        {
            ActiveJefe3();
        }
        else if (rnd == 3)
        {
            ActiveJefe1();
            ActiveJefe2();
        }
        else if (rnd == 4)
        {
            ActiveJefe3();
            ActiveJefe2();
        }
        else if (rnd == 5)
        {
            ActiveJefe1();
            ActiveJefe3();
        }
        else if (rnd == 6)
        {
            ActiveJefe1();
            ActiveJefe2();
            ActiveJefe3();
        }

    }


}
