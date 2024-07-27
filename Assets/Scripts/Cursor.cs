using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    private Camera _cam;
    private RaycastHit _hit;
    [SerializeField] private LayerMask _layer;
    private Transform _tr;
    private Vector3 _mousePos;

    [SerializeField] private Vector3 targetPosition;
    private GameObject _can;
    private GameObject lataEnMano;
    private bool isMoving = false;
    private bool tieneLata = false;

    [SerializeField] private float _force;

    // Start is called before the first frame update
    void Start()
    {
        _cam = Camera.main;
        _tr = transform;
    }

    // Update is called once per frame
    void Update()
    {
        //_mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);
        //Debug.Log(_mousePos);
        //_tr.position = new Vector3(_mousePos.x, _mousePos.y, 0);

        if (Physics.Raycast(_cam.ScreenPointToRay(Input.mousePosition), out _hit, 1000, _layer) && Input.GetMouseButtonDown(0))
        {
            Debug.Log("Raycast");

            GameObject obj = _hit.transform.gameObject;

            if (obj.GetComponent<LightController>() != null)
            {
                obj.GetComponent<LightController>().TurnOn();
            }
            else if (obj.GetComponent<Orbit>() != null)
            {
                Destroy(obj.transform.parent.gameObject);
            }
            else if (obj.tag == "Lata" && !isMoving && !tieneLata)
            {
                takeCan(obj);
            }
            else if ((obj.tag == "Pared" || obj.tag == "Lata") && tieneLata)
            {
                throwCan(_hit.point);
            }
        }

        if (isMoving)
        {
            _can.transform.position = Vector3.Lerp(_can.transform.position, targetPosition, Time.deltaTime * 5.0f);
            if (Vector3.Distance(_can.transform.position, targetPosition) < 0.01f)
            {
                _can.transform.position = targetPosition;
                isMoving = false;
                tieneLata = true;
                lataEnMano = _can;
            }
        }

        Debug.Log("tengo lata: " + tieneLata);
    }

    private void takeCan(GameObject can)
    {
        _can = can;

        Rigidbody rb = _can.GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.constraints = RigidbodyConstraints.FreezePosition;
        rb.constraints = RigidbodyConstraints.FreezeRotation;

        lataEnMano = _can;
        isMoving = true;
    }

    private void throwCan(Vector3 target)
    {
        Debug.Log("lanzo");
        //devuelvo fisicas a la lata y la lanzou
        Rigidbody rb = lataEnMano.GetComponent<Rigidbody>();
        rb.useGravity = true;
        rb.constraints = RigidbodyConstraints.None;

        //aplico fuerza a la lata, en la direccion donde ha colisionado el rayo
        rb.AddForce((target - lataEnMano.transform.position).normalized * _force, ForceMode.Impulse);

        tieneLata = false;
    }
}
