using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformUp : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameObject.transform.position += Vector3.up * Time.deltaTime;
            print("platform moved");
        }

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        gameObject.transform.position += Vector3.up * Time.deltaTime;
    }

}

