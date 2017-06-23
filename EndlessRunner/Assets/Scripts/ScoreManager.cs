using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public Text scoreText;
    public Text highScore;

    public float scoreCount;
    public float highScoreCount;

    public float pointsPerSecond;

    public bool ScoreIncreasing;

	// Use this for initialization
	void Start () {
		if(PlayerPrefs.GetFloat("HighScore") != 0)
        {
            highScoreCount = PlayerPrefs.GetFloat("HighScore");
        }
	}
	
	// Update is called once per frame
	void Update () {

        if (ScoreIncreasing) { 
                 scoreCount += pointsPerSecond * Time.deltaTime;
        }
        if (scoreCount > highScoreCount)
        {
            highScoreCount = scoreCount;
            PlayerPrefs.SetFloat("HighScore", highScoreCount);
        }

        scoreText.text = "Score: " + Mathf.Round(scoreCount);
        highScore.text = "High Score: " + Mathf.Round(highScoreCount);

	}
}
