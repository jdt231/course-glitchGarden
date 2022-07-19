using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{

    Defender defender;
    GameObject defenderParent;
    const string DEFENDER_PARENT_NAME = "Defenders";


    private void Start()
    {
        CreateDefenderParent();
    }

    private void CreateDefenderParent()
    {
        defenderParent = GameObject.Find(DEFENDER_PARENT_NAME);
        if (!defenderParent)
        {
            defenderParent = new GameObject(DEFENDER_PARENT_NAME);
        }
    }

    private void OnMouseDown()
    {
        AttemptToPlaceDefenderAt(GetSquareClicked());
    }

    public void SetSelectedDefender(Defender defenderToSelect)
    {
        defender = defenderToSelect;
    }

    private void AttemptToPlaceDefenderAt(Vector2 gridPos)
    {
        var StarDisplay = FindObjectOfType<StarDisplay>(); // allows us to access the StarDisplay script.
        int defenderCost = defender.GetStarCost(); // sets "defenderCost" to the amount passed in by the "GetStarCost" method from "Defender" script.
        if (StarDisplay.HaveEnoughStars(defenderCost)) // calls the "HaveEnoughStars" bool method within the "StarDisplay" script, feeds the "defenderCost" int declared above into this method.
                                                       // if the HaveEnoughStars bool method within the "StarDisplay" script returns "true" (as this method simply returns true or false).
        {
            SpawnDefender(gridPos);
            StarDisplay.SpendStars(defenderCost);
        }
    }

    private Vector2 GetSquareClicked()

    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y); // sets "clickPos" vector co-ords to the x & y position of the mouse when it clicked.
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos); // converts the x & y co-ords stored in clickPos into "world space" and stores this in "worldPos".
        Vector2 gridPos = SnapToGrid(worldPos); // using the SnapToGrid method to round the new x + y co-ords (converted to "world space") to the nearest integer.
        return gridPos; // return these rounded integers when "AttemptToPlaceDefenderAt" is called
    }

    // This is the method used to convert the x & y co-ords collected above into whole integers.
    private Vector2 SnapToGrid(Vector2 rawWorldPos) // In "GetSquareClicked" the param being feed into here is "worldPos". 
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newX, newY);
    }

    private void SpawnDefender(Vector2 roundedPos) // The rounded (world space) co-ords produced by "GetSquareClicked" are what's is passed into "roundedPos"
    {
        Defender newDefender = Instantiate(defender, roundedPos, Quaternion.identity) as Defender;
        newDefender.transform.parent = defenderParent.transform;
    }


}
