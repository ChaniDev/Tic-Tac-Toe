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
                InputManager.Board[i] = 1;
                int score = MiniMax(InputManager.Board, 0, false);
                InputManager.Board[i] = 0;
                
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

    int[] scoreTable = new int[]{0,-1,1};

    int MiniMax(int[] gameBoard, int algoDepth, bool isMaximizing)
    {
        int gameResult = insGameState.GameResult();
        if (gameResult != 10)
        {
            int gameScore = scoreTable[gameResult];
            return gameScore;
        }

        if (isMaximizing)
        {

        }

        return 1;
    }

    void Output(int selectedLocation)
    {
        insInputManager.TurnManager(selectedLocation,playerID);

        InputManager.validSlotID.Remove(selectedLocation);
        InputManager.Board[selectedLocation] = 1;

        insGameState.CheckBoard();
    }
    
}