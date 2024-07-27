using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadPlayState()
    {
        SceneManager.LoadScene("MainPrueba");
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
