using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_AI : MonoBehaviour
{
    public BoxCollider2D houseColider;
    public BoxCollider2D[] myColliders;
    LevelLoader levelloader;
    PlayerController player;
    public GameObject TouchControl;
    public Dialog dialog;
    public Dialog dialog1;
    public Transform[] spawnPoints;
    [SerializeField]
    private float timer;
    public GameObject eagles;
    public GameObject opos;
    public Transform[] holesright;
    public Transform[] holesleft;
    public Transform[] holesup;
    public AudioClip bossAudio;
    public Transform oposHoleRight;
    public Transform oposHoleLeft;
    // Use this for initialization
    GameMgr gameMgr;

    void Awake()
    {
        player = FindObjectOfType<PlayerController>();
        levelloader = FindObjectOfType<LevelLoader>();
        gameMgr = FindObjectOfType<GameMgr>();
    }
    void Start()
    {
        timer = 0;
        levelloader.playerIn = false;
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            GameObject cameraSound = GameObject.Find("Main Camera");
            cameraSound.GetComponent<AudioSource>().clip = bossAudio;
            cameraSound.GetComponent<AudioSource>().Play();
            player.Move(0);
            FindObjectOfType<DialogMgr>().StartDialog(dialog);
            TouchControl.SetActive(false);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            foreach (BoxCollider2D bc in myColliders) bc.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(levelloader.playerIn == true)
        {
            houseColider.enabled = true;
        }


    }



    public IEnumerator boss()
    {

        while (transform.position != spawnPoints[0].position)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(spawnPoints[0].position.x, spawnPoints[0].position.y), 0.1f);
            yield return null;
        }

      
        yield return new WaitForSeconds(2f);


        int i = 0;
        while (i < 12)
        {
           
            GameObject shots = Instantiate(eagles, holesright[Random.Range(0, 2)].position, Quaternion.identity) as GameObject;
            shots.GetComponent<Rigidbody2D>().velocity = Vector2.left * 6f;
            GameObject oposy = Instantiate(opos, oposHoleRight.position, Quaternion.identity) as GameObject;
            oposy.GetComponent<Rigidbody2D>().velocity = Vector2.left * 6f;
            Destroy(shots, 10f);
            Destroy(oposy, 10f);

            i++;
            yield return new WaitForSeconds(1.5f);
        }


        while (transform.position != spawnPoints[1].position)
        {
            transform.position = Vector2.MoveTowards(transform.position, spawnPoints[1].position, 0.1f);
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            yield return null;
        }
        //transform.localScale = new Vector2(-1, 1);
        yield return new WaitForSeconds(2f);

        int x = 0;
        while (x < 16)
        {
            GameObject shots = Instantiate(eagles, holesleft[Random.Range(0, 2)].position, Quaternion.identity) as GameObject;
            shots.GetComponent<Rigidbody2D>().velocity = Vector2.right * 7f;
            shots.GetComponent<SpriteRenderer>().flipX = true;
            GameObject oposy = Instantiate(opos, oposHoleRight.position, Quaternion.identity) as GameObject;
            oposy.GetComponent<Rigidbody2D>().velocity = Vector2.left * 7f;
            Destroy(shots, 10f);
            Destroy(oposy, 10f);

            x++;
            yield return new WaitForSeconds(1.5f);
        }

        while (transform.position != spawnPoints[2].position)
        {
            transform.position = Vector2.MoveTowards(transform.position, spawnPoints[2].position, 0.1f);
            gameObject.GetComponent<SpriteRenderer>().flipX = true;

            yield return null;
        }
        //transform.localScale = new Vector2(-1, 1);
        yield return new WaitForSeconds(2f);

        int y = 0;
        while (y < 20)
        {
            GameObject shots = Instantiate(eagles, holesup[Random.Range(0, 8)].position, Quaternion.identity) as GameObject;
            shots.GetComponent<Rigidbody2D>().velocity = Vector2.down * 7f;
            GameObject oposy = Instantiate(opos, oposHoleLeft.position, Quaternion.identity) as GameObject;
            oposy.GetComponent<Rigidbody2D>().velocity = Vector2.right * 5f;
            oposy.GetComponent<SpriteRenderer>().flipX = true;
            Destroy(shots, 10f);
            Destroy(oposy, 10f);

            y++;
            yield return new WaitForSeconds(1.5f);
        }


        while (transform.position != spawnPoints[3].position)
        {
            transform.position = Vector2.MoveTowards(transform.position, spawnPoints[3].position, 0.1f);
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            yield return null;
        }
        if(transform.position == spawnPoints[3].position)
        {
            TouchControl.SetActive(false);
            FindObjectOfType<DialogMgr>().StartDialog(dialog1);
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            eagles.GetComponent<SpriteRenderer>().enabled = false;
            eagles.GetComponent<BoxCollider2D>().enabled = false;
            foreach (BoxCollider2D bc in myColliders) bc.enabled = false;
            StopAllCoroutines();
         
     }

           
    }
        
}
   
