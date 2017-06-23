using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroyer : MonoBehaviour {

    public GameObject PlatformDestroyPoint;

	// Use this for initialization
	void Start () {

        PlatformDestroyPoint = GameObject.Find("PlatformDestroyPoint");
	}
	
	// Update is called once per frame
	void Update () {
		
        if(transform.position.x < PlatformDestroyPoint.transform.position.x)
        {
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
	}
}
