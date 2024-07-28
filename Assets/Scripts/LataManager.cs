using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LataManager : MonoBehaviour
{
    private Transform _tr;
    private float _timer;
    private float _initialZ;
    [SerializeField]
    private float _randomizer;
    Color color;

    [SerializeField] private GameObject[] _lata;

    // Start is called before the first frame update
    void Start()
    {
        _tr = transform;
        _initialZ = _tr.position.z;
        _timer = GameManager.Instance.CanCadency;
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

            _timer = GameManager.Instance.CanCadency;
        }

        _timer -= Time.deltaTime;
    }

    void LataCreator()
    {
        int colorRandom = Random.Range(0, 4);

        Instantiate(_lata[colorRandom], _tr).transform.position = new Vector3(_tr.position.x, _tr.position.y, _tr.position.z + _randomizer);
        
        if(colorRandom ==0 || colorRandom ==1)
        {
            GameManager.Instance.cansDeployed++;
        }
        
    }
}