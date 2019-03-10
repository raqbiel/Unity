using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelSelector : MonoBehaviour {

    public string[] levelTags;
    public bool[] levelUnlocked;
    public Button[] buttons;
    //public GameObject[] locks;

	// Use this for initialization
	void Start () {
		


        for(int i = 0; i < levelTags.Length; i++)
        {
            //buttony interactable set to false;
          //  PlayerPrefs.SetInt(levelTags[i],0);

            if (PlayerPrefs.GetInt(levelTags[i]) == null)
            {
                levelUnlocked[i] = false;
            }else if(PlayerPrefs.GetInt(levelTags[i]) == 0)
            {
                levelUnlocked[i] = false;
            }
            else
            {
                levelUnlocked[i] = true;
            }
            if (levelUnlocked[i])
            {
                // locks[i].SetActive(false);
                buttons[i].GetComponent<Button>().interactable = true;
            }
        }

	}
	
	// Update is called once per frame
	void Update () {
		

	}
}
