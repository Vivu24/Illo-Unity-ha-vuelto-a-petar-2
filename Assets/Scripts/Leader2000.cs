using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Dan.Main;
using System.Linq;
using System;
public class Leader2000 : MonoBehaviour
{

    [SerializeField]
    private List<TextMeshProUGUI> names;
    [SerializeField]
    private List<TextMeshProUGUI> scores;

    private string publicLeaderboardKey = "6b16819a5210deef139c15238e3dde03661f79b49950dbc710504ad7520a9469";
    public void getLeaderboard()
    {
        LeaderboardCreator.GetLeaderboard(publicLeaderboardKey, (msg) =>
        {
            for (int i = 0; i < Math.Min(names.Count,msg.Length); ++i)
            {
                names[i].text = msg[i].Username;
                scores[i].text = msg[i].Score.ToString();
            }
        });
       
    }

    public void SetLeaderboardEntry(string username, int score)
    {
       LeaderboardCreator.UploadNewEntry(publicLeaderboardKey, username, score, ((msg) =>
        {
            getLeaderboard();
        }));
    }

    public void disableButton(GameObject boton)
    {
        boton.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
