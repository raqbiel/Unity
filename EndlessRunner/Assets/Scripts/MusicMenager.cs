using UnityEngine;
using System.Collections;

public class MusicMenager : MonoBehaviour {

    private AudioSource audioSource;
    public AudioClip[] musicLevelArray;

    // Use this for initialization
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Debug.Log("Don't Destroy on load: " + name);
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        AudioClip thisLevelMusic = musicLevelArray[0];
        Debug.Log("Playing clip: " + thisLevelMusic);

        if (thisLevelMusic) // jezeli jest jakas muza dolaczona
        {
            audioSource.clip = thisLevelMusic;
            audioSource.loop = true;
            audioSource.Play();
        }
    }

   /* void OnLevelWasLoaded(int level)
    {
        AudioClip thisLevelMusic = musicLevelArray[level];
        Debug.Log("Playing clip: " + thisLevelMusic);

        if (thisLevelMusic) // jezeli jest jakas muza dolaczona
        {
            audioSource.clip = thisLevelMusic;
            audioSource.loop = true;
            audioSource.Play();
        }
    }*/
}
