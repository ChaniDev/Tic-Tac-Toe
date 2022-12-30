using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    GameManager insGameManager;
    InputManager insInputManager;

    bool wonPlayer = false;
    bool wonAI = false;

    int scanOutcome = 10;


    bool gameTie = false;

    int turnCounter = 0;

    bool isPlayerCross;

    Vector3Int[] resultGrid = new Vector3Int[]
    {
        new Vector3Int (0,1,2),
        new Vector3Int (3,4,5),
        new Vector3Int (6,7,8),

        new Vector3Int (0,3,6),
        new Vector3Int (1,4,7),
        new Vector3Int (2,5,8),

        new Vector3Int (0,4,8),
        new Vector3Int (2,4,6),
    };

    void Start()
    {
        insGameManager = FindObjectOfType<GameManager>();
        insInputManager = FindObjectOfType<InputManager>();
    }

    public void PlayersPostion(bool insPlayerIsCross)
    {
        isPlayerCross = insPlayerIsCross;
    }

    public void CheckBoard(string RequestType)
    {
        int locationTracker = 0;

        foreach(Vector3Int i in resultGrid)
        {  
            if(
                (
                    InputManager.Board[(i.x)],
                    InputManager.Board[(i.y)],
                    InputManager.Board[(i.z)]
                )
                == (1,1,1)
            )
            {
                if(RequestType == "GameCore")
                {
                    insGameManager.WinHandler(isPlayerCross,locationTracker, 1);

                    Debug.Log("Win Location:"+ i +" ");
                    wonAI = true;
                }
                else if(RequestType == "Scan")
                {
                    scanOutcome = 1;
                }
            }
            else if(
                (
                    InputManager.Board[(i.x)],
                    InputManager.Board[(i.y)],
                    InputManager.Board[(i.z)]
                )
                == (2,2,2)
            )
            {
                if(RequestType == "GameCore")
                {
                    insGameManager.WinHandler(isPlayerCross,locationTracker, 2);

                    Debug.Log("Win Location:"+ i +" ");
                    wonPlayer = true;
                }
                else if(RequestType == "Scan")
                {
                    scanOutcome = 2;
                }
            }

            locationTracker++; 
        }

        if(RequestType == "Scan" && scanOutcome == 10)
        {
            bool isTerminal = true;
            for(int i = 0; i < 9 ; i++)
            {
                if(InputManager.Board[i] == 0)
                {
                    isTerminal = false;
                    return;
                }
            }

            if(isTerminal)
            {
                scanOutcome = 0;
            }
        }
        

        if(turnCounter >= 8 && !wonAI && !wonPlayer)
        {
            gameTie = true;
        }

        if(RequestType == "GameCore")
        {
            turnCounter++;
            GameResult();
        }
    }

    void GameResult()
    {
        if(wonPlayer)
        {
            insInputManager.GameResult();

            GameReset();

            print("--Player WON--");
        }
        else if(wonAI)
        {
            insInputManager.GameResult();

            GameReset();

            print("--AI WON--");
        }
        else if(gameTie)
        {
            insInputManager.GameResult();

            GameReset();

            print("--Game ended in a TIE--");
        }
    }

    void GameReset()
    {
        wonPlayer = false;
        wonAI = false;
        gameTie = false;
        turnCounter = 0;
    }

    public int ScanBoard()
    {
        CheckBoard("Scan");

        if(scanOutcome == 0)
        {
            scanOutcome = 10;
            return 0;
        }
        else if(scanOutcome == 1)
        {
            scanOutcome = 10;
            return 1;
        }
        else if(scanOutcome == 2)
        {
            scanOutcome = 10;
            return 2;
        }
        else return 10;
    }
}
