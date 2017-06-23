using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour {

	public float autoLoadNextLevelAfter;

	void Start () {
        if(autoLoadNextLevelAfter == 0)
        {
            Debug.Log("Wczytano Poziom");
        }else { 
		Invoke ("LoadNextLevel", autoLoadNextLevelAfter);
        }
    }

	public void LoadLevel(string name){
		Debug.Log ("New Level load: " + name);
		SceneManager.LoadScene (name);
	}

	public void QuitRequest(){
		Debug.Log ("Quit requested");
		Application.Quit ();
	}
	
	public void LoadNextLevel() {
		SceneManager.LoadScene(Application.loadedLevel + 1);
	}
}
