using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallObjects : MonoBehaviour {

    [SerializeField]
    private AudioClip clipSound;
    private AudioSource source;

	// Use this for initialization
	void Start () {

        source = GetComponent<AudioSource>();
       
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        StartCoroutine(fallObject(0.2f));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(fallObject(0.1f));
    }

    IEnumerator fallObject(float timer) {

        yield return new WaitForSeconds(timer);
        source.PlayOneShot(clipSound);
        this.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
     

    }
}
