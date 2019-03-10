using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using admob;
using UnityEngine.SocialPlatforms;


public class scriptsBanner : MonoBehaviour {


  
    // Use this for initialization
    void Start () {

        Admob.Instance().loadInterstitial();
        Admob.Instance().initAdmob("ca-app-pub-4657780191765526/3444571285", "ca-app-pub-4657780191765526/7738684292");
        Admob.Instance().showBannerRelative(AdSize.myBanner, AdPosition.TOP_CENTER, 0);

        //tappx request

    }
	
	// Update is called once per frame
	void Update () {

       
    }
}
