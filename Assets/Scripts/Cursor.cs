using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;


public class Cursor : MonoBehaviour
{
    private Camera _cam;
    private RaycastHit _hit;
    [SerializeField] private LayerMask _layer;
    private Transform _tr;
    private Vector3 _mousePos;
    [SerializeField] private AudioManager _audioManager;

    [SerializeField] private Vector3 targetPosition;
    private GameObject _can;
    private GameObject lataEnMano;
    private bool isMoving = false;
    private bool tieneLata = false;
    [SerializeField] private float takeVelocity = 5.0f;

    [SerializeField] private BoxCollider _boxCollider;
    [SerializeField] private CapsuleCollider _capsuleCollider;
    [SerializeField] private BoxCollider _catCollider;
    [SerializeField] private Animator _animator;

    [SerializeField] private float _force;

    private int _pets = 0;

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
            Debug.Log("Raycast: " + _hit.transform.gameObject);

            GameObject obj = _hit.transform.gameObject;

            if (obj.GetComponent<LightController>() != null)
            {
                obj.GetComponent<LightController>().TurnOn();
            }
            else if (obj.GetComponent<Orbit>() != null)
            {
                _audioManager.KillFly();
                Debug.Log("moscaaaaa");
                _animator.Play("Subir");
                Destroy(obj.transform.parent.gameObject);
            }
            else if (obj.tag == "Lata" && !isMoving && !tieneLata)
            {
                takeCan(obj);
            }
            else if (obj.tag == "Redbull" && !tieneLata && !isMoving)
            {
                drinkRedbull(obj);
            }
            else if ((obj.tag == "Pared" || obj.tag == "Lata") && tieneLata)
            {
                throwCan(_hit.point);
            }
            else if (obj.GetComponent<Gatete>() != null)
            {
                AudioClip gatoFeliz = GameManager.Instance.gatoFeliz[Random.Range(0, GameManager.Instance.gatoFeliz.Length)];

                AudioSource.PlayClipAtPoint(gatoFeliz, new Vector3(0, 0, 0));
                _pets++;

                if (_pets == 4)
                {
                    obj.GetComponent<Gatete>().FlipAndLeave();
                    _pets = 0;
                }
            }
        }

        if (isMoving)
        {
            _can.transform.position = Vector3.Lerp(_can.transform.position, targetPosition, Time.deltaTime * takeVelocity);
            if (Vector3.Distance(_can.transform.position, targetPosition) < 0.01f)
            {
                _can.transform.position = targetPosition;
                isMoving = false;
                tieneLata = true;
                lataEnMano = _can;
            }
        }
    }

    private void takeCan(GameObject can)
    {
       if (can.GetComponent<Producto>().canBeTaken)
       {
            _can = can;
            

            Rigidbody rb = _can.GetComponent<Rigidbody>();
            rb.useGravity = false;
            rb.constraints = RigidbodyConstraints.FreezePosition;
            rb.constraints = RigidbodyConstraints.FreezeRotation;

            _boxCollider = rb.GetComponent<BoxCollider>();
            _boxCollider.enabled = false;  
            _capsuleCollider = rb.GetComponent<CapsuleCollider>();
            _capsuleCollider.enabled = false;
        

            lataEnMano = _can;
            tieneLata = true;
            isMoving = true;
        }
    }

    private void drinkRedbull(GameObject can)
    {
        takeCan(can);
        if (!can.GetComponent<Producto>().isUsed())
        {
            GameManager.Instance.drinkRedbull();
            can.GetComponent<Producto>().setUsed(true);
        }
    }

    private void throwCan(Vector3 target)
    {
        Debug.Log("lanzo");
        //devuelvo fisicas a la lata y la lanzou
        Rigidbody rb = lataEnMano.GetComponent<Rigidbody>();
        rb.useGravity = true;
        rb.constraints = RigidbodyConstraints.None;

        //aplico fuerza a la lata, en la direccion donde ha colisionado el rayo
        float forceMult = Mathf.Min(Vector3.Distance(lataEnMano.transform.position, target) * _force, 130.0f);
        rb.AddForce((target - lataEnMano.transform.position).normalized * forceMult, ForceMode.Impulse);

       _boxCollider.enabled = true;
        //_capsuleCollider.enabled = true;

        lataEnMano.GetComponent<Producto>().canBeTaken = false;
        tieneLata = false;
        isMoving = false;
        if (lataEnMano.GetComponent<Producto>().isUsed())
        {
            GameManager.Instance.spawnRedbull();
            lataEnMano.tag= ("Lata");
            lataEnMano.GetComponent<Producto>().setUsed(false);
        }
    }
}
