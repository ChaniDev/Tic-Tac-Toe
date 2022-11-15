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
    int insPlayerCount = 0;

    void Start()
    {
        insGameManager = FindObjectOfType<GameManager>();
        insInputAI = FindObjectOfType<InputAI>();

        for(int i = 0; i < 9; i++)
        {
            validSlots.Add(i);
        }

        insPlayerCount = insGameManager.PlayerAmount();

        playerTurn = "Cross";
    }

    public void Reset()
    {
        validSlots.Clear();

        insLocationTrigger = 10;
        for(int i = 0; i < 9; i++)
        {
            validSlots.Add(i);
        }

        playerTurn = "Cross";
    }

    public void PlayerInput(int locationTrigger)
    {
        if(playerTurn.Equals("Cross") & GameManager.gameEnded == false)
        {
            insLocationTrigger = locationTrigger; 
            IsValid();
        }

        if(playerTurn.Equals("Circle") & GameManager.gameEnded == false & insPlayerCount ==1)
        {
            insLocationTrigger = locationTrigger;
            IsValid();
        }
    }

    void AIInput()
    {
        if(GameManager.gameEnded == false && insPlayerCount == 0)
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
                    AIInput();
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
