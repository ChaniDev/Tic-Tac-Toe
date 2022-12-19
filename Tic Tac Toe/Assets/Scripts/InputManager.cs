using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    GameManager insGameManager;
    InputPlayer insInputPlayer;
    InputAI insInputAI;
    GameState insGameState;

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
    public static int turnCount = 0;
    int gameCounter = 0;

    void Start()
    {
        for(int i = 0; i < 9; i++)
        {
            validSlotID.Add(i);
        }

        insGameManager = FindObjectOfType<GameManager>();
        insGameState = FindObjectOfType<GameState>();

        insInputPlayer = FindObjectOfType<InputPlayer>();
        insInputAI = FindObjectOfType<InputAI>();
    }

    public void TriggerStartTurn()
    {
        if(playerIsCross)
        {
            Invoke("RequestPlayerInput",0.2f);
        }
        else
        {
            Invoke("RequestAIInput",0.8f);
        }
    }

    void RequestPlayerInput()
    {
        lastTurn = "Player";
        turnCount++;
        
        insInputPlayer.RequestInput();
    }
    void RequestAIInput()
    {
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
            insGameManager.Invoke("GameReset",2f);
        }
        else if(lastTurn == "Player" & !gameEnded)
        {
            Invoke("RequestAIInput",0.8f);
        }
        else if(lastTurn == "AI" & !gameEnded)
        {
            Invoke("RequestPlayerInput",0.2f);
        }
        else
        {
            Debug.LogError("No Input Request sent* Error in lastTurn variable");
        }
    }  

    public void Reset()
    {
        gameCounter++;

        if(gameCounter > 2  & playerIsCross)
        {
            playerIsCross = false;
            gameCounter = 0;

            insGameManager.PlayerSwitch();
        }
        else if(gameCounter > 2 & !playerIsCross)
        {
            playerIsCross = true;
            gameCounter = 0;

            insGameManager.PlayerSwitch();
        }
        gameEnded = false;

        validSlotID.Clear();

        for(int i = 0; i < 9; i++)
        {
            validSlotID.Add(i);
        }

        turnCount = 0;

        for(int i = 0; i < 9; i++)
        {
            Board[i] = 0;
        }

        Invoke("TriggerStartTurn",0.1f);
    }
}
