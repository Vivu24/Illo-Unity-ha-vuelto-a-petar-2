using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class EventManager : MonoBehaviour

{

    public int numOfEvent;
    [SerializeField] private GameObject _mosca;
    [SerializeField] private GameObject _gatito;
    [SerializeField] private GameObject _jefe;
    [SerializeField] private GameObject _luz;


    public void ChangeEvent(int n)
    {
        numOfEvent = n;
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

    }

    private void GatitoEvent()
    {

    }

    private void JefeEvent()
    {

    }

    private void LuzEvent()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}