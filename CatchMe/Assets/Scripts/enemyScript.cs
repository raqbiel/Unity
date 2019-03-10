using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour {

    public Transform targetPlayer;
    private Transform myTransform;
    Color[] colory = new Color[6];
    private bool playerAlive = true;
    public float enemySpeed;
    GameManager gm;
    private void Awake()
    {
        myTransform = transform;

        colory[0] = Color.cyan;
        colory[1] = Color.red;
        colory[2] = Color.green;
        colory[3] = Color.yellow;
        colory[4] = Color.magenta;
    }
    // Use this for initialization
    void Start() {

        gm = FindObjectOfType<GameManager>();
        gameObject.GetComponent<SpriteRenderer>().material.color = colory[Random.Range(0, colory.Length)];
        targetPlayer = GameObject.FindGameObjectWithTag("Player").transform;
        playerAlive = true;

    }
	
	// Update is called once per frame
	void Update () {
        if (playerAlive == true) {
        transform.position = Vector3.MoveTowards(transform.position, targetPlayer.transform.position, enemySpeed);
        }
        else
        {
            print("No player!");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
         
            gm.PlayerCollided();

        }
    }
}
