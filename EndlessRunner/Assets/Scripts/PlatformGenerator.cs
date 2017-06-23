using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{

    public GameObject[] thePlatform = new GameObject[2];
    public Transform generationPoint;

    private float odlegloscMiedzyPlatformami;
    public float odlegloscMIN;
    public float odlegloscMAX;
    private float dlugoscPlatform;
    private float[] dlugoscPlatformy;

    private float rMIN;
    private float rMAX;
    public Transform maxYPoint;
    private float wysokoscChange;
    public float maxWysokoscChange;

    private int WyborPlatformy;
    // Use this for initialization
    void Start()
    {

        
        dlugoscPlatformy = new float[thePlatform.Length];

        for(int i = 0; i < thePlatform.Length; i++)
        {
            dlugoscPlatformy[i] = thePlatform[i].GetComponent<BoxCollider2D>().size.x;
        }
        rMIN = transform.position.y;
        rMAX = maxYPoint.position.y;

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < thePlatform.Length; i++)
        {
            if (transform.position.x < generationPoint.position.x)
        {
            odlegloscMiedzyPlatformami = Random.Range(odlegloscMIN, odlegloscMAX);

            WyborPlatformy = Random.Range(0, thePlatform.Length);

            wysokoscChange = transform.position.y + Random.Range(maxWysokoscChange, -maxWysokoscChange);
                if(wysokoscChange > rMAX)
                {
                    wysokoscChange = rMAX;

                }else if(wysokoscChange < rMIN)
                {
                    wysokoscChange = rMIN;
                }

            transform.position = new Vector3(transform.position.x + (dlugoscPlatformy[WyborPlatformy] / 2) + odlegloscMiedzyPlatformami, wysokoscChange, transform.position.z);

            Instantiate(thePlatform[WyborPlatformy], transform.position , transform.rotation);
               
            }


        }
    }
}
