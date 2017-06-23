using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

    public int scorepoint = 0;
    public Text myText;
   

    public void Score(int points) {
        Debug.Log("Score points");
         scorepoint += points;
         myText.text = scorepoint.ToString();
    }

    void Reset()
    {
        scorepoint = 0;
        myText.text = scorepoint.ToString();
    }

    void Start()
    {
        GetComponent<Text>();
    }
}
