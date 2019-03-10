using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;



public class GameManager : MonoBehaviour {

    public static GameManager instance = null;

    public Text scoreText;
    public Text scoreEnd;
    public Text highScore;
    public int scoreCount;
    public int highscore;
    public GameObject GameUI;
    public GameObject OverUI;

    public bool gameOver;

    public Animator goodAnim;
    public GameObject GoodText;
    public Text goodText;


    private AndroidJavaObject bannerControl = null;
    public AndroidJavaObject interstitialControl = null;
    // Use this for initialization

    private void Awake()
    {
      
     
    }
    void Start () {

     
     
        scoreText = GameObject.Find("Score").GetComponent<Text>();
        highscore = PlayerPrefs.GetInt("highscore", highscore);
    }
	
	// Update is called once per frame
	void Update () {


        if (scoreCount > highscore)
        {
            highscore = scoreCount;
            Social.ReportScore(highscore, "CgkIxI7j_YUTEAIQAQ", (bool success) =>
            {
                Debug.Log(success ? "Reported score successfully" : "Failed to report score");
            });
        }

        if (scoreCount == 15)
        {
            // unlock achievement (achievement ID "Cfjewijawiu_QA")
            Social.ReportProgress("CgkIxI7j_YUTEAIQAg", 100.0f, (bool success) => {
                // handle success or failure
            });
      
        }
        if (scoreCount == 50)
        {
            // unlock achievement (achievement ID "Cfjewijawiu_QA")
            Social.ReportProgress("CgkIxI7j_YUTEAIQAw", 100.0f, (bool success) => {
                // handle success or failure
            });

        }
        if (scoreCount == 70)
        {
            // unlock achievement (achievement ID "Cfjewijawiu_QA")
            Social.ReportProgress("CgkIxI7j_YUTEAIQBA", 100.0f, (bool success) => {
                // handle success or failure
            });

        }
        if (scoreCount == 100)
        {
            // unlock achievement (achievement ID "Cfjewijawiu_QA")
            Social.ReportProgress("CgkIxI7j_YUTEAIQBQ", 100.0f, (bool success) => {
                // handle success or failure
            });

        }

        PlayerPrefs.SetInt("highscore", highscore);

        scoreText.text = "Score: " + Mathf.Round(scoreCount);
        scoreEnd.text = "Score: " + Mathf.Round(scoreCount);
        highScore.text = "Highscore: " + Mathf.Round(highscore);

   

    }

    public void GameOver()
    {


        gameOver = true;
        GameUI.SetActive(false);
        OverUI.SetActive(true);
    }

    public IEnumerator GoodAnimation(string text)
    {
        GoodText.SetActive(true);
        goodText.text = text;
        goodAnim.Play("Good");
        yield return new WaitForSeconds(1f);
        GoodText.SetActive(false);

    }
        public void LoadLevel(string level)
    {
        SceneManager.LoadScene(level);
    }

    public void LoadRetry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void QuitApp()
    {
        Application.Quit();
    }
    public void ShowLeaderboard()
    {
        
        PlayGamesPlatform.Instance.ShowLeaderboardUI("CgkIxI7j_YUTEAIQAQ");
        
    }
    public void ShowAchiev()
    {
        Social.ShowAchievementsUI();
    }

}
