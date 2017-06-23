using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMgr : MonoBehaviour {

    public Slider diff_slider;
    public Slider Volume_slider;
    public LevelManager lvlMgr;

    private MusicMenager musicMgr;
	// Use this for initialization
	void Start () {

        musicMgr = GameObject.FindObjectOfType<MusicMenager>();

        Volume_slider.value = PlayerPrefMgr.GetMasterVolume();
        diff_slider.value = PlayerPrefMgr.GetDifficulty();
	}
	
	// Update is called once per frame
	void Update () {

        musicMgr.ChangeVolume(Volume_slider.value);

	}

    public void SaveAndExit()
    {
        PlayerPrefMgr.SetMasterVolume(Volume_slider.value);
        PlayerPrefMgr.SetDifficulty(diff_slider.value);
        lvlMgr.LoadLevel("01StartMenu");
    }

    public void SetDefault()
    {
        Volume_slider.value = 0.5f;
        diff_slider.value = 2f;
    }
}
