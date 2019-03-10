using UnityEngine;
using System;
using System.Collections;
using UnityEngine.SceneManagement;
using GooglePlayGames.BasicApi;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using System.Collections.Generic;

public class ConnectionCheck : MonoBehaviour
{
    public Dialog dialog;
    string toastString;
    string input;
    AndroidJavaObject currentActivity;
    AndroidJavaClass UnityPlayer;
    AndroidJavaObject context;
    SceneFader sceneFader;
    public GameObject googleMenu;
    void Start()
    {
       sceneFader = FindObjectOfType<SceneFader>();
      
       
        // Enable line below to enable logging if you are having issues setting up OneSignal. (logLevel, visualLogLevel)
      /*   OneSignal.SetLogLevel(OneSignal.LOG_LEVEL.INFO, OneSignal.LOG_LEVEL.INFO);

          OneSignal.StartInit("ae8afef7-d391-4141-98f3-03b1b6de2537")
           .HandleNotificationOpened(HandleNotificationOpened)
            .EndInit();

          OneSignal.inFocusDisplayType = OneSignal.OSInFocusDisplayOption.Notification;
          */

    }
    // private static void HandleNotificationOpened(OSNotificationOpenedResult result)
    //  {
    //  }
    void Awake()
    {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.Activate();
    }
    void SignIn()
    {
        Social.localUser.Authenticate(success => {

        });
       
    }

    public void MyShowToastMethod()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            showToastOnUiThread("Check your internet connection");
        }
    }
    void showToastOnUiThread(string toastString)
    {
        AndroidJavaClass UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");

        currentActivity = UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        this.toastString = toastString;

        currentActivity.Call("runOnUiThread", new AndroidJavaRunnable(showToast));
    }

    void showToast()
    {
        Debug.Log("Toast SHOWED");
        AndroidJavaObject context = currentActivity.Call<AndroidJavaObject>("getApplicationContext");
        AndroidJavaClass Toast = new AndroidJavaClass("android.widget.Toast");
        AndroidJavaObject javaString = new AndroidJavaObject("java.lang.String", toastString);
        AndroidJavaObject toast = Toast.CallStatic<AndroidJavaObject>("makeText", context, javaString, Toast.GetStatic<int>("LENGTH_SHORT"));
        toast.Call("show");
    }

    IEnumerator checkInternetConnection(Action<bool> action){
		WWW www = new WWW("http://google.com");
		yield return www;
		if (www.error != null) {
            //action (false);
            //Application.Quit
            MyShowToastMethod();



        } else {

            SignIn();
            googleMenu.SetActive(true);
            /*
            
            if (PlayerPrefs.GetFloat("DialogMenu") == 0)
            {
                FindObjectOfType<DialogMgr>().StartDialog(dialog);
                Destroy(gameObject, 0.1f);
            }
            else
            {
                sceneFader.FadeTo("levelselect");

            }*/
        }
	} 
	public void EnterTheGame(){
		StartCoroutine(checkInternetConnection((isConnected)=>{
            
        }));
	}

    public void ZamknijApke()
    {
        Application.Quit();
    }
    public void ButtonNo()
    {
        googleMenu.SetActive(false);
    }
}