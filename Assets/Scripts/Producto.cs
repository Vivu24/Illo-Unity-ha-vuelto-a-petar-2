using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Producto : MonoBehaviour
{
    [SerializeField] private bool _isCan;
    [SerializeField] private bool _isUsed;
    [SerializeField] private int _color;

    public bool isCan()
    {
        return _isCan;
    }

    public int color()
    {
        return _color;
    }

    public bool isUsed()
    {
        return _isUsed;
    }

    public void setUsed(bool isUsed)
    {
        _isUsed = isUsed;
    }
    public void setColor(int color)
    {
        _color = color;
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.GetComponent<Producto>() == null || 
    //        collision.gameObject.GetComponent<CintaPutaMadre>() == null)
    //    {
    //        gameObject.GetComponent<AudioSource>().volume = 0.05f;
    //        gameObject.GetComponent<AudioSource>().pitch = 0.25f;
    //        gameObject.GetComponent<AudioSource>().Play();
    //    }
    //}
}
