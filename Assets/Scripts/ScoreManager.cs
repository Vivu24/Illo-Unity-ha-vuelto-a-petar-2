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
    [SerializeField]
    private TMP_InputField inputName;

    public UnityEvent<string, int> submitScoreEvent;

    public void SubmitScore()
    {
        submitScoreEvent.Invoke(inputName.text, score);
    }
    void Start()
    {
        score = GameManager.Instance.Score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
