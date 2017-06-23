using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    private Vector3 ostatniaPozycjaGracza;
    private float dystansRuch;

    public Player player;
	// Use this for initialization
	void Start () {

        player = FindObjectOfType<Player>();
        ostatniaPozycjaGracza = player.transform.position;

    }
	
	// Update is called once per frame
	void Update () {
        dystansRuch = player.transform.position.x - ostatniaPozycjaGracza.x;

        transform.position = new Vector3(transform.position.x + dystansRuch, transform.position.y, transform.position.z);

        ostatniaPozycjaGracza = player.transform.position;

	}
}
