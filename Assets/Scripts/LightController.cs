using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class LightController : MonoBehaviour
{
    [SerializeField] private Light _light;

    public void TurnOn()
    {
        _light.intensity = 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        _light.intensity = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
