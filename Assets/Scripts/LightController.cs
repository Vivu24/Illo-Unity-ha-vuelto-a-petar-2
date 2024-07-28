using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class LightController : MonoBehaviour
{
    [SerializeField] private Light _light;
    public Animator palancaAnimator;

    private void Start()
    {
        GetComponent<MeshCollider>().enabled = false;
    }
    public void TurnOn()
    {
        _light.intensity = 3.57f;
        palancaAnimator.SetTrigger("Trigger");
        GetComponent<MeshCollider>().enabled = false;
    }

    public void TurnOff()
    {
        _light.intensity = 0.1f;
        palancaAnimator.SetTrigger("Trigger");
        GetComponent<MeshCollider>().enabled = true;
    }
}
