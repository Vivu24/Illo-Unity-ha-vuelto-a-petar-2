using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CintaPutaMadre : MonoBehaviour
{
    private Rigidbody _rb;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 pos = _rb.position;
        _rb.position += Vector3.left * GameManager.Instance.LoadingBeltVelocity * Time.fixedDeltaTime;
        _rb.MovePosition(pos);
    }
}