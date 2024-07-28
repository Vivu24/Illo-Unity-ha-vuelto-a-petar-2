using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    public Animator panel;

    private bool _hide = false;

    private Vector3 _hided;

    // Start is called before the first frame update
    void Start()
    {
        _hided = new Vector3(transform.position.x, transform.position.y + 300f, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if(_hide)
        {
            transform.position = Vector3.Lerp(transform.position, _hided, 10f * Time.deltaTime);
        }
    }

    IEnumerator Fade()
    {
        panel.SetTrigger("fade");
        Debug.Log("holi");
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("MainPrueba");
    }
    public void LoadPlayState()
    {
        _hide = true;
        StartCoroutine(Fade());        
    }

    public void LoadLeadBoardState()
    {
        _hide = true;
        SceneManager.LoadScene("LeaderBoardScene");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MenuPrueba");

    }

    public void LoadExitApplication()
    {
        Application.Quit();
    }
}
