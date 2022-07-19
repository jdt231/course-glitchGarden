using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject loseLabel;
    [SerializeField] float waitToLoad = 4f;
    int numberOfAttackers = 0;
    bool levelTimerFinished = false;

    private void Start()
    {
        winLabel.SetActive(false); // at the start of our game turns off our "Level Complete Canvas" so that it is not visible until we win the game.
        loseLabel.SetActive(false); // at the start of our game turns off our "Level Lost Canvas" so that it is not visible until we win the game.
    }

    public void AttackerSpawned()
    {
        numberOfAttackers++;
    }

    public void AttackerKilled()
    {
        numberOfAttackers--;

        if (numberOfAttackers <= 0 && levelTimerFinished) // using "&&" alows us to have have more than one criteria for our if statement.
        {
            StartCoroutine(HandleWinCondition()); // once the level is won, call this co-routine.
        }
    }

    IEnumerator HandleWinCondition()
    {
        winLabel.SetActive(true); // turn on the "Level Complete Canvas"
        GetComponent<AudioSource>().Play(); //access the "AudioSource" and play the attached audio clip.
        yield return new WaitForSeconds(waitToLoad); // wait for the amount of seconds entered into our Serialised Field "waitToLoad".
        FindObjectOfType<LevelLoader>().LoadNextScene(); // access the LevelLoader and run the "LoadNextScene" method.
    }

    public void HandleLoseCondition()
    {
        loseLabel.SetActive(true);
        Time.timeScale = 0; // sets the in game passing of time to zero so everything stops moving.
    }

    public void LevelTimerFinished()
    {
        levelTimerFinished = true;
        StopAllSpawners();
    }

    private void StopAllSpawners() // we have 5 spawners so we need to create an array in order to access them all at once.
    {
        AttackerSpawner[] spawnerArray = FindObjectsOfType<AttackerSpawner>();
        // "AttackerSpawner[]" = Type of array.
        // "spawnerArray" = Name of array.
        // "FindObjectsOfType<AttackerSpawner>();" = finds every object with the "AttackerSpawner" script attached to it and collects it into our array.

        foreach (AttackerSpawner spawner in spawnerArray) // assigns each "AttackerSpawner" held in our array (spawnerArray) to "spawner" and runs the method for every "spawner" in the array.
        {
            spawner.StopSpawning(); // calls the "StopSpawning" method in each "AttackerSpawner" script.
        }
    }
}
