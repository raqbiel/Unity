using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AchievementSystem : MonoBehaviour
{

    private AudioSource audioSrc;
    public AudioClip audioClip;
    string sceneName;
    // Use this for initialization
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        audioSrc = GetComponent<AudioSource>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.gameObject.name == "Player") {
        audioSrc.PlayOneShot(audioClip);
        Destroy(gameObject, 2f);
        }
        if (sceneName == "level01" && collision.gameObject.name == "Player")
        {
          
            Social.ReportProgress("CgkIqJ2C-KgQEAIQAw", 100.0f, (bool success) => {
            // handle success or failure
            });
        }
        if(sceneName == "level02" && collision.gameObject.name == "Player")
        {
            
            Social.ReportProgress("CgkIqJ2C-KgQEAIQAg", 100.0f, (bool success) => {
                // handle success or failure
            });
        }
        if (sceneName == "level03" && collision.gameObject.name == "Player")
        {

            Social.ReportProgress("CgkIqJ2C-KgQEAIQDA", 100.0f, (bool success) => {
                // handle success or failure
            });
        }
        if (sceneName == "level05" && collision.gameObject.name == "Player")
        {

            Social.ReportProgress("CgkIqJ2C-KgQEAIQCw", 100.0f, (bool success) => {
                // handle success or failure
            });
        }
        if (sceneName == "level06" && collision.gameObject.name == "Player")
        {

            Social.ReportProgress("CgkIqJ2C-KgQEAIQCQ", 100.0f, (bool success) => {
                // handle success or failure
            });
        }
        if (sceneName == "level07" && collision.gameObject.name == "Player")
        {

            Social.ReportProgress("CgkIqJ2C-KgQEAIQCg", 100.0f, (bool success) => {
                // handle success or failure
            });
        }
    }
}
