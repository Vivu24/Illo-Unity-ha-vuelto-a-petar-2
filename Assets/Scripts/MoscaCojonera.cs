using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MoscaCojonera : MonoBehaviour
{
    private Transform _tr;
    private float _timer = 1;
    private Vector3 _dir;

    // Start is called before the first frame update
    void Start()
    {
        _tr = transform;
        _dir = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(_timer <= 0)
        {
            _dir = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0);
            _timer = 3;
        }
        _tr.localPosition += _dir * Time.deltaTime;
        _timer -= Time.deltaTime;
    }
}
