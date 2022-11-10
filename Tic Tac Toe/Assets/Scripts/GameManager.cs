using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    InputManager insInputManager;

//-----
    [SerializeField] private GameObject prefabCross;
    [SerializeField] private GameObject prefabCircle;
    string turnCounter = "Default";
    int selectedSlot;

    Vector2[] allSlots = new Vector2[] 
        {
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
    List<int> availableSlots = new List<int>();

    void Start()
    {
        insInputManager = FindObjectOfType<InputManager>();
    //------
        turnCounter = "P1";
        for(int i = 0; i < 9; i++)
        {
            availableSlots.Add(i);
        } 
        
        TurnHandler();
    }

    void TurnHandler()
    {
        if(turnCounter == "Player")
        {
            RequestInputP1();
        }
        else if(turnCounter == "CPU")
        {
            RequestInputP2();
        }
        else
        {
            Debug.LogWarning("Turn Counter was left undefined or lost its value");
            Application.Quit();
        }
    }

    void RequestInputP1()
    {
        selectedSlot = insInputManager.RequestP1Input();
    }

    void RequestInputP2()
    {

    }
}
