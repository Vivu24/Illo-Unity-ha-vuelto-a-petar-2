using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class MoscaCojonera : MonoBehaviour
{
    private Transform _tr;
    [SerializeField] private Sprite _first;
    [SerializeField] private Sprite _second;

    [SerializeField] public GameObject areaSize; // Tamaño del área de movimiento
    [SerializeField]public float speed = 5f; // Velocidad de movimiento

    private Vector3 targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        SetRandomTargetPosition();
        _tr = transform;
    }

    // Update is called once per frame
    void Update()
    {
        MoveTowardsTarget();
        if (ReachedTargetPosition())
        {
            SetRandomTargetPosition();
        }

        if (_tr.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite == _first)
            _tr.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = _second;
        else if (_tr.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite == _second)
            _tr.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = _first;
    }

    void SetRandomTargetPosition()
    {
        float x = Random.Range(-areaSize.transform.localScale.x / 2, areaSize.transform.localScale.x / 2);
        float y = Random.Range(-areaSize.transform.localScale.y / 2, areaSize.transform.localScale.y / 2);
        float z = Random.Range(-areaSize.transform.localScale.z / 2, areaSize.transform.localScale.z / 2);
        targetPosition = new Vector3(x, y, z);
    }

    void MoveTowardsTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }

    bool ReachedTargetPosition()
    {
        return Vector3.Distance(transform.position, targetPosition) < 0.1f;
    }
}
