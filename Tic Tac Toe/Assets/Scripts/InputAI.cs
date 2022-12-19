using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputAI : MonoBehaviour
{
    InputManager insInputManager;
    GameState insGameState;

    int playerID = 1;

    void Start()
    {
        insInputManager = FindObjectOfType<InputManager>();
        insGameState = FindObjectOfType<GameState>();
    }

    public void RequestInput()
    {
        int bestScore = -1000;
        int bestMove;
        int selectedLocation = 0;

        for(int i = 0; i < 9; i++)
        {
            if(InputManager.Board[i] == 0 )
            {
                int score = MiniMax(InputManager.Board);
                
                if (score > bestScore)
                {
                    bestScore = score;
                    bestMove = (i);
                    
                    selectedLocation = bestMove;
                }
            }
        }
        Output(selectedLocation);
    }

    int MiniMax(int[] gameBoard)
    {
        return 1;
    }

    void Output(int selectedLocation)
    {
        insInputManager.TurnManager(selectedLocation,playerID);
        print("--Player Input--");

        InputManager.validSlotID.Remove(selectedLocation);
        InputManager.Board[selectedLocation] = 1;
    }
    
}