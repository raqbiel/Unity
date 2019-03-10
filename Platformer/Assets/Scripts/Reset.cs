using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour {

	// Use this for initialization
	void Start () {

        
        PlayerPrefs.SetInt("level1lock", 1);
        PlayerPrefs.SetFloat("TotalCherry", 0);
        PlayerPrefs.SetFloat("TotalDiamonds", 0);
        PlayerPrefs.SetFloat("DialogLevel", 0);
        PlayerPrefs.SetFloat("DialogMenu", 0);
        PlayerPrefs.SetFloat("CheckPoint", 0);



    }

    // Update is called once per frame
    void Update () {
		
	}
}
