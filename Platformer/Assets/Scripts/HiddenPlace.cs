using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenPlace : MonoBehaviour {

    [SerializeField]
    private GameObject onCave;
    Lever lever;
    public GameObject nokeySprite;
    //SOUND/////
    private AudioSource audioSrc;
    public AudioClip clip;
	// Use this for initialization
	void Start () {
        lever = FindObjectOfType<Lever>();
        nokeySprite.SetActive(false);
        audioSrc = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player" && lever.keyGot == true && gameObject.name != "triggerDoorNo") { 
        onCave.SetActive(false);
        audioSrc.PlayOneShot(clip);

        }
        else if(collision.gameObject.name == "Player" && lever.keyGot == false)
        {
            nokeySprite.SetActive(true);
            audioSrc.PlayOneShot(clip);
        }
        if (collision.gameObject.name == "Player" && lever.keyGot == true && gameObject.name == "triggerDoorNo")
        {
            onCave.SetActive(false);
        }
    }
   public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            onCave.SetActive(true);
            
        }
        if (collision.gameObject.name == "Player" && gameObject.name == "triggerDoorNo" && lever.keyGot == true)
        {
            onCave.SetActive(false);

        }
        if (collision.gameObject.name == "Player" && lever.keyGot == false || lever.keyGot == true)
        {
            nokeySprite.SetActive(false);
        }
      
    }
}
