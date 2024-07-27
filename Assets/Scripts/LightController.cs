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

    public void TurnOff()
    {
        _light.intensity = 0;
    }
}
