using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    private Transform _tr;
    private Transform _pivote;
    [SerializeField] private float _speed;

    // Start is called before the first frame update
    void Start()
    {
        _tr = transform;
        _pivote = _tr.parent;
    }

    // Update is called once per frame
    void Update()
    {
        _tr.RotateAround(_pivote.position, Vector3.back, _speed * Time.deltaTime);
    }
}
