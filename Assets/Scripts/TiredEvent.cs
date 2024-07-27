using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiredEvent : MonoBehaviour
{
    public float caffeine = 100f;
    public Animator animator;
    public int decreasecaffeine = 4;
    public int secondsToDecrease = 5;
    public float timeToIncreaseDecreaseCaffeine = 40;
    public int MaxDecreaseCaffeine = 8;
    GameManager manager = GameManager.Instance;
        
        // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DecreaseCaffeine(secondsToDecrease));
        StartCoroutine(IncreaseDecreaseCafeine(timeToIncreaseDecreaseCaffeine));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void restartCaffeine()
    {
        caffeine = 100;
    }
    IEnumerator Blink(float delay)
    {
        animator.SetBool("sleep", true);
        yield return new WaitForSeconds(delay);
        animator.SetBool("sleep", false);
        StartCoroutine(DecreaseCaffeine(secondsToDecrease));
    }
    IEnumerator DecreaseCaffeine(int delay)
    {

        yield return new WaitForSeconds(delay);
        caffeine -= decreasecaffeine;
        if (caffeine <= 0 && !animator.GetBool("sleep"))
        {
            if (manager.Lifes != 0) manager.LoseLife();
        }
        else if (caffeine <= 20 && !animator.GetBool("sleep"))
        {
            StartCoroutine(Blink(6));
        }
        else if (caffeine <= 40 && !animator.GetBool("sleep"))
        {
            StartCoroutine(Blink(3));
        }
        else if (caffeine <= 70 && !animator.GetBool("sleep"))
        {
            StartCoroutine(Blink(1.5f));
        }
        else if (caffeine > 70)
        {
            StartCoroutine(DecreaseCaffeine(delay));
        }
    }
    IEnumerator IncreaseDecreaseCafeine(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (decreasecaffeine < MaxDecreaseCaffeine) decreasecaffeine++;
        StartCoroutine(IncreaseDecreaseCafeine(delay));
    }
}