using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this); // this will ensure that this isnt destroyed when we change scenes.
        audioSource = GetComponent<AudioSource>(); // find our audio source that plays the music
        audioSource.volume = PlayerPrefsController.GetMasterVolume(); //set the volume of our audio source to the player preferences master volume.
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
