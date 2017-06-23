using UnityEngine;
using System.Collections;

public class MusicMenager : MonoBehaviour {

    private AudioSource audioSource;
    public AudioClip[] musicLevelArray;

    const string MUSIC_VOLUME = "MUSIC_VOLUME";

    // Use this for initialization
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Debug.Log("Don't Destroy on load: " + name);
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
       
    }

    void OnLevelWasLoaded(int level)
    {
        AudioClip thisLevelMusic = musicLevelArray[level];
        Debug.Log("Playing clip: " + thisLevelMusic);

        if (thisLevelMusic) // jezeli jest jakas muza dolaczona
        {
            audioSource.clip = thisLevelMusic;
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    public void ChangeVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
