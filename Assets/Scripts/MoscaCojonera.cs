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
    [SerializeField] private float _speed;
    [SerializeField] private Sprite _first;
    [SerializeField] private Sprite _second;

    // Start is called before the first frame update
    void Start()
    {
        _tr = transform;
        _dir = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
    }

    // Update is called once per frame
    void Update()
    {
        if(_timer <= 0)
        {
            _dir = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            _timer = 3;
        }
        _tr.localPosition += _dir * Time.deltaTime * _speed;
        _timer -= Time.deltaTime;

        if (_tr.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite == _first)
            _tr.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = _second;
        else if (_tr.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite == _second)
            _tr.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = _first;
    }
}
