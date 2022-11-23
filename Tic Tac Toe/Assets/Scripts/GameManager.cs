using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    InputManager insInputManager;

    [SerializeField] private GameObject Cross;

    void Start()
    {
        insInputManager = FindObjectOfType<InputManager>();

        StartGame();
    }

    void StartGame()
    {
        insInputManager.TriggerStartTurn();
    }

    public void DisplayHandler(int insSelectedLocation, int insPlayerID)
    {
        Instantiate(Cross, new Vector2(0,0), Quaternion.identity);
    }
}
