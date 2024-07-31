using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Producto : MonoBehaviour
{
    [SerializeField] private bool _isCan;
    [SerializeField] private bool _isUsed;
    [SerializeField] private int _color;
    public bool canBeTaken = true, canBeTakenCR_running = true;

    public void Update()
    {
        if (!canBeTaken && canBeTakenCR_running)
        {
            StartCoroutine(takeAgainCD(1.5f));
        }
    }

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

    private IEnumerator takeAgainCD(float time)
    {
        canBeTakenCR_running = false;
        yield return new WaitForSeconds(time);
        canBeTaken = true;
        canBeTakenCR_running = true;
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
