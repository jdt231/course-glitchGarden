using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{

    [SerializeField] Slider volumeSlider;
    [SerializeField] float defaultVolume = 0.8f;
    [SerializeField] Slider difficultySlider;
    [SerializeField] float defaultDifficulty = 0f;

    // Start is called before the first frame update
    void Start()
    {
        volumeSlider.value = PlayerPrefsController.GetMasterVolume(); // set the value of the slider ( 0 - 1) to whatever the ""PlayerPrefsController"'s master volume is set to (on start).
        difficultySlider.value = PlayerPrefsController.GetDifficulty();
    }

    // Update is called once per frame
    void Update()
    {
        var musicPlayer = FindObjectOfType<MusicPlayer>();
        if (musicPlayer)
        {
            musicPlayer.SetVolume(volumeSlider.value);
        }
        else
        {
            Debug.LogWarning("No music player found, did you start from splash screen?");
        }
    }

    public void SaveAndExit() // when we press the "Back" button we want to set the master volume to whatever has been selected on the slider.
    {
        PlayerPrefsController.SetMasterVolume(volumeSlider.value); // set the master volume within the "PlayerPrefsController" to the slider value.
        PlayerPrefsController.SetDifficulty(difficultySlider.value);
        FindObjectOfType<LevelLoader>().LoadMainMenu(); // load the main menu.
    }

    public void ResetToDefaults() // reset the slider value to whatever the default is set to, the "SaveAndExit" function above will set the master volume when they press the "Back button".
    {
        volumeSlider.value = defaultVolume;
        difficultySlider.value = defaultDifficulty;
    }
}
