using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject insCross;
    [SerializeField] GameObject insCircle;

    int selectedLocation = 10;
    string PlayerID = "default";

    Vector2[] possibleSlots = {
        new Vector2(-2,2),
        new Vector2(0,2),
        new Vector2(2,2),
        new Vector2(-2,0),
        new Vector2(0,0),
        new Vector2(2,0),
        new Vector2(-2,-2),
        new Vector2(0,-2),
        new Vector2(2,-2)
        };

    public void InputLocation(int insLocationTrigger, string playerTurn)
    {
        selectedLocation = insLocationTrigger;
        PlayerID = playerTurn;

        print(selectedLocation);
        print(PlayerID);

        DisplayData();
    }

    void DisplayData()
    {
        if(PlayerID == "P1")
        {
            Instantiate(insCross,possibleSlots[selectedLocation], Quaternion.identity);
        }
        else
        {
            Instantiate(insCircle,possibleSlots[selectedLocation], Quaternion.identity);
        }
    }
}
