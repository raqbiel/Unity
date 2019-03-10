using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    public Vector3 pointA;
    public Vector3 pointB;
    public float speed;
    [SerializeField]
    private GameObject platform = null;
    private Vector3 offset;
    // Use this for initialization
    IEnumerator Start()
    {

        while (true)
        {
            yield return StartCoroutine(MoveEnemy(transform, pointA, pointB, speed));
            yield return StartCoroutine(MoveEnemy(transform, pointB, pointA, speed));
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator MoveEnemy(Transform ThisObject, Vector3 startPos, Vector3 endPos, float czas)
    {
        float i = 0f;
        float rate = 1f / czas;
        while (i < 1f)
        {
            i += Time.deltaTime * rate;
            ThisObject.position = Vector3.Lerp(startPos, endPos, i);

            yield return null;
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.name == "Player" && gameObject.tag != "block")
        {

            other.transform.parent = gameObject.transform;
        }
       
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.transform.name == "Player")
        {

            other.transform.parent = null;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
		if (collision.transform.name == "Player" && gameObject.tag != "block")
		{

            collision.transform.parent = gameObject.transform;
		}
    }

	private void OnTriggerExit2D(Collider2D coll){
		if (coll.transform.name == "Player")
		{

            coll.transform.parent = null;
		}
    
	}
}
