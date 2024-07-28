using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PuntuajeMoscas : MonoBehaviour
{

    private TextMeshProUGUI _textMesh;
    private int puntos;


    // Start is called before the first frame update
    void Start()
    {
        _textMesh= GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        puntos = GameManager.Instance.Flies;
        _textMesh.text = puntos.ToString("0");
    }
}
