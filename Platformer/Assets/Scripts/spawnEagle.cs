using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEagle : MonoBehaviour {

    GameMgr gameMgr;
    Enemy enemyScr;
    public AudioClip playerWin;
    public PlayerController playerControl;
    // Use this for initialization
    void Start () {
        playerControl = FindObjectOfType<PlayerController>();
        gameMgr = FindObjectOfType<GameMgr>();
        enemyScr = FindObjectOfType<Enemy>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            print("spawnEagle COllision");
            gameMgr.GameOver();
        }
       

        }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "footColider")
        {

            print("foot Colided");
            Destroy(gameObject);
            playerControl.GetComponent<AudioSource>().PlayOneShot(playerWin);
            playerControl.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 400));
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 400));
            GameObject feedback = Instantiate(enemyScr.boom, transform.position, Quaternion.identity) as GameObject;
        }
    }


}
