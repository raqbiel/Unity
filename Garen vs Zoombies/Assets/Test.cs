using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {

       print (PlayerPrefMgr.GetMasterVolume());
       PlayerPrefMgr.SetMasterVolume(0.3f);
       print (PlayerPrefMgr.GetMasterVolume());


        print(PlayerPrefMgr.IsLevelUnlocked(2));
        PlayerPrefMgr.UnlockLevel(2);
        print(PlayerPrefMgr.IsLevelUnlocked(2));

        print(PlayerPrefMgr.GetDifficulty());
        PlayerPrefMgr.SetDifficulty(2);
        print(PlayerPrefMgr.GetDifficulty());

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
