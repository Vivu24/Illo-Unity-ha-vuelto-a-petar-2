using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class LightController : MonoBehaviour
{
    [SerializeField] private Light _light;
    private float _timer = 3;

    void OnTriggerStay(Collider other)
    {
        _timer -= Time.deltaTime;
    }

    void OnTriggerExit(Collider other)
    {
        _timer = 3;
    }

    // Start is called before the first frame update
    void Start()
    {
        _light.intensity = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (_timer <= 0)
        {
            _light.intensity = 1;
            _timer = 3;
        }
    }
}
