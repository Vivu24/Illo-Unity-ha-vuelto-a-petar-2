using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor2000 : MonoBehaviour
{
    // este script lo lleva la camara (NO LA LATA"!!)

    Ray ray;
    RaycastHit hit;

    private GameObject lata;
    private Vector3 targetPosition;
    private bool isMoving = false;
    private bool tieneLata = false;
    [SerializeField]
    public float pickUpSpeed = 5.0f;
    public float throwForce = 50.0f;

    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (hit.collider.tag == "Lata" && !isMoving && !tieneLata) //losiento el string typing mola 
                {
                    Debug.Log("click sin lata");

                    // agarrar lata
                    lata = hit.collider.gameObject;

                    //le desactivo rb
                    Rigidbody rb = lata.GetComponent<Rigidbody>();
                    rb.useGravity = false;
                    rb.constraints = RigidbodyConstraints.FreezePosition;
                    rb.constraints = RigidbodyConstraints.FreezeRotation;

                    //la muevo
                    targetPosition = new Vector3(2, 0.5f, -8);
                    isMoving = true;
                }
                else if(hit.collider.tag != "Lata") //por siqeremos interactuar con otro obj
                {
                    Debug.Log("no lataa");
                }
                // *** añadir mas else ifs si eso para otros objs

                // quehaceres con la lata si es q he cogido
                if (tieneLata)
                {
                    Debug.Log("click con lata");
                    Debug.Log(hit.collider);

                    Rigidbody rb = lata.GetComponent<Rigidbody>();

                    if (hit.collider.tag == "Basura")
                    {
                        // tirar lata a la basura?¿
                        Debug.Log("click en basura con lata");

                    }
                    else if (hit.collider.tag == "Fondo") // voy a suponer q el fondo tiene collider
                    {
                        Debug.Log("click en la nada con lata");
                        // lanza lata ?¿?¿?¿ no se q quereis q haga
                        // (Aqui iria logica para lanzar lata pero q perreza ahora


                        // dejar caer lata
                        rb.useGravity = true;
                        rb.constraints = RigidbodyConstraints.None;
                    }

                }
            }
        }

        // si estamos moviendo lata, parar cuando llegue al targetPos
        if (isMoving)
        {
            lata.transform.position = Vector3.Lerp(lata.transform.position, targetPosition, Time.deltaTime * pickUpSpeed);

            if (Vector3.Distance(lata.transform.position, targetPosition) < 0.01f)
            {
                lata.transform.position = targetPosition;
                isMoving = false;
                tieneLata = true;
            }
        }
    }
}
