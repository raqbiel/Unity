using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SIMgr : MonoBehaviour {
    //Twitter
    string TWITTER_ADRESS = "http://twitter.com/intent/tweet";
    string TWEET_LANG = "en";
    string textToDisplay = "Enjoy Fun, free games! Challenge yourself or share with friends. Fun and easy to use games.\n https://play.google.com/store/apps/details?id=com.rql.betis";

    //FB
    //App ID
    //string AppID = "9124523422";
    //This link is attached to this post
    //string Link = "https://play.google.com/store/apps/details?id=com.rql.circle";
    //The URL of a picture attached to this post. The Size must be atleat 200px by 200px.
    //string Picture = "http://i-cdn.phonearena.com/images/article/85835-thumb/Google-Pixel-3-codenamed-Bison-to-be-powered-by-Andromeda-OS.jpg";
    //The Caption of the link appears beneath the link name
    //string Caption = "Check out My New Score: ";
    //The Description of the link
   // string Description = "Enjoy Fun, free games! Challenge yourself or share with friends. Fun and easy to use games.";

    /* END OF FACEBOOK VARIABLES */
    // Use this for initialization
    void Start () {
		
	}
	
	public void ShareOnTwitter()
    {
        Application.OpenURL(TWITTER_ADRESS + "?text=" + WWW.EscapeURL(textToDisplay) + "&amp;lang=" + WWW.EscapeURL(TWEET_LANG));
    }
    public void shareScoreOnFacebook()
    {
        Application.OpenURL("https://www.facebook.com/Betis-Adventures-347121099041481");
    }
}
