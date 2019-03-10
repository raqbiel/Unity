using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guide : MonoBehaviour {

    public GameObject guideFirst;
    public GameObject guideSecond;
    public GameObject guideThird;

    private void Start()
    {
        guideFirst.SetActive(false);
        guideSecond.SetActive(false);
        guideThird.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(gameObject.name == "GUIDETrigger1" && collision.gameObject.name == "Player")
        {
            guideFirst.SetActive(true);
        }
        if (gameObject.name == "GUIDETrigger2" && collision.gameObject.name == "Player")
        {
            guideSecond.SetActive(true);
        }
        if (gameObject.name == "GUIDETrigger3" && collision.gameObject.name == "Player")
        {
            guideThird.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
       if(gameObject.name == "GUIDETrigger1" && collision.gameObject.name == "Player")
        {
            guideFirst.SetActive(false);
        }
        if (gameObject.name == "GUIDETrigger2" && collision.gameObject.name == "Player")
        {
            guideSecond.SetActive(false);
        }
        if (gameObject.name == "GUIDETrigger3" && collision.gameObject.name == "Player")
        {
            guideThird.SetActive(false);
        }
    }
}
