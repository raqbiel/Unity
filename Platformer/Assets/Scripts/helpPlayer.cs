using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class helpPlayer : MonoBehaviour {

    [SerializeField]
    public bool isGrounded;
    [SerializeField]
    private Transform foot1;
    [SerializeField]
    private Transform foot2;
    [SerializeField]
    private LayerMask onlyGroundMask;
    public Rigidbody2D myRigibody;
    public Animator myAnimator;
    bool rusz;
    private bool facingRight;
    public GameObject diamondDialog;
    PlayerController playerControl;
    // Use this for initialization
    void Start () {
        rusz = false;
        myRigibody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        playerControl = FindObjectOfType<PlayerController>();
    }

    private void FixedUpdate()
    {
        myAnimator.SetBool("grounded", isGrounded);
       // myAnimator.SetFloat("velocityY", myRigibody.velocity.y);
      

    }
    // Update is called once per frame
    void Update () {

        if (rusz) { 
        GameObject.Find("helpPlayer").transform.position += Vector3.right * Time.deltaTime;
        myAnimator.SetFloat("speed", Mathf.Abs(2));
        }




        isGrounded = Physics2D.OverlapArea(foot1.position, foot2.position, onlyGroundMask);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && playerControl.bigGem)
        {
            print("dziala");
            rusz = true;


        }
        else if(collision.gameObject.name == "Player" && !playerControl.bigGem)
        {
            diamondDialog.SetActive(true);
        }
        if (collision.gameObject.name == "crank-up")
        {
            rusz = false;
            print("dupa");
            myAnimator.SetFloat("speed", Mathf.Abs(1));
            GameObject.Find("helpPlayer").transform.position = GameObject.Find("helpPlayer").transform.position;
          
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !playerControl.bigGem)
        {
            diamondDialog.SetActive(false);
        }
        if(collision.gameObject.name == "Player" && playerControl.bigGem)
        {
            diamondDialog.SetActive(false);
        }
    }
}
