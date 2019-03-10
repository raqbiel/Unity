using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerav1 : MonoBehaviour
{

    public GameObject player;

    private float deltaX;
    private float cameraY;
    private float cameraZ;
    private float cameraX;

    public float deltaY;

    public Vector2 velocity;
    public float smoothTimeY;
    public float smoothTimeX;

    public float shakeTimer;
    public float shakeAmount;

    // Use this for initialization
    void Start()
    {
        deltaX = Mathf.Abs(player.transform.position.x - transform.position.x);
        cameraY = transform.position.y;
        cameraZ = transform.position.z;
    
    }
    /*public void FixedUpdate()
    {
        float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
        float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);

        transform.position = new Vector3(posX, posY, transform.position.z);
    }*/

    // Update is called once per frame
    void Update()
    {
        yFollow();
        SetCameraPosition();

        if(shakeTimer >= 0)
        {
            Vector2 ShakePos = Random.insideUnitCircle * shakeAmount;
            transform.position = new Vector3(transform.position.x + ShakePos.x, transform.position.y + ShakePos.y, transform.position.z);
            shakeTimer -= Time.deltaTime;
        
        }
    }

    void SetCameraPosition()
    {
        transform.position = new Vector3(player.transform.position.x + deltaX, cameraY, cameraZ);
    }

    void yFollow()
    {
        if (player.transform.position.y < transform.position.y - deltaY)
        {
            cameraY = player.transform.position.y + deltaY;
        }
        else if (player.transform.position.y > transform.position.y + deltaY)
        {
            cameraY = player.transform.position.y - deltaY;
        }


    }
    public void ShakeCamera(float shakePwr, float shakeDur)
    {

        shakeAmount = shakePwr;
        shakeTimer = shakeDur;
    }
  
}