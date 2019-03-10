using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;
public class LevelOverMenu : MonoBehaviour {

    public string sceneName;
    public float cState;

    private void Awake()
    {
        Advertisement.Initialize("1576771");
        cState = PlayerPrefs.GetFloat("CheckPoint");
    }
    private void Start()
    {
        
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;

    }


    public void Retry()
    {
        int random = Random.Range(0, 6);
        if(random <= 2)
        {
            Advertisement.Show();
        }
       

        if (PlayerPrefs.GetFloat("CheckPoint") == 1 && sceneName == "level07")
        {
            SceneManager.LoadScene("level07c");
        }
        else { 

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }
    public void Menu()
    {
        SceneManager.LoadScene("levelselect");
    }
}
