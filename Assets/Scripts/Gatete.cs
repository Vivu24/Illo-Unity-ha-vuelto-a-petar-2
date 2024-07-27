using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Gatete : MonoBehaviour
{
    [SerializeField] private float _force;

    [SerializeField] private Sprite _normal;
    [SerializeField] private Sprite _delante;
    [SerializeField] private Sprite _detras;

    private float _timer = 1;

    private int[] _lado = {1, -1};

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            Debug.Log("ostia");
            int lado = _lado[Random.Range(0, 2)];
            other.gameObject.transform.parent.GetComponent<Rigidbody>().AddForce(0, 50, _force * lado);
            if (lado == 1)
            {
                GetComponent<SpriteRenderer>().sprite = _delante;
            }
            else if (lado == -1)
            {
                GetComponent<SpriteRenderer>().sprite = _detras;
            }
        }
    }

    void Update()
    {
        if (GetComponent<SpriteRenderer>().sprite == _detras || GetComponent<SpriteRenderer>().sprite == _delante)
        {
            if (_timer <= 0)
            {
                GetComponent<SpriteRenderer>().sprite = _normal;
                _timer = 1;
            }
            _timer -= Time.deltaTime;
        }
    }
}
