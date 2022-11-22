using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    InputManager insInputManager;

    

    void Start()
    {
        insInputManager = FindObjectOfType<InputManager>();

        StartGame();
    }

    void StartGame()
    {
        insInputManager.TriggerStartTurn();
    }
}
