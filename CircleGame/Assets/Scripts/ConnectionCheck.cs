using UnityEngine;
using System;
using System.Collections;
using UnityEngine.SceneManagement;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;
using System.Collections.Generic;

public class ConnectionCheck : MonoBehaviour
{

    string toastString;
    string input;
    AndroidJavaObject currentActivity;
    AndroidJavaClass UnityPlayer;
    AndroidJavaObject context;


    void Start()
    {

        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.Activate();

        // Enable line below to enable logging if you are having issues setting up OneSignal. (logLevel, visualLogLevel)
        // OneSignal.SetLogLevel(OneSignal.LOG_LEVEL.INFO, OneSignal.LOG_LEVEL.INFO);

        OneSignal.StartInit("fa202439-9521-4aa6-ae50-49cd7aee3a2f")
          .HandleNotificationOpened(HandleNotificationOpened)
          .EndInit();

        OneSignal.inFocusDisplayType = OneSignal.OSInFocusDisplayOption.Notification;


    }
    private static void HandleNotificationOpened(OSNotificationOpenedResult result)
    {
    }
    void SignIn()
    {
        Social.localUser.Authenticate(success => { });
       
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
            SceneManager.LoadScene("game");
           

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
}