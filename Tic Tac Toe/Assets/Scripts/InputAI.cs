using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputAI : MonoBehaviour
{
    InputManager insInputManager;
    GameState insGameState;

    int playerID = 1;

    bool ActiveAI = true;


    public void SettingsAI(bool AI)
    {
        ActiveAI = AI;
    }

    void Start()
    {
        insInputManager = FindObjectOfType<InputManager>();
        insGameState = FindObjectOfType<GameState>();
    }

    public void RequestInput()
    {
        float bestScore = -Mathf.Infinity;
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
        if(!ActiveAI)
        {
            return 1;
        }

        int scanResult = insGameState.ScanBoard(); 

        if(scanResult == 0)
        {
            return 0;
        } 
        else if(scanResult == 1)
        {
            //ai won
            return 1;
        }
        else if(scanResult == 2)
        {
            //ai lost
            return -1;
        }

        if(isMaximizing)
        {
            int bestScore = -10;

            for(int i = 0; i < 9; i++)
            {
                if(gameBoard[i] == 0)
                {
                    gameBoard[i] = 1;
                    int score = MiniMax(gameBoard, algoDepth++, false);
                    gameBoard[i] = 0;

                    if(score > bestScore)
                    {
                        bestScore = score;
                    } 
                }
            }

            return bestScore;
        }
        else
        {
            int bestScore = 10; 

            for(int i = 0; i < 9; i++)
            {
                if(gameBoard[i] == 0)
                {
                    gameBoard[i] = 2;
                    int score = MiniMax(gameBoard, algoDepth++, true);
                    gameBoard[i] = 0;

                    if(score < bestScore)
                    {
                        bestScore = score;
                    }
                }
            }

            return bestScore;
        }
    }

    void Output(int selectedLocation)
    {
        insInputManager.TurnManager(selectedLocation,playerID);

        InputManager.validSlotID.Remove(selectedLocation);
        InputManager.Board[selectedLocation] = 1;

        insGameState.CheckBoard("GameCore");
    }
    
}