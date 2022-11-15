using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    GameManager insGameManager;

    InputAI insInputAI;

//-----
    int insLocationTrigger = 10;
    List<int> validSlots = new List<int>();
    string playerTurn = "Default";
    int insPlayerCount;

    void Start()
    {
        insGameManager = FindObjectOfType<GameManager>();
        insInputAI = FindObjectOfType<InputAI>();

        for(int i = 0; i < 9; i++)
        {
            validSlots.Add(i);
        }

        

        playerTurn = "Cross";
    }

    public void CrossInput(int locationTrigger)
    {
        if(playerTurn.Equals("Cross") & GameManager.gameEnded == false)
        {
            insLocationTrigger = locationTrigger;
            IsValid();
        }
    }

    void CircleInput()
    {
        if(GameManager.gameEnded == false && insPlayerCount == 0);
        {
            insLocationTrigger = insInputAI.locationTrigger(validSlots);
            IsValid();
        }
    }

    void IsValid()
    {
        foreach(int i in validSlots)
        {
            if(insLocationTrigger.Equals(i))
            {
                insGameManager.InputLocation(insLocationTrigger,playerTurn);
                validSlots.Remove(i);

                if(playerTurn.Equals("Cross"))
                {
                    playerTurn = "Circle";
                    CircleInput();
                }
                else
                {
                    playerTurn = "Cross";
                }

                break;
            }
        }
    }
}
