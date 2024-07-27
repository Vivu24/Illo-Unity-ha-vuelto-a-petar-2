using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    private Camera _cam;
    private RaycastHit _hit;
    [SerializeField] private LayerMask _layer;
    private Transform _tr;
    private Vector3 _mousePos;

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
            else if (obj.transform.parent.GetComponent<MoscaCojonera>() != null)
            {
                Destroy(obj.transform.parent.gameObject);
            }
        }
    }
}
