using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    GameManager insGameManager;
    InputPlayer insInputPlayer;
    InputAI insInputAI;

    public static List<int> validSlotID = new List<int>();
    public static int[] Board = new int[]
        {
            0,0,0,
            0,0,0,
            0,0,0,
        };

    bool playerIsCross = true;
    bool gameEnded = false;
    string lastTurn;
    int turnCount = 0;

    void Start()
    {
        for(int i = 0; i < 9; i++)
        {
            validSlotID.Add(i);
        }

        insGameManager = FindObjectOfType<GameManager>();

        insInputPlayer = FindObjectOfType<InputPlayer>();
        insInputAI = FindObjectOfType<InputAI>();
    }

    public void TriggerStartTurn()
    {
        if(playerIsCross)
        {
            Invoke("RequestPlayerInput",0.5f);
        }
        else
        {
            Invoke("RequestAIInput",0.8f);
        }
    }

    void RequestPlayerInput()
    {
        Debug.Log("Turn - Player");

        lastTurn = "Player";
        turnCount++;
        
        insInputPlayer.RequestInput();
    }
    void RequestAIInput()
    {
        Debug.Log("Turn - AI");

        lastTurn = "AI";
        turnCount++;

        insInputAI.RequestInput();
    }

    public void TurnManager(int selectedLocation, int playerID)
    {
        insGameManager.DisplayHandler(selectedLocation, playerID ,playerIsCross);

        if(turnCount > 8)
        {
            gameEnded = true;

            insGameManager.Invoke("GameReset",1f);
        }
        else if(lastTurn == "Player" & !gameEnded)
        {
            Invoke("RequestAIInput",0.8f);
        }
        else if(lastTurn == "AI" & !gameEnded)
        {
            Invoke("RequestPlayerInput",0.5f);
        }
        else
        {
            Debug.LogError("No Input Request sent* Error in lastTurn variable");
        }
    }  

    public void Reset()
    {
        gameEnded = false;

        validSlotID.Clear();

        for(int i = 0; i < 9; i++)
        {
            validSlotID.Add(i);
        }

        turnCount = 0;

        TriggerStartTurn();
    } 
}
