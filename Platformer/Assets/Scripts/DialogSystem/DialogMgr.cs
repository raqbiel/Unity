using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogMgr : MonoBehaviour {

    public Queue<string> zdania;

    public Text nameText;
    public Text dialogText;

    public Animator anim;
    SceneFader sceneFader;
    public string levelTo;
    public GameObject levelButtons;
    public GameObject socialButtons;
    public GameObject googleServices;
    public GameObject credits;
    public GameObject exitButton;
    public GameObject muteSound;
    boss_AI boss;
    PlayerController player;

    string sceneName;
    // Use this for initialization

    private void Awake()
    {
        boss = FindObjectOfType<boss_AI>();
        player = FindObjectOfType<PlayerController>();
    }
    void Start () {

        PlayerPrefs.SetInt("level1lock", 1);

        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;

        sceneFader = FindObjectOfType<SceneFader>();
        zdania = new Queue<string>();
    }
	
	// Update is called once per frame
	public void StartDialog(Dialog dialog)
    {
        anim.SetBool("isOpen", true);

        nameText.text = dialog.name;

        zdania.Clear();

        foreach(string zdanie in dialog.zdania)
        { 
            zdania.Enqueue(zdanie);
        }
        PokazNastepneZdanie();
    }

    public void PokazNastepneZdanie()
    {
        if(zdania.Count == 0 && sceneName == "menu")
        {
            sceneFader.FadeTo(levelTo);
            PlayerPrefs.SetFloat("DialogMenu", 1);
            ZakonczDialog();
            return;
        }
        if(zdania.Count == 0 && sceneName == "levelselect")
        {
            
            PlayerPrefs.SetFloat("DialogLevel", 1);
            levelButtons.SetActive(true);
            socialButtons.SetActive(true);
            googleServices.SetActive(true);
            credits.SetActive(true);
            exitButton.SetActive(true);
            muteSound.SetActive(true);

            ZakonczDialog();
            return;
        }
        if (zdania.Count == 0 && sceneName == "level07")
        {
           
            boss.TouchControl.SetActive(true);
            StartCoroutine(boss.GetComponent<boss_AI>().boss());
            ZakonczDialog();
            return;
        }
        if (zdania.Count == 0 && sceneName == "level07c")
        {

            boss.TouchControl.SetActive(true);
            StartCoroutine(boss.GetComponent<boss_AI>().boss());
            ZakonczDialog();
            return;
        }

        string zdanie = zdania.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeZdanie(zdanie));
    }

    IEnumerator TypeZdanie(string zdanie)
    {
        dialogText.text = "";
        foreach(char litera in zdanie.ToCharArray())
        {
            dialogText.text += litera;
            yield return null;
            
        }
    }

    public void ZakonczDialog()
    {
       
        anim.SetBool("isOpen", false);
    }
}
