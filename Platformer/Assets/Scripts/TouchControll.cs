using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControll : MonoBehaviour {


    private PlayerController thePlayer;
	// Use this for initialization
	void Start () {

        thePlayer = FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LeftArrow()
    {
        thePlayer.Move(-1);
    }
    public void RightArrow()
    {
        thePlayer.Move(1);
    }
    public void UnpressArrow()
    {
        thePlayer.Move(0);
    }
    public void Jump()
    {
        if(thePlayer.isGrounded && thePlayer.OnLadder) { 
        thePlayer.Jump(0);
        }else if(thePlayer.isGrounded && !thePlayer.OnLadder){
        thePlayer.Jump(380);
        }

    }
    public void UpArrow()
    {
        thePlayer.UpDown(1);
    }
    public void DownArrow()
    {
        thePlayer.UpDown(-1);
    }
    public void StopUpDown()
    {
        thePlayer.UpDownStop(0);
    }
}
