using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour {
    public Vector3[] spawnPoints;
    public GameObject objectSpawn;
    public float timeToDestroy;

	// Use this for initialization
	void Start () {
        InvokeRepeating("spawnWave", 2f, 1f);

	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void spawnWave()
    {
        for(int i = 0; i < 1; i++)
        {

            GameObject spawnObjects = Instantiate(objectSpawn, spawnPoints[Random.Range(0, spawnPoints.Length)], transform.rotation) as GameObject;
            Destroy(spawnObjects, timeToDestroy);


        }
    }
}
