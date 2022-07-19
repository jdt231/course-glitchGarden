using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    // Start is called before the first frame update

    [Tooltip("Our level timer in SECONDS")] // This adds a pop-up dialog box when we hover over the serialized field below it in the editor.
    [SerializeField] float levelTime = 10;
    bool triggeredLevelFinished;

    // Update is called once per frame
    void Update()
    {
        if (triggeredLevelFinished) { return; } // if "triggeredLevelFinished" is set to "true", ignore the rest of this method/do nothing.

        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime; // "GetComponent<Slider().Value>" is what we are using to access the sliders position or "value". If we are 5 seconds
                                                                            // into our game and and our levelTime is set to 10, the above will set the slider to 0.5 (5 divided by 10).

        bool timerFinished = (Time.timeSinceLevelLoad >= levelTime); // the amount of seconds that has past since the level loaded up reaches the value of our "levelTime"

        if (timerFinished) // if the above is true
        {
            FindObjectOfType<LevelController>().LevelTimerFinished(); //access the "LevelController" script and call the "LevelTimerFinished" method.
            triggeredLevelFinished = true;
        }
    }
}
