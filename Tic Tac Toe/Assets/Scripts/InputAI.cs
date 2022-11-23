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
        int i = Random.Range(0,9); 
        insInputManager.TurnManager(i,PlayerID);
    }

}
