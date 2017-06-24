
using UnityEngine;

public class Enemy : MonoBehaviour {

    public Transform exitPoint;
    public int target = 0;
    public Transform[] checkPoints;
    public float navigateUpdate;

    private Transform enemy;
    private float navigationTime = 0;
    GameManager gm;

	// Use this for initialization
	void Start () {
        enemy = GetComponent<Transform>();
        gm = FindObjectOfType<GameManager>();
	}


    public void LookAt2D(Transform transform, Vector2 target)
    {
        Vector2 current = transform.position;
        var direction = target - current;
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
    // Update is called once per frame
    void Update () {
       

        if (checkPoints != null)
        {
            
            navigationTime += Time.deltaTime;
            if(navigationTime > navigateUpdate)
            {
                if(target < checkPoints.Length)
                {
                    enemy.position = Vector2.MoveTowards(enemy.position, checkPoints[target].position, navigationTime);
                    LookAt2D(gameObject.transform, checkPoints[target].position);

                }
                else
                {
                    enemy.position = Vector2.MoveTowards(enemy.position, exitPoint.position, navigationTime);
                    LookAt2D(gameObject.transform, exitPoint.position);
                }
                navigationTime = 0;
            }
        }


	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "CheckPoints")
        {
            target += 1;
        }else if(collision.gameObject.tag == "Finish")
        {
            GameManager.Instance.removeEnemyFromScreen();
            print("Object destroyed");
            Destroy(gameObject);
        }
    }
   
}
