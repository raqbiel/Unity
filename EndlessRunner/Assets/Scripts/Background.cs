using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{

    private Vector3 ostatniaPozycjaGracza;
    private float dystansRuch;

    public Camera camera;
    // Use this for initialization
    void Start()
    {

        camera = FindObjectOfType<Camera>();
        ostatniaPozycjaGracza = camera.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        dystansRuch = camera.transform.position.x - ostatniaPozycjaGracza.x;

        transform.position = new Vector3(transform.position.x + dystansRuch, transform.position.y);

        ostatniaPozycjaGracza = camera.transform.position;

    }
}
