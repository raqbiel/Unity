using UnityEngine;
using System.Collections;


public class CameraScriptSecond : MonoBehaviour
{

[SerializeField]
private float xMax;

[SerializeField]
private float yMax;

[SerializeField]
private float xMin;

[SerializeField]
private float yMin;

[SerializeField]
private float zMax;

[SerializeField]
private float zMin;

private Transform target;


// Use this for initialization
void Start()
{

    target = GameObject.Find("Player").transform;

}

// Update is called once per frame
void LateUpdate()
{

    transform.position = new Vector3(Mathf.Clamp(target.position.x, xMin, xMax), Mathf.Clamp(target.position.y, yMin, yMax), Mathf.Clamp(target.position.z, zMin, zMax));
}
}