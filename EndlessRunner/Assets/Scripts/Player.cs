using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float speed = 5;
    public float jump = 10;
    public Rigidbody2D rb;

    public float speedMulti;

    public float speedIncreaseKm;
    private float speedKmCount;


    private float jumpTimerCounter;
    public float jumpTime;

    public bool isGrounded;
    public LayerMask whatIsGround;
    public Transform groundCheck;
    public float groundCheckRadius;

    public AudioClip skok;


    private Collider2D myCollider;
	// Use this for initialization
	void Start () {

        rb = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();

        jumpTimerCounter = jumpTime;


	}
	
	// Update is called once per frame
	void Update () {

        // isGrounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        if(transform.position.x > speedKmCount)
        {
            speedKmCount += speedIncreaseKm;

            speedIncreaseKm = speedIncreaseKm * speedMulti;
            speed = speed * speedMulti;

            speedKmCount = speedIncreaseKm;

        }

        rb.velocity = new Vector2(speed, rb.velocity.y);

        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            AudioSource.PlayClipAtPoint(skok, transform.position);
            if (isGrounded) { 
                 rb.velocity = new Vector2(rb.velocity.x, jump);
                AudioSource.PlayClipAtPoint(skok, transform.position);

            }

        }

        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
        {
            if(jumpTimerCounter > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, jump);
                jumpTimerCounter -= Time.deltaTime;
                
            }
        }


        if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0))
        {
            jumpTimerCounter = 0;
            
        }
        if (isGrounded)
        {
            jumpTimerCounter = jumpTime;

        }
    }

}
