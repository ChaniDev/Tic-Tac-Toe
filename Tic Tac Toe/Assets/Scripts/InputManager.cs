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

    void Start()
    {
        insGameManager = FindObjectOfType<GameManager>();
        insInputAI = FindObjectOfType<InputAI>();

        for(int i = 0; i < 9; i++)
        {
            validSlots.Add(i);
        }
        playerTurn = "P1";
    }

    public void P1Input(int locationTrigger)
    {
        if(playerTurn.Equals("P1") & GameManager.gameEnded == false)
        {
            insLocationTrigger = locationTrigger;
            IsValid();
        }
    }

    void P2Input()
    {
        if(GameManager.gameEnded == false)
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

                if(playerTurn.Equals("P1"))
                {
                    playerTurn = "P2";
                    P2Input();
                }
                else
                {
                    playerTurn = "P1";
                }

                break;
            }
        }
    }
}
