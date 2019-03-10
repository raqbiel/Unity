/**
 * Wszystkie skrypty dla gry brick breaker są
 * Wykonane przeze mnie i objęte prawem autorskim.
 * Development dla android devices.
 *
 * Copyright (C) 2016  Paweł Kryspin 
 * 
*/

using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
public class Bricks : MonoBehaviour {

    private int timesHit;
    private bool isBreakable;

    static public Bricks instance;
    public GameObject smoke;
    public AudioClip crack;

    public Sprite[] hitSprites;
    public static int brickCount = 0;
    public GameObject diamondsSpawn;


    // Use this for initialization
    void Start () {

        instance = this;

        isBreakable = (this.tag == "Breakable");
        //sledzi sciezke rozbitych klockow
        if (isBreakable){
        brickCount++;
        print(brickCount);
        }
        timesHit = 0;
       
        
    }
	
	// Update is called once per frame
	void Update () {
    
    }

  

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.name == "footColider") { 
        AudioSource.PlayClipAtPoint(crack, transform.position);
        // Ustawiamy isBreakable do obiektu z tagiem "Breakable" 
        // jezeli obiekt ma tag Breakable zniszczy go wykona metode HandleHits()    
        if (isBreakable) {
            HandleHits();
        }
       }
    }

    void HandleHits()
    {
        timesHit++;
        // max hit ma o 1 wiecej od hitSprites
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits){
            brickCount--;
            GameObject dym = Instantiate(smoke, transform.position, Quaternion.identity) as GameObject;  
            Destroy(gameObject);

            int index = UnityEngine.Random.Range(0, 3);
            if(index == 0)
            {
                GameObject diamonds = Instantiate(diamondsSpawn, transform.position, Quaternion.identity) as GameObject;

            }
            else
            {

            }
        }
        else
        {
            LoadSprites();
        }
    }

    void LoadSprites()
    {
        //ładuje kolejne sprite zepsutych blockow
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex])
        { 
        this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
    }
   
    
}
