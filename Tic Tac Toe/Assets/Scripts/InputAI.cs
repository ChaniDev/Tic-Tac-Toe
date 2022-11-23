using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputAI : MonoBehaviour
{
    InputManager insInputManager;

    int playerID = 1;
    bool matchFound = false;

    void Start()
    {
        insInputManager = FindObjectOfType<InputManager>();
    }

    public void RequestInput()
    {
        matchFound = false;

        int r =Random.Range(0,9);

        IfValid(r);
    }

    void IfValid(int selectedLocation)
    {
        Debug.Log("I am in Danger");

        foreach(int i in InputManager.validSlotID)
        {
            if(selectedLocation == i)
            {
                Debug.Log("OutputFound");
                InputManager.validSlotID.Remove(i);

                insInputManager.TurnManager(i,playerID);
                matchFound = true;
                break;
            }
        }

        if (!matchFound)
        {
            RequestInput();
        }
    }
}
