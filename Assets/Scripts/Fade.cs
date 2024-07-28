using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    [SerializeField]
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void fadeOut()
    {
        animator.Play("FadeOut");
    }

    public void fadeIn()
    {
        animator.Play("FadeIn");
    }
}
