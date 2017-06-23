using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour {

    public GameObject enemyPrefab;
    public GameObject enemyPrefab1;
    public GameObject enemyBoss;

    public float width = 10f;
    public float height = 5f;
    public float speed = 5f;
    public float spawnDelay = 0.5f;

    private Animator anim;

    bool MoveRight;
    float xmin;
    float xmax;
    private float padding = 1f;
    private bool animQueue;
    public ScoreKeeper scoreKeeper;

    public void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Use this for initialization
    void Start () {
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        xmin = leftmost.x + padding;
        xmax = rightmost.x - padding;
        //Tworzy wave przeciwnikow
        SpawnEnemies();
        
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height, 0));
    }

    // Update is called once per frame
    void Update()
    {
        if (MoveRight)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        // maxymalna odleglosc na lewo i prawo jaka moga osiagnac enemy
        float rightEdgeOfFormation = transform.position.x + (0.3f * width);
        float leftEdgeOfFormation = transform.position.x - (0.3f * width);
        if (leftEdgeOfFormation < xmin)
        {
            MoveRight = true;
        }else if(rightEdgeOfFormation > xmax)
        {
            MoveRight = false;
        }
        //sprawdza czy wszyscy przeciwnicy sa martwi
        if (AllMembersDead())
        {
            if(scoreKeeper.scorepoint == 750 || scoreKeeper.scorepoint == 2650)
            {
                SpawnBoss();
            }
            else { 
            Debug.Log("Pusta Formacja");
            SpawnUntilFull();
            }
        }

    }
    Transform NextFreePosition() {
        foreach (Transform childPositionGameObject in transform){
            if (childPositionGameObject.childCount == 0){
                return childPositionGameObject;
            }
        }
        return null;
    }

    void SpawnEnemies(){

        foreach (Transform child in transform){
            int random;
            random = Random.Range(1, 2);
            if(random == 1) {
               
                GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
                enemy.transform.parent = child;
            }
            else
            {  
                GameObject enemy = Instantiate(enemyPrefab1, child.transform.position, Quaternion.identity) as GameObject;
                enemy.transform.parent = child;
            }
        }
    }
    //Tworzy przeciwnikow tak dlugo az zostanie uzupelniona cala formacja
    void SpawnUntilFull(){
        int random;
        random = Random.Range(1, 5);
        Transform freePosition = NextFreePosition();
        if (random == 1)
        {

            GameObject enemy = Instantiate(enemyPrefab, freePosition.transform.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = freePosition;
        }
        else
        {
            GameObject enemy = Instantiate(enemyPrefab1, freePosition.transform.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = freePosition;
        }
        if (NextFreePosition()) {
            Invoke("SpawnUntilFull", spawnDelay);
         }
    }

    bool AllMembersDead() {
        foreach(Transform childPositionGameObject in transform) {
           if( childPositionGameObject.childCount > 0)
            {
         return false;
            }
        }
        return true;
    }

    void SpawnBoss()
    {
        Transform position = GameObject.Find("Position1").transform;
        {
            GameObject enemy = Instantiate(enemyBoss, position.transform.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = position;
        }
    }
}

