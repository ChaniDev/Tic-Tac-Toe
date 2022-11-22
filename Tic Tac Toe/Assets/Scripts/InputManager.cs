using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    GameManager insGameManager;
    InputPlayer insInputPlayer;

    bool playerIsCross = true;
    bool gameEnded = false;
    string lastTurn;
    int turnCount = 0;

    void Start()
    {
        insGameManager = FindObjectOfType<GameManager>();
        insInputPlayer = FindObjectOfType<InputPlayer>();
    }

    public void TriggerStartTurn()
    {
        if(playerIsCross)
        {
            RequestPlayerInput();
        }
        else
        {
            RequestAIInput();
        }
    }

    void RequestPlayerInput()
    {
        Debug.Log("Player");
        insInputPlayer.turnPlayer();

        lastTurn = "Player";

        turnCount++;
        TurnManager();
    }
    void RequestAIInput()
    {
        Debug.Log("AI");

        lastTurn = "AI";

        turnCount++;
        TurnManager();
    }

    void TurnManager()
    {
        if(turnCount > 8)
        {
            gameEnded = true;
        }
        else if(lastTurn == "Player" & !gameEnded)
        {
            RequestAIInput();
        }
        else if(lastTurn == "AI" & !gameEnded)
        {
            RequestPlayerInput();
        }
        else
        {
            Debug.LogError("No Input Request sent* Error in lastTurn variable");
        }
    }
    
}
