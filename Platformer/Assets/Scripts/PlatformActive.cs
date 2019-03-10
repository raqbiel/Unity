using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformActive : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" || collision.gameObject.name == "Box")
        {
            Debug.Log("Player stand");
            GameObject.Find("platformActive").transform.position = Vector2.MoveTowards(GameObject.Find("platformActive").transform.position, new Vector2(114f, -13.59f), 0.2f);
            GameObject.Find("doorToMove").transform.position = Vector2.MoveTowards(GameObject.Find("doorToMove").transform.position, new Vector2(117.48f, -9.86f), 0.1f);
           
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.name == "Player" || collision.gameObject.name == "Box")
        {
            Debug.Log("Player stand");
            GameObject.Find("platformActive").transform.position = Vector2.MoveTowards(GameObject.Find("platformActive").transform.position, new Vector2(114f, -13.41f), 0.2f);
            GameObject.Find("doorToMove").transform.position = Vector2.MoveTowards(GameObject.Find("doorToMove").transform.position, new Vector2(117.48f, -11.86132f), 1f);
        }
    }

}
