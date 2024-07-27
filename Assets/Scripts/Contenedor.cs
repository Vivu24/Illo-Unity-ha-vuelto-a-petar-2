using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contenedor : MonoBehaviour
{
    [SerializeField] private int _color;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Producto>().isCan())
        {
            if (other.gameObject.GetComponent<Producto>().color() == _color)
            {
                GameManager.Instance.AddPoints(49);
            }
            else
            {
                GameManager.Instance.LoseLife();
            }
        }
        else
        {
            GameManager.Instance.LoseLife();
        }
    }
}
