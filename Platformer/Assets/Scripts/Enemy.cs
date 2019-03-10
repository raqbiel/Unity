using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameMgr gameMgr;


    public AudioSource hitPlayer;
    [SerializeField]
    public AudioClip playerHit;
    [SerializeField]
    public AudioClip playerWin;
    public GameObject boom;
    public Vector3 pointA;
    public Vector3 pointB;
    public PlayerController playerControl;
    public float enemySpeed;
    // Use this for initialization

    private void Awake()
    {
        playerControl = FindObjectOfType<PlayerController>();
    }
    IEnumerator Start()
    {
        gameMgr = FindObjectOfType<GameMgr>();
        hitPlayer = GetComponent<AudioSource>();
        while (true)
        {
            yield return StartCoroutine(MoveEnemy(transform, pointA, pointB, enemySpeed));
            yield return StartCoroutine(MoveEnemy(transform, pointB, pointA, enemySpeed));
        }

    }

    // Update is called once per frame
    void Update()
    {
    

        if (gameObject.transform.position == pointA && gameObject.tag == "Opos")
        {
        
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        if (gameObject.transform.position == pointB)
        {
          
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
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

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.name == "footColider")
        {
            var player = collision.GetComponent<PlayerController>();
            player = FindObjectOfType<PlayerController>();
            print("foot Colided");
            Destroy(gameObject);
           playerControl. myRigibody.AddForce(new Vector2(0, 300f));
            playerControl.GetComponent<AudioSource>().PlayOneShot(playerWin);
            GameObject feedback = Instantiate(boom, transform.position, Quaternion.identity) as GameObject;
           

         
        }
    }
   private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            playerControl.myAnimator.SetBool("hurt", false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            print("Player hit");
            gameMgr.lifeCount -= 1;
            playerControl.knockbackCount = playerControl.knockbackLength;
            playerControl.myAnimator.SetBool("hurt", true);
            hitPlayer.PlayOneShot(playerHit);

            if (collision.transform.position.x < transform.position.x)
            {
                playerControl.knockFromRight = true;

            }
            else
            {
                playerControl.knockFromRight = false;
            }
        
        }
      
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            playerControl.myAnimator.SetBool("hurt", false);
        }
    }
}
