using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public RigidbodyConstraints2D originalCon;

    public GameObject cameraFollow;
    Enemy enemyScript;

    int fallDmg;
    public float downValue;
    public Rigidbody2D myRigibody;
    public Animator myAnimator;

    private float movementSpeed = 7f;
    private bool facingRight;
    public float timer;

    [SerializeField]
    public bool isGrounded;
    [SerializeField]
    private Transform foot1;
    [SerializeField]
    private Transform foot2;
    [SerializeField]
    private LayerMask onlyGroundMask;
    [SerializeField]
    private float jumpForce;

    private bool canJump;
    public float maxTime = 0.1f;
    private AudioSource jumpSound;
    public AudioClip jump;

    public AudioSource coinSound;
    public AudioClip wisniaSound;
    public AudioClip enemyDeath;
    public AudioClip hurtPlayer;

    private float climbSpeed = 4f;
    public float knockback;
    public float knockbackLength;
    public float knockbackCount;
    public bool knockFromRight;
    private float moveVelocity;

    public float direction;
    public float vert;
    private bool move;

    [SerializeField]
    private GameObject btnUp;
    [SerializeField]
    private GameObject btnDown;

    GameMgr gameMgr;

    public bool OnLadder;
    bool onKladka;

    [SerializeField]
    public bool isLadder;
    [SerializeField]
    private Transform head;
    [SerializeField]
    private Transform head1;
    [SerializeField]
    private LayerMask onlyLadderMask;

    public Quaternion originalRotationValue;
    float rotationResetSpeed = 0.1f;
    public bool bigGem;

    private void Awake()
    {
     
        originalCon = myRigibody.constraints;
    }
    // Use this for initialization
    void Start()
    {

        bigGem = false;
        enemyScript = FindObjectOfType<Enemy>();
        gameMgr = FindObjectOfType<GameMgr>();
        coinSound = GetComponent<AudioSource>();

        jumpSound = GetComponent<AudioSource>();
        myRigibody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        facingRight = true;
        OnLadder = false;

        originalRotationValue = transform.rotation;
    }





    private void FixedUpdate()
    {

        if (isGrounded && !isLadder && OnLadder)
        {
           
            myRigibody.constraints = RigidbodyConstraints2D.FreezePositionY;



        }
        float horiznotal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (vert <= -1)
        {
            myRigibody.constraints = originalCon;
          
        }
        if (move)
        {
            HandleMovement(direction, vert);
            Flip(direction);

        }
        else
        {
            HandleMovement(horiznotal, vertical);
            Flip(horiznotal);
        }
    }
    // Update is called once per frame
    void Update()
    {

        myAnimator.SetBool("grounded", isGrounded);
        myAnimator.SetFloat("velocityY", myRigibody.velocity.y);

        isGrounded = Physics2D.OverlapArea(foot1.position, foot2.position, onlyGroundMask);
        isLadder = Physics2D.OverlapArea(head.position, head1.position, onlyLadderMask);

       

        // moveVelocity = movementSpeed * Input.GetAxis("Horizontal");

      

       if(isGrounded && isLadder && !OnLadder)
        {
            btnUp.SetActive(true);
            btnDown.SetActive(false);
            OnLadder = true;
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        }
        if (isGrounded && !OnLadder)
        {
            btnUp.SetActive(false);
            btnDown.SetActive(false);
            OnLadder = false;
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 1.8f;
        }

        if (isGrounded && Input.GetKeyDown(KeyCode.W))
        {
            jumpSound.PlayOneShot(jump);
            timer = 0;
            canJump = true;
            myRigibody.AddForce(new Vector2(0, jumpForce));
        }
        else if (Input.GetKey(KeyCode.W) && canJump && timer < maxTime)
        {
            timer += Time.deltaTime;
            myRigibody.AddForce(new Vector2(0, jumpForce));
        }
        else
        {
            canJump = false;
        }
        if (isGrounded)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, originalRotationValue, Time.time * rotationResetSpeed);
        }

    }


    public void HandleMovement(float horizontal, float vertical)

    {
        if (knockbackCount <= 0)
        {
            myRigibody.velocity = new Vector2(horizontal * movementSpeed, myRigibody.velocity.y);
            myAnimator.SetFloat("speed", Mathf.Abs(horizontal));
            myAnimator.SetBool("hurt", false);
            knockbackCount = 0;
        }
        else
        {
            if (knockFromRight)
                myRigibody.velocity = new Vector2(-knockback, knockback);
            if (!knockFromRight)
                myRigibody.velocity = new Vector2(knockback, knockback);
            knockbackCount -= Time.deltaTime;

        }

    }

    private void Flip(float horizontal)
    {
        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            facingRight = !facingRight;

            Vector3 theScale = transform.localScale;

            theScale.x *= -1;

            transform.localScale = theScale;

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.tag == "Life")
        {
            Destroy(collision.gameObject, 1f);
            coinSound.PlayOneShot(wisniaSound);
            gameMgr.lifeCount = gameMgr.lifeCount + 1;
        }
        /* if (Mathf.Abs(collision.relativeVelocity.y) > 10f)
         {
             fallDmg = (int)((0.1f) * Mathf.Abs(collision.relativeVelocity.y) - 3f);
             print("Getting DMG");
         }*/
        if (collision.gameObject.tag == "wisnia" || collision.gameObject.tag == "diamond")
        {
            coinSound.PlayOneShot(wisniaSound);
        }
        if(collision.gameObject.name == "BigGem")
        {
            coinSound.PlayOneShot(wisniaSound);
            bigGem = true;
        }
        if (collision.gameObject.tag == "block")
        {
            print("co jest kurwa");
            print(collision.gameObject.name);
            gameMgr.GameOver();
        }
        if (collision.gameObject.tag == "spikes")
        {
            gameMgr.GameOver();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "ladder")
        {

            vert = 0;
            btnUp.SetActive(true);
            btnDown.SetActive(true);
            OnLadder = true;
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;

        }
        if (collision.gameObject.tag == "ladder" && !isGrounded)
        {
            myRigibody.velocity = new Vector2(direction * 0f, vert * 0f);
            myAnimator.SetBool("NoLadder", false);
            myAnimator.SetBool("ladder", true);
        }

        if (collision.gameObject.tag == "Die")
        {
            cameraFollow.GetComponent<Camerav1>().enabled = false;

        }
        if (collision.gameObject.name == "ShowMenu")
        {
            gameMgr.GameOver();
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {

     

        if (collision.gameObject.tag == "ladder" )
        {
            
            vert = 0;
            btnUp.SetActive(false);
            btnDown.SetActive(false);
            OnLadder = false;
            myAnimator.SetBool("ladder", false);
            myAnimator.SetBool("NoLadder", false);
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 1.8f;  
            myRigibody.velocity = new Vector2(direction * 0f, vert * 0f);
            myRigibody.constraints = originalCon;

        }
        


    }

    #region SterowanieTouch
    public void Move(float direction)
    {

        this.direction = direction;
        this.move = true;
    }
    public void StopMove(float direction)
    {

        this.direction = direction;
        this.move = false;
    }


    public GameObject FindClosestLadder()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("ladder");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }

    public void UpDown(float vert)
    {
       

        this.move = true;
        this.vert = vert;
        if (OnLadder)   
            if (vert > 0 || vert < 0)
            {
                FindClosestLadder();
                myAnimator.SetBool("NoLadder", false);
                myRigibody.velocity = new Vector2(direction * climbSpeed, vert * climbSpeed);
                myAnimator.SetBool("ladder", true);
                
               gameObject.transform.position = new Vector3(FindClosestLadder().transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
              

            }
      
      
      
            
    }

    public void UpDownStop(float vert)
    {
        
        this.vert = 0;
        this.move = false;
        myAnimator.SetBool("NoLadder", true);
        myRigibody.velocity = new Vector2(direction * 0f, vert * 0f);
    }

    public void Jump(float jumpHigh)
    {
        if (isGrounded)
        {
            jumpSound.PlayOneShot(jump);
            canJump = true;
            myRigibody.AddForce(new Vector2(0, jumpHigh));
        }
        else { 
            canJump = false;
            
        }
        
     
    }
    #endregion
}
