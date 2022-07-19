using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{

    const string MASTER_VOLUME_KEY = "master volume"; // "const" means constant. A constant cannot be changed. When declaring constants, you need to use capitals.
    const string DIFFICULTY_KEY = "difficulty";

    const float MIN_VOLUME = 0f; // we put these floats in place so that we dont accidentally go outside of these figures.
    const float MAX_VOLUME = 1f;

    const float MIN_DIFFICULTY = 0f;
    const float MAX_DIFFICULTY = 2f;

    public static void SetMasterVolume(float volume) // a "static" method will remain the same throughout the entire project
    {
        if (volume >= MIN_VOLUME && volume <= MAX_VOLUME) // if the float passed into the method is within the min and max range
        {
            Debug.Log("Master volume set to " + volume);
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume); // set the volume value to the float value passed in.
        }
        else
        {
            Debug.LogError("Master volume is out of range"); // using "Debug.LogError" instead of "Debug.Log" will actually make this show as an error with a red exclamation mark.
        }
    }

    public static float GetMasterVolume() // we are using this method to return the current master volume figure so that we can check it when called.
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY); 
    }

    public static void SetDifficulty(float difficulty)
    {
        if (difficulty >= MIN_DIFFICULTY && difficulty <= MAX_DIFFICULTY) // the difficulty feed in is within our Min and Max range
        {
            PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty);
        }
        else
        {
            Debug.LogError("Difficulty setting is not in range");
        }
    }

    public static float GetDifficulty()
    {
        return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
    }

}
