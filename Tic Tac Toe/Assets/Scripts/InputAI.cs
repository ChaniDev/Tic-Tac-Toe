using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputAI : MonoBehaviour
{
    InputManager insInputManager;

    int PlayerID = 1;

    void Start()
    {
        insInputManager = FindObjectOfType<InputManager>();
    }

    public void RequestInput()
    {
        int i=0;
        insInputManager.TurnManager(i,PlayerID);
    }

}
