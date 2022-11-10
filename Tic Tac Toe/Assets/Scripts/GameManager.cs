using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    string playerTurn = "Default";
    int selectedLocation = 10;

    public void InputLocation(int insLocationTrigger)
    {
        selectedLocation = insLocationTrigger;

        Debug.Log(selectedLocation + "GameManager");
    }
}
