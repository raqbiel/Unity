using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;
public class MenuScript : MonoBehaviour {

    
        ConnectionCheck concheck;
    public string levelTag;
    public Dialog dialog;
    string sceneName;

    public GameObject socialIcons;
    public GameObject buttonClick;
    public GameObject googleServices;
    public GameObject CanvasMenu;
    public GameObject cameraSound;
    public AudioClip changeSound;
    public GameObject credits;
    public GameObject exitButton;

    public GameObject exitMenu;

    private AudioSource allAudioSources;
    public GameObject muteSounds;
    public Sprite spriteSoundOff;
    public Sprite spriteSoundOn;
    private float mState;

    // Use this for initialization
    public void Start () {

        allAudioSources = FindObjectOfType<AudioSource>();

        mState = PlayerPrefs.GetFloat("muted");
        if (mState == 1)
        {
            muteSounds.GetComponent<Image>().sprite = spriteSoundOn;
        }
        else
        {
            muteSounds.GetComponent<Image>().sprite = spriteSoundOff;
        }

        concheck = FindObjectOfType<ConnectionCheck>();
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        PlayerPrefs.SetInt("level1lock", 1);

        //sceneFader = FindObjectOfType<SceneFader>();

        if (PlayerPrefs.GetFloat("DialogLevel") == 0)
        {
            cameraSound.GetComponent<AudioSource>().clip = changeSound;
            cameraSound.GetComponent<AudioSource>().Play();
            buttonClick.SetActive(true);
            CanvasMenu.SetActive(false);
            socialIcons.SetActive(false);
            googleServices.SetActive(false);
            credits.SetActive(false);
            exitButton.SetActive(false);
            muteSounds.SetActive(false);
        }
        else
        {
            muteSounds.SetActive(true);
            credits.SetActive(true);
            socialIcons.SetActive(true);
            CanvasMenu.SetActive(true);
            googleServices.SetActive(true);
            buttonClick.SetActive(false);
            exitButton.SetActive(true);
            // sceneFader.FadeTo("levelselect");
        }

    }
   
    // Update is called once per frame
   void Update () {
		
	}
    public void LoadLevelButton(string level)
    {
        SceneManager.LoadScene(level);
    }

    public void QuitApp()
    {
        Application.Quit();
    }
    public void ShowExitMenu()
    {

        exitMenu.SetActive(true);
        concheck.googleMenu.SetActive(false);
    }
    public void ShowLeaderboard()
    {
        print("Leaderboard showed");
      //  PlayGamesPlatform.Instance.ShowLeaderboardUI("CgkIqJ2C-KgQEAIQBg");
         Social.ShowLeaderboardUI();

    }
    public void ShowAchiev()
    {
        print("Achiev showed");
        Social.ShowAchievementsUI();
    }
    public void ButtonNo()
    {
        exitMenu.SetActive(false);
    }
    public void MuteSound()
    {

        AudioListener.pause = !AudioListener.pause;
        if (AudioListener.pause)
        {
            PlayerPrefs.SetFloat("muted", 1);
            muteSounds.GetComponent<Image>().sprite = spriteSoundOn;
        }
        else
        {
            PlayerPrefs.SetFloat("muted", 0);
            muteSounds.GetComponent<Image>().sprite = spriteSoundOff;
        }

    }
}
