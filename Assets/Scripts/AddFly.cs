using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddFly : MonoBehaviour
{
    public void Fly()
    {
        GameManager.Instance.AddFlies(1);
        Debug.Log(GameManager.Instance.Flies);
    }
}
