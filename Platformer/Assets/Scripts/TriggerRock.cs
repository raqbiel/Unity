using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerRock : MonoBehaviour {

    public GameObject Rock;
    public GameObject cameraShake;
    public AudioClip rockClip;
    public AudioClip backClip;
    public GameObject Sciana;
    string sceneName;

    private void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        Sciana.SetActive(false);
    }
    void Update()
    {
        
        GameObject rotateRorkc = GameObject.Find("rock_0");
        if(sceneName == "level05") { 
        rotateRorkc.transform.Rotate(0, 0, -3f);
        }
        if (sceneName == "level01")
        {
        rotateRorkc.transform.Rotate(0, 0, 3f);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && gameObject.name == "TriggerProc")
        {
            FindObjectOfType<Camerav1>().GetComponent<AudioSource>().clip = rockClip;
            FindObjectOfType<Camerav1>().GetComponent<AudioSource>().Play();
            FindObjectOfType<Camerav1>().ShakeCamera(0.1f, 1f);
            Rock.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            Sciana.SetActive(true);
           
        }
        if (collision.gameObject.name == "Player" && gameObject.name == "triggerlevelone")
        {
           
            FindObjectOfType<Camerav1>().ShakeCamera(0.1f, 1f);
            Rock.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            Rock.transform.Rotate(0, 0, 3f);



        }
        if (collision.gameObject.name == "Player" && gameObject.name == "triggermusic")
        {
            FindObjectOfType<Camerav1>().GetComponent<AudioSource>().clip = backClip;
            FindObjectOfType<Camerav1>().GetComponent<AudioSource>().Play();
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        FindObjectOfType<Camerav1>().ShakeCamera(0f, 0f);
        if (collision.gameObject.name == "Player" && gameObject.name == "triggermusic")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.name == "Player" && gameObject.name == "triggerlevelone")
        {
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
   


}
