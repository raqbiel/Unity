using UnityEngine;
using System.Collections;

public class BossScript : MonoBehaviour
{

    public GameObject projectile;
    public float projectileSpeed = 2;
    //zycie przeciwnika
    public float health = 500;
    public float shootPerSecond = 0.5f;

    public int scoreValue = 150;
    private ScoreKeeper scoreKeeper;

    void Start()
    {
        scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
    }

    void Update()
    {


        float probability = Time.deltaTime * shootPerSecond;
        if (Random.value < probability)
        {
            Fire();
        }
    }

    public void Fire()
    {

        Vector3 startPosition = transform.position + new Vector3(0, -1, 0);
        //tworzy pociski przeciwnikow
        GameObject missile = Instantiate(projectile, startPosition, Quaternion.identity) as GameObject;
        missile.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col);
        Shoot missile = col.gameObject.GetComponent<Shoot>();
        if (missile)
        {
            //zadaje dmg
            health -= missile.GetDamage();
            //niszczy rakiete przy trafieniu
            missile.Hit();
            if (health <= 0)
            {
                Destroy(gameObject);
                scoreKeeper.Score(scoreValue);

            }
        }
    }
}
