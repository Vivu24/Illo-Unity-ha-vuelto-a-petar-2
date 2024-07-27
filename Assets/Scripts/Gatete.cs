using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Gatete : MonoBehaviour
{
    [SerializeField] private float _force;
    private int[] _lado = {1, -1};

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            Debug.Log("ostia");
            // Play animation
            other.gameObject.transform.parent.GetComponent<Rigidbody>().AddForce(0, 0, _force * _lado[Random.Range(0, 2)]);
        }
    }
}
