using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakWindow : MonoBehaviour
{
    [SerializeField] private GameObject normalGlass;
    [SerializeField] private GameObject destroyedGlassParent;
    private AudioSource _audioSource;



    private void OnCollisionEnter(Collision collision)
    {
        destroyedGlassParent.SetActive(true);
        normalGlass.SetActive(false);
    }

}
