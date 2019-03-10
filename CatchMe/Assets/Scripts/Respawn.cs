using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {

    public GameObject prefab;
    public Transform[] spawnPoints;
    // Use this for initialization

    void Start()
    {

        RandomSpawn();


    }
	
	// Update is called once per frame
	void Update () {

       

	}

    public void RandomSpawn()
    {

        for (int x = 0; x < 1; x++)
        {

            Instantiate(prefab, spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position, Quaternion.identity);
            
        }
    }
}
