using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

    Respawn respawn;
    public GameObject enemy;
    public GameObject player;
    public float czas = 2;

    GameManager gm;
    // Use this for initialization
    void Start () {
        StartCoroutine(SpawnEnemy());
        gm = FindObjectOfType<GameManager>();
        respawn = FindObjectOfType<Respawn>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            print("player DETECTED");
            Destroy(gameObject);
            respawn.RandomSpawn();
            gm.scoreCount = gm.scoreCount + 1;
            
        }
    }

       public IEnumerator SpawnEnemy()
       {
        
        print("spawnIn" + czas);
        yield return new WaitForSeconds(czas);
        Instantiate(enemy, respawn.spawnPoints[Random.Range(0, respawn.spawnPoints.Length)].position, Quaternion.identity);
        print("Enemy Spawned!");

    }
   
}
