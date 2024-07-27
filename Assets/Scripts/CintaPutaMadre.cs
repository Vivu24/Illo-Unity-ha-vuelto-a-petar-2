using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CintaPutaMadre : MonoBehaviour
{
    private Rigidbody _rb;
    private float _speed;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _speed = GameManager.Instance.LoadingBeltVelocity;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 pos = _rb.position;
        _rb.position += Vector3.left * _speed * Time.fixedDeltaTime;
        _rb.MovePosition(pos);
    }
}