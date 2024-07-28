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
}
