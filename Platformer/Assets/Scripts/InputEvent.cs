using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InputEvent : MonoBehaviour {

    public InputField inputPass;
    public GameObject inputField;
	public float posX;
	public float posY;
   //public Text placeHolder;
    public string haslo;
	// Use this for initialization
	void Start () {

        inputField.SetActive(false);

	}

    private void OnTriggerExit2D(Collider2D collision)
    {
        inputField.SetActive(false);
    }

    // Update is called once per frame
    void Update () {

        //Password(haslo);
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            inputField.SetActive(true);
            Password(haslo);
        }
    }

    public void Password(string password)
    {
        if (inputPass.text == password)
        {
            Debug.Log("Password currect");
			GameObject.Find("InputDoor").transform.position = Vector2.MoveTowards(GameObject.Find("InputDoor").transform.position, new Vector2(posX, posY), 0.1f);
            Destroy(GameObject.Find("TriggerEnter"),1f); 
            Destroy(GameObject.Find("EnterPassword"),1f);
        }
        else
        {
            Debug.Log("Password wrong");
        
        }
    }
}
