using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Producto : MonoBehaviour
{
    [SerializeField] private bool _isCan;
    [SerializeField] private int _color;

    public bool isCan()
    {
        return _isCan;
    }

    public int color()
    {
        return _color;
    }
}
