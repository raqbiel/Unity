using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TappxSDK;
public class MenuScript : MonoBehaviour {

    public TappxManagerUnity tmu;

	// Use this for initialization
	void Start () {
        tmu = FindObjectOfType<TappxManagerUnity>();

        
	}


	
	// Update is called once per frame
	void Update () {
        tmu.show();
    }

   
      
}
