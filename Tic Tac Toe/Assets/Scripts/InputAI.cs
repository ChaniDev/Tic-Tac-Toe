using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputAI : MonoBehaviour
{
    InputManager insInputManager;
    GameState insGameState;

    int playerID = 1;
    bool matchFound = false;

    void Start()
    {
        insInputManager = FindObjectOfType<InputManager>();
        insGameState = FindObjectOfType<GameState>();
    }

    public void RequestInput()
    {
        matchFound = false;
        int moveSelected = 10;
        int bestMove = -1000;
        int depthOfTree = 0;

        for(int i = 0; i < 9; i++)
        {
            if(InputManager.Board[i] == 0)
            {
                int scoreOfMove = MinMax(InputManager.Board, depthOfTree, false);

                if(scoreOfMove > bestMove)
                {
                    bestMove = scoreOfMove;
                    moveSelected = i;
                }
            }
        }

        IfValid(moveSelected);
    }

    int GameResult()
    {
        if(GameState.gameResult == "Player")
        {
            int score = -1;
            return(score);
        }
        else if(GameState.gameResult == "AI")
        {
            int score = 1;
            return(score);
        }
        else
        {
            int score = 0;
            return(score);
        }
    } 

    int MinMax(int[] insBoard, int insDepthOfTree, bool isMaximizing)
    {
        if(GameState.gameResult != "null")
        {
            int score = GameResult();
            return(score);
        }

        return(1);
    }

    void IfValid(int selectedLocation)
    {
        foreach(int i in InputManager.validSlotID)
        {
            if(selectedLocation == i)
            {
                print("--AI Input--");

                InputManager.validSlotID.Remove(i);
                InputManager.Board[i] = 2;

                insInputManager.TurnManager(i,playerID);
                matchFound = true;
                break;
            }
        }

        if (!matchFound)
        {
            RequestInput();
        }
    }
}
