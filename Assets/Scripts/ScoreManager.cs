using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using System;

public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    
    private int score = 0;


    public TextMeshProUGUI moscasScore;
    public TextMeshProUGUI latasScore;
    public TextMeshProUGUI timerScore;
    public TextMeshProUGUI moscasCount;
    public TextMeshProUGUI latasCount;
    public TextMeshProUGUI timerCount;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scoreLeader;

    public float moscas;
    public float latas; 
    public float timer; 

    //private TMP_InputField inputName;

    //public UnityEvent<string, int> submitScoreEvent;

    //public void SubmitScore()
    //{
    //    submitScoreEvent.Invoke(inputName.text, score);
    //}

    void Start()
    {
        moscas = (float)GameManager.Instance.getFlies();
        latas = GameManager.Instance.cansEnBasura;
        timer = GameManager.Instance.getTime();
        Debug.Log("f: " + moscas + " l: " + latas + "t: " + timer);


        StartCoroutine(Print(moscas, moscasCount));
        StartCoroutine(Print(latas, latasCount));
        StartCoroutine(Print(timer, timerCount));
        StartCoroutine(Print(moscas * 437, moscasScore));
        StartCoroutine(Print(latas * 187, latasScore));
        StartCoroutine(Print(timer * 31, timerScore));

        StartCoroutine(Print(moscas * 437 + latas * 187 + timer * 31, scoreText));
        score = System.Convert.ToInt32(moscas * 437 + latas * 187 + timer * 31);
    }

    IEnumerator Print(float score, TextMeshProUGUI text)
    {
        float number = 0;
        text.text = "0";

        while (number < score)
        {
            number += Mathf.Min(score / 100f, score - number); // Incrementa el número en pasos razonables
            text.text = number.ToString("F0"); // Formato para evitar decimales
            yield return new WaitForSeconds(0.05f);
        }
    }

    IEnumerator PrintTime(TextMeshProUGUI text)
    {
        float number = 0;
        text.text = "0";

        float score = GameManager.Instance.timePlayed;

        while (number < score)
        {
            number += Mathf.Min(score / 100f, score - number); // Incrementa el número en pasos razonables
            text.text = number.ToString("F0"); // Formato para evitar decimales
            yield return new WaitForSeconds(0.05f);
        }
    }
}
