using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMgr : MonoBehaviour {

    public static GameMgr GM;
    public int totalcherry;
    public int totaldiamonds;
    public float cherryCount;
    public float diamondCount;
    public Text cherryText;
    public Text diamondtext;
    public Text cherryTextEnd;
    public Text diamondTextEnd;
    public Text lifeTextEnd;

    public float lifeCount;
    public Text lifeText;

    public GameObject GameOverUI;
    public GameObject GameManager;
    public GameObject TouchControl;

    public Sprite deathSprite;

    [SerializeField]
    private GameObject cameraFollow;
    string sceneName;
    PlayerController playerControl;
    private bool isBreakable;

    private AudioSource allAudioSources;
    public GameObject muteSounds;
    public Sprite spriteSoundOff;
    public Sprite spriteSoundOn;
    private float mState;
    public GameObject exitMenu;
    // Use this for initialization

    void Start () {
        allAudioSources = FindObjectOfType<AudioSource>();

        mState = PlayerPrefs.GetFloat("muted");
        if(mState == 1)
        {
            muteSounds.GetComponent<Image>().sprite = spriteSoundOn;
        }
        else
        {
            muteSounds.GetComponent<Image>().sprite = spriteSoundOff;
        }
        
        totalcherry = PlayerPrefs.GetInt("TotalCherry", totalcherry);
        totaldiamonds = PlayerPrefs.GetInt("TotalDiamonds", totaldiamonds);
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;

        lifeCount = 1;
        playerControl = FindObjectOfType<PlayerController>();

    }

    // Update is called once per frame
    void Update () {

       
        /*cherryText.text = cherryCount.ToString();
        diamondtext.text = diamondCount.ToString();
        cherryTextEnd.text = cherryCount.ToString();
        diamondTextEnd.text = diamondCount.ToString();
        lifeTextEnd.text = lifeCount.ToString();
        lifeText.text = lifeCount.ToString();
        */
        if (totalcherry == 100)
        {
           
            Social.ReportScore(totalcherry, "CgkIqJ2C-KgQEAIQAA", (bool success) =>
            {
                Debug.Log(success ? "Reported score successfully" : "Failed to report score");
            });

        }
        if (totalcherry == 250)
        {

            Social.ReportScore(totalcherry, "CgkIqJ2C-KgQEAIQBA", (bool success) =>
            {
                Debug.Log(success ? "Reported score successfully" : "Failed to report score");
            });
        }
        if (totaldiamonds == 100)
        {

            Social.ReportScore(totaldiamonds, "CgkIqJ2C-KgQEAIQAQ", (bool success) =>
            {
                Debug.Log(success ? "Reported score successfully" : "Failed to report score");
            });

        }
        if (totaldiamonds == 250)
        {

            Social.ReportScore(totaldiamonds, "CgkIqJ2C-KgQEAIQBQ", (bool success) =>
            {
                Debug.Log(success ? "Reported score successfully" : "Failed to report score");
            });
        }

        if (lifeCount <= 0)
        { 
            GameOver();
 
        }

    }

    public void GameOver()
    {
        playerControl.myRigibody.constraints = playerControl.originalCon;
        cameraFollow.GetComponent<AudioSource>().enabled = false;
        cameraFollow.GetComponent<Camerav1>().enabled = false;
        playerControl.GetComponent<Animator>().enabled = false;
        playerControl.GetComponent<SpriteRenderer>().sprite = deathSprite;
        BoxCollider2D[] myColliders = playerControl.gameObject.GetComponentsInChildren<BoxCollider2D>();
        foreach (BoxCollider2D bc in myColliders) bc.enabled = false;
       
        GameOverUI.SetActive(true);
        TouchControl.SetActive(false);
        GameManager.SetActive(false);


    }
    public void MuteSound()
    {

        AudioListener.pause = !AudioListener.pause;
        if (AudioListener.pause)
        {
            PlayerPrefs.SetFloat("muted", 1);
            muteSounds.GetComponent<Image>().sprite = spriteSoundOn;
        }
        else {
            PlayerPrefs.SetFloat("muted", 0);
            muteSounds.GetComponent<Image>().sprite = spriteSoundOff;
        }

    }
    public void ShowExitMenu()
    {
        exitMenu.SetActive(true);
    }
    public void noExitMenu()
    {
        exitMenu.SetActive(false);
    }
    public void Menu()
    {
        SceneManager.LoadScene("levelselect");
    }

}
