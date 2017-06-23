﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public Transform platformGenerator;
    private Vector3 platformStartPoint;

    public Player player;
    private Vector3 playerStartPoint;

    private PlatformDestroyer[] platformList;

    private ScoreManager scoreManager;

	// Use this for initialization
	void Start () {

        platformStartPoint = platformGenerator.position;
        playerStartPoint = player.transform.position;

        scoreManager = FindObjectOfType<ScoreManager>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RestartGame()
    {
        StartCoroutine("ResetGameCO");

    }

    public IEnumerator ResetGameCO()
    {
        scoreManager.ScoreIncreasing = false;
        player.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        platformList = FindObjectsOfType<PlatformDestroyer>();

        for(int i = 0; i < platformList.Length; i++)
        {
            platformList[i].gameObject.SetActive(false);
        }

        player.transform.position = playerStartPoint;
        platformGenerator.position = platformStartPoint;
        player.gameObject.SetActive(true);

        scoreManager.scoreCount = 0;
        scoreManager.ScoreIncreasing = true;
    }

}
