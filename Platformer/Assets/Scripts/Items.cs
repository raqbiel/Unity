using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour {



    public Animator itemAnim;
    public GameObject wisnia;
    GameMgr gameMgr;


	// Use this for initialization
	void Start () {

        gameMgr = FindObjectOfType<GameMgr>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player") {
        Destroy(gameObject);
        GameObject feedback = Instantiate(wisnia, transform.position, Quaternion.identity) as GameObject;
        if(gameObject.tag == "wisnia") {
        gameMgr.cherryCount += 1;
        gameMgr.totalcherry = gameMgr.totalcherry + 1;

        }
        if(gameObject.tag == "diamond")
        {
        gameMgr.diamondCount += 1;
        gameMgr.totaldiamonds = gameMgr.totaldiamonds + 1;
        }

        Destroy(feedback, 1f);


        }
    }
}
