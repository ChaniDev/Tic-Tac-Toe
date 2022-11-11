using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int selectedLocation = 10;
    string PlayerID = "default";

    public void InputLocation(int insLocationTrigger, string playerTurn)
    {
        selectedLocation = insLocationTrigger;
        PlayerID = playerTurn;

        print(selectedLocation);
        print(PlayerID);
    }
}
