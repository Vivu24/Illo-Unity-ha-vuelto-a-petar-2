using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LataManager : MonoBehaviour
{
    private Transform _tr;
    private float _timer;

    [SerializeField] private GameObject _lata;

    // Start is called before the first frame update
    void Start()
    {
        _tr = transform;
        _timer = GameManager.Instance.CanCadency;
    }

    // Update is called once per frame
    void Update()
    {
        if (_timer <= 0)
        {
            Instantiate(_lata, _tr);
            _timer = GameManager.Instance.CanCadency;
        }

        _timer -= Time.deltaTime;
    }
}