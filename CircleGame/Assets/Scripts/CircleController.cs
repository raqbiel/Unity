using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CircleController : MonoBehaviour
{

    public float maxSize;
    public float growFactor;
    public float waitTime;
    private bool click;

    public Sprite kwadratPlayer;
    public Sprite trojkatPlayer;
    public Sprite koloPlayer;
    public Sprite rombPlayer;


    private AudioSource audioSource;
    public AudioClip audioClip;

    private Color[] colors = new Color[5];

    public GameObject circle;
    private GameManager gameMgr;

    private void Awake()
    {
        colors[0] = Color.cyan;
        colors[1] = Color.red;
        colors[2] = Color.green;
        colors[3] = Color.yellow;
        colors[4] = Color.magenta;
    }

    void Start()
    {
        gameMgr = FindObjectOfType<GameManager>();
        gameObject.GetComponent<SpriteRenderer>().color = colors[Random.Range(0, colors.Length)];
        StartCoroutine(Scale());
        audioSource = GetComponent<AudioSource>();

    }

    IEnumerator Scale()
    {
        float timer = 0;

        while (true)
        {

            while (maxSize > transform.localScale.x)
            {
                timer += Time.deltaTime;
                transform.localScale += new Vector3(1f, 1f, 1) * Time.deltaTime * growFactor;
                yield return null;
            }
            // reset the timer

            yield return new WaitForSeconds(waitTime);

            timer = 0;
            while (0.05 < transform.localScale.x)
            {
                timer += Time.deltaTime;
                transform.localScale -= new Vector3(1, 1, 1) * Time.deltaTime * growFactor;
                yield return null;
            }

            timer = 0;
            yield return new WaitForSeconds(waitTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Punkt"))
        {
            //print("Collision: enabled");
            click = true;

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Punkt")
        {
            //print("Collision: disble");
            click = false;

        }
    }


    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {

            if (click == true)
            {

                int index = Random.Range(0, 100);
                if (index <= 20 && index >= 10)
                {
                    StartCoroutine(gameMgr.GoodAnimation("GOOD"));
                }else if(index <= 10 && index >= 5 && gameMgr.scoreCount >= 50)
                {
                    StartCoroutine(gameMgr.GoodAnimation("AWESOME!"));
                }
                    print("Click: approved");

                audioSource.PlayOneShot(audioClip);
                gameObject.GetComponent<SpriteRenderer>().color = colors[Random.Range(0, colors.Length)];

                //Count - punkty
                gameMgr.scoreCount += 1;

                    growFactor = Random.Range(0.7f, 1f);
                    if (gameMgr.scoreCount >= 5)
                    {
                    int randomFigure = Random.Range(0, 12);

                    switch (randomFigure)
                    {
                        case 0:
                            gameObject.GetComponent<CircleCollider2D>().offset = new Vector2(-0.06f, 1.62f);
                            circle.GetComponent<CircleCollider2D>().offset = new Vector2(-0.06f, 1.62f);
                            circle.GetComponent<SpriteRenderer>().sprite = koloPlayer;
                            gameObject.GetComponent<SpriteRenderer>().sprite = koloPlayer;
                            break;
                        case 1:
                            gameObject.GetComponent<CircleCollider2D>().offset = new Vector2(-0.06f, 1.13f);
                            circle.GetComponent<CircleCollider2D>().offset = new Vector2(-0.06f, 1.13f);
                            circle.GetComponent<SpriteRenderer>().sprite = kwadratPlayer;
                            gameObject.GetComponent<SpriteRenderer>().sprite = kwadratPlayer;
                            print("Size value: 0.6f");
                            break;
                        case 2:
                            gameObject.GetComponent<CircleCollider2D>().offset = new Vector2(-0.06f, 1.23f);
                            circle.GetComponent<CircleCollider2D>().offset = new Vector2(-0.06f, 1.23f);
                            circle.GetComponent<SpriteRenderer>().sprite = trojkatPlayer;
                            gameObject.GetComponent<SpriteRenderer>().sprite = trojkatPlayer;
                            break;
                        case 3:
                            gameObject.GetComponent<CircleCollider2D>().offset = new Vector2(-0.06f, 1.35f);
                            circle.GetComponent<CircleCollider2D>().offset = new Vector2(-0.06f, 1.35f);
                            circle.GetComponent<SpriteRenderer>().sprite = rombPlayer;
                            gameObject.GetComponent<SpriteRenderer>().sprite = rombPlayer;
                            break;
                    }
                    growFactor = Random.Range(1.2f, 1.5f);
                    waitTime = 0.6f;
                    }
                    if (gameMgr.scoreCount >= 10)
                    {
                    growFactor = Random.Range(1.3f, 1.7f);
                    waitTime = 0.6f;

                    }

                    if (gameMgr.scoreCount >= 25)
                    {

                    growFactor = Random.Range(1.8f, 2.0f);
                    waitTime = 0.6f;
                    }
                    if(gameMgr.scoreCount >= 45)
                    {
                    growFactor = Random.Range(2f, 2.2f);
                    waitTime = 0.4f;
                    }
                    if (gameMgr.scoreCount >= 60)
                    {
                    growFactor = Random.Range(2.5f, 3f);
                    waitTime = 0.4f;
                    }
                    if (gameMgr.scoreCount >= 80)
                    {
                    growFactor = Random.Range(2.8f, 3.3f);
                    waitTime = 0.2f;
                    }
                if (gameMgr.scoreCount >= 100)
                {
                    growFactor = Random.Range(3f, 3.5f);
                    waitTime = 0f;
                }

                int random = Random.Range(0, 5);

                    switch (random)
                    {
                        case 0:
                            circle.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
                            print("Size value: 0.4f");
                            break;
                        case 1:
                            circle.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
                            print("Size value: 0.6f");
                            break;
                        case 2:
                            circle.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
                            print("Size value: 0.8f");
                            break;
                        case 3:
                            circle.transform.localScale = new Vector3(1f, 1f, 1f);
                            print("Size value: 1f");
                            break;
                        case 4:
                            circle.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
                            print("Size value: 1.2f");
                            break;
                        case 5:
                            circle.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
                            print("Size value: 1.5f");
                            break;
                    }

                }
                else
                {
                    print("Click: declined");
                    gameMgr.GameOver();

                }
            }
        }
    }



