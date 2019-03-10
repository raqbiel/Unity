using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using admob;
using UnityEngine.SocialPlatforms;


public class scriptsBanner : MonoBehaviour {


  
    // Use this for initialization
    void Start () {


        Admob.Instance().initAdmob("ca-app-pub-4657780191765526/2145664895", "////");
        Admob.Instance().showBannerRelative(AdSize.Banner, AdPosition.BOTTOM_CENTER, 0);

        //tappx request

    }
	
	// Update is called once per frame
	void Update () {

       
    }
}
michal.unity3d@gmail.com	
unity3dgra