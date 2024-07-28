using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LataManager2 : MonoBehaviour
{
    private Transform _tr;
    private float _timer;
    private float _initialZ;
    [SerializeField]
    private float _randomizer;
    Color color;
    private int maxRandom = 1;

    [SerializeField] private GameObject[] _lata;

    // Start is called before the first frame update
    void Start()
    {
        _tr = transform;
        _initialZ = _tr.position.z;
        _timer = 5;

    }

    // Update is called once per frame
    void Update()
    {
        if (_timer <= 0)
        {
            _randomizer = Random.Range(-0.35f, 0.35f);
            //Vector3 aux3D = new Vector3(_tr.position.x, _tr.position.y, _tr.position.z + _randomizer);
            //Transform auxTr = _tr;
            //auxTr.position = aux3D;
            LataCreator();

            _timer = 5;
        }

        _timer -= Time.deltaTime;
    }

    void LataCreator()
    {
        Instantiate(_lata[0], _tr).transform.position = new Vector3(_tr.position.x, _tr.position.y, _tr.position.z + _randomizer);        
    }
}