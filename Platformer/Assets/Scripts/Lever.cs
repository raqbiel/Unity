using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lever : MonoBehaviour {

    public Sprite sprite;
    public bool keyGot;
    private AudioSource levarSource;
    public AudioClip clipLever;
    string sceneName;
    // Use this for initialization
    void Start () {
        keyGot = false;
        levarSource = GetComponent<AudioSource>();

        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
    }
	
	// Update is called once per frame
	void Update () {
		
       

	}

     void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player"  && sceneName != "level07")
        {
            levarSource.PlayOneShot(clipLever);
            gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
            keyGot = true;
        }
     
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "helpPlayer" && sceneName == "level07")
        {
            StartCoroutine(lever());
        }
    }
    IEnumerator lever()
    {
       
        gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
        GameObject.Find("platformMove").transform.position = Vector2.MoveTowards(GameObject.Find("platformMove").transform.position, new Vector2(617.12f, 129.55f), 0.1f);
        yield return new WaitForSeconds(3f);
        BoxCollider2D[] myColliders = GameObject.Find("helpPlayer").GetComponentsInChildren<BoxCollider2D>();
        foreach (BoxCollider2D bc in myColliders) bc.enabled = false;
        GameObject.Find("helpPlayer").GetComponent<Rigidbody2D>().isKinematic = true;
    }
}
