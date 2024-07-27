using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiredEvent : MonoBehaviour
{
    public int caffeine = 100;
    public Animator animator;
    public int decreasecaffeine = 1;
    public int secondsToDecrease = 5;
    public float blinkTimeMultiplier = 3f;
        
        // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DecreaseCaffeine(secondsToDecrease));
    }

    // Update is called once per frame
    void Update()
    {
        if (caffeine <= 70 && !animator.GetBool("sleep"))
        {
            StartCoroutine(Blink((caffeine/100)*blinkTimeMultiplier));
        }
    }
    IEnumerator Blink(float delay)
    {
        animator.SetBool("sleep", true);
        yield return new WaitForSeconds(delay);
        animator.SetBool("sleep", false);
    }
    IEnumerator DecreaseCaffeine(int delay)
    {

        yield return new WaitForSeconds(delay);
        caffeine-=decreasecaffeine;
        if (caffeine <= 70 && !animator.GetBool("sleep"))
        {
            float test = (caffeine / 100) * blinkTimeMultiplier;
            Debug.Log("Parpadeo: " + test);
            StartCoroutine(Blink(test));
        }
        StartCoroutine(DecreaseCaffeine(delay));
    }
}
