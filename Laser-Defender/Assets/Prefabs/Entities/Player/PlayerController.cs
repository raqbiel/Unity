using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class PlayerController : MonoBehaviour
{
    private float speed = 10f;
    private float padding = 1f;
    public float shootSpeed;
    public float fireRate= 0.2f;
    public float health = 250;

    public GameObject yourButton;
    public Image Health;

    public AudioClip smierc, strzal;

    public bool knt = false;
    public bool tnk = false;
   
    public GameObject shoot;
    public bool CoolingDown; 

    float xmin = 0.40f;
    float xmax = 14;

     void Start () {

        yourButton = GameObject.Find("Shot");
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);

        //Player nie ma mozliwosci wyjscia poza obraz camery
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        xmin = leftmost.x + padding;
        xmax = rightmost.x - padding;
    }

    void TaskOnClick()
    {

        Vector3 offset = new Vector3(0, 1, 0);
        GameObject beam = Instantiate(shoot, transform.position + offset, Quaternion.identity) as GameObject;
        NetworkServer.Spawn(shoot);
        beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0, shootSpeed, 0);
        AudioSource.PlayClipAtPoint(strzal, transform.position);
       
    }


    void Update()
    {



          if (Input.GetKeyDown(KeyCode.Space))
             {
            Vector3 offset = new Vector3(0, 1, 0);
            NetworkServer.Spawn(shoot);
            GameObject beam = Instantiate(shoot, transform.position + offset, Quaternion.identity) as GameObject;
            beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0, shootSpeed, 0);
            AudioSource.PlayClipAtPoint(strzal, transform.position);
        }
            

            //poruszanie sie gracza za pomoca buttonow
        if (knt)
        {
            GameObject.Find("Player").transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (tnk)
        {
            GameObject.Find("Player").transform.position += Vector3.right * speed * Time.deltaTime;
        }
        float newX = Mathf.Clamp(transform.position.x, xmin, xmax);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);

    }
    public void downLeft()   {knt = true;}
    public void upLeft()     {knt = false;}
    public void downRight()  {tnk = true;}
    public void upRight()    {tnk = false;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        
        Shoot missile = col.gameObject.GetComponent<Shoot>();
        if (missile)
        {
            bool CoolingDown = true;
            //zadaje dmg
            health -= missile.GetDamage();
            //niszczy rakiete przy trafieniu
            missile.Hit();
            if(CoolingDown == true) { 
            Health.fillAmount -= 0.25f;
            }
            if (health <= 0)
            {
                Destroy(gameObject);
                SceneManager.LoadScene("Start Menu");
            }
        }
    }


}
