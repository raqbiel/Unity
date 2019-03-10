using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using TappxSDK;
public class GameManager : MonoBehaviour {

    public Text scoreText;
    public long scoreCount;
    public long highScoreCountEZ;
    public long highScoreCountNM;
    public long highScoreCountHR;


    public static GameManager instance = null;

    public bool playerActive = false;
    public bool gameOver = false;

    /// EndMenu
    public GameObject menuEnd;
    public Text scoreEnd;
    public GameObject UI;

    TappxManagerUnity tmu;
    string sceneName;

    public bool PlayerActive
    {
        get { return playerActive; }
    }

    public void PlayerCollided()
    {
        tmu.interstitialShow();

        menuEnd.SetActive(true);
        UI.SetActive(false);
        gameOver = true;
        playerActive = false;
        Destroy(GameObject.FindGameObjectWithTag("Player"));
      
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies)
            {
                GameObject.Destroy(enemy);
            }
            GameObject[] pkts = GameObject.FindGameObjectsWithTag("Pkt");
            foreach (GameObject punkty in pkts)
            {
                GameObject.Destroy(punkty);
            }

        }
    public void Awake()
    {
        tmu = FindObjectOfType<TappxManagerUnity>();
    }

    // Use this for initialization
    public void Start () {

        tmu.loadInterstitial();

        Scene currentScene = SceneManager.GetActiveScene();
        sceneName =  currentScene.name;

      


    }

    // Update is called once per frame
    void Update()
    {
                 if (scoreCount > highScoreCountEZ && sceneName == "levelEasy")
                  {
                    highScoreCountEZ = scoreCount;
                    Social.ReportScore(highScoreCountEZ, "CgkImNSp9s0NEAIQBA", (bool success) =>
                    {
                        Debug.Log(success ? "Reported score successfully" : "Failed to report score");
                    });
                     
                     }

                 if (scoreCount > highScoreCountNM && sceneName == "levelNormal")
                     {
                     highScoreCountNM = scoreCount;
                     Social.ReportScore(highScoreCountNM, "CgkImNSp9s0NEAIQBQ", (bool success) =>
                     {
                         Debug.Log(success ? "Reported score successfully" : "Failed to report score");
                     });
                 }

                 if (scoreCount > highScoreCountHR && sceneName == "levelHard")
                 {
                     highScoreCountHR = scoreCount;  
                     Social.ReportScore(highScoreCountHR, "CgkImNSp9s0NEAIQBg", (bool success) =>
                     {
                         Debug.Log(success ? "Reported score successfully" : "Failed to report score");
                     });
                 }
                 


            scoreText.text = "Score: " + Mathf.Round(scoreCount);
            scoreEnd.text = "Score: " + Mathf.Round(scoreCount);

          
        }
    

    
    public void ShowLeaderboard()
    {
        if(sceneName == "levelEasy") {
            Debug.Log("Easy");
        PlayGamesPlatform.Instance.ShowLeaderboardUI("CgkImNSp9s0NEAIQBg");
        }else if(sceneName == "levelNormal")
        {
            Debug.Log("Normal");
        PlayGamesPlatform.Instance.ShowLeaderboardUI("CgkImNSp9s0NEAIQBQ");
        }
        else
        {
            Debug.Log("Hard");
        PlayGamesPlatform.Instance.ShowLeaderboardUI("CgkImNSp9s0NEAIQBg");
        }
    }
   


}
