using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    public Animator panel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
        StartCoroutine(Fade());        
    }

    public void LoadLeadBoardState()
    {
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
