using admob;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelLoader : MonoBehaviour {



    public bool playerIn;
   public string levelToLoad;
   PlayerController player;
   public float autoLoadNextLevelAfter;
   public string levelTag;
   string sceneName;
   public GameObject UIPoints;
   public GameObject EndScreen;
   public GameObject mainCamera;
   public GameObject TouchUI;

    GameMgr gameMgr;

    void Start () {
        playerIn = false;
        player = FindObjectOfType<PlayerController>();
        gameMgr = FindObjectOfType<GameMgr>();

        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
    }
	
	// Update is called once per frame
	void Update () {

         if(player.isGrounded && playerIn)
        {
            mainCamera.GetComponent<AudioSource>().enabled = false;
            TouchUI.SetActive(false);
            UIPoints.SetActive(false);
            EndScreen.SetActive(true);
            player.Move(0);
            PlayerPrefs.SetInt("TotalCherry", gameMgr.totalcherry);
            PlayerPrefs.SetInt("TotalDiamonds", gameMgr.totaldiamonds);
            Social.ReportScore(gameMgr.totalcherry, "CgkIqJ2C-KgQEAIQBg", (bool success) =>
            {
                Debug.Log(success ? "Reported score successfully" : "Failed to report score");
            });
            Social.ReportScore(gameMgr.totaldiamonds, "CgkIqJ2C-KgQEAIQBw", (bool success) =>
            {
                Debug.Log(success ? "Reported score successfully" : "Failed to report score");
            });

            Invoke("LoadLevel", autoLoadNextLevelAfter);
        }
	}

    public void LoadLevel()
    {
        if (Admob.Instance().isInterstitialReady())
        {
            Admob.Instance().showInterstitial();
        }
        PlayerPrefs.SetInt(levelTag, 1);
        SceneManager.LoadScene(levelToLoad);
    }
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerIn = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerIn = false;
        }
    }
}

