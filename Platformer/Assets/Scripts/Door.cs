using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    private AudioSource audioSrc;
    public AudioClip audioClip;

    public Transform[] doorEnter;
    public bool playerIn;
    // Use this for initialization
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        audioSrc.PlayOneShot(audioClip);
        if (collision.gameObject.name == "Player" && gameObject.name == "door")
            collision.transform.position = doorEnter[1].transform.position;
            

        if (collision.gameObject.name == "Player" && gameObject.name == "door2")
            collision.transform.position = doorEnter[0].transform.position;
           




    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && gameObject.name == "door2")
        {
            playerIn = false;
        }
    }
}

