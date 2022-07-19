using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // This one

public class StarDisplay : MonoBehaviour
{
    [SerializeField] int stars = 100;
    Text starText; // Make sure you have added the "UnityEngine.UI" namespace to the top of your script, otherwise this line won't work.

    void Start()
    {
        starText = GetComponent<Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        starText.text = stars.ToString();
    }

    public bool HaveEnoughStars(int amount) // when this method is called by "DefenderSpawner", the defenders "starCost" is fed into it.
    {
        return stars >= amount; // compares the amount of stars we have (the "stars" int) and compares it to the defender's "starcost" fed into the method above when it was called.
                                // this method is a bool. So if our current "stars" is greater than or equal to the amount (starCost), this method will return true. If it's less, return false.
    }

    public void AddStars(int amount)
    {
        stars += amount;
        UpdateDisplay();
    }

    public void SpendStars(int amount)
    {
        if (stars >= amount)
        {
            stars -= amount;
            UpdateDisplay();
        }
    }

}
