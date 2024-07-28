using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour
{
    [SerializeField]
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "MainPrueba")
        {
            animator.Play("FadeOut");
        }
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
