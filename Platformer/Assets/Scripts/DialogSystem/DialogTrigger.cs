using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;
using System.Collections.Generic;


public class DialogTrigger : MonoBehaviour {

    public Dialog dialog;
    SceneFader sceneFader;
    string sceneName;
    public GameObject levelButtons;
    
    void Start()
    {
    
        // OneSignal.SetLogLevel(OneSignal.LOG_LEVEL.INFO, OneSignal.LOG_LEVEL.INFO);

        OneSignal.StartInit("ee918653-6c7b-42d3-a7a2-6dbf7458a219")
         .HandleNotificationOpened(HandleNotificationOpened)
         .EndInit();

        OneSignal.inFocusDisplayType = OneSignal.OSInFocusDisplayOption.Notification;
        
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;

        sceneFader = FindObjectOfType<SceneFader>();
    }
    private static void HandleNotificationOpened(OSNotificationOpenedResult result)
    {
    }
    public void TriggerDialogMenu()
    {

        if (PlayerPrefs.GetFloat("DialogMenu") == 0)
        {
            FindObjectOfType<DialogMgr>().StartDialog(dialog);
            Destroy(gameObject, 0.1f);
        }
        else
        {
            sceneFader.FadeTo("levelselect");

        }

    }
    public void TriggerDialogLevel()
    {
       
            FindObjectOfType<DialogMgr>().StartDialog(dialog);
            Destroy(gameObject, 0.1f);
        
    
    }
    
 }



