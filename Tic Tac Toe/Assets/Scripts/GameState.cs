using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    GameManager insGameManager;
    InputManager insInputManager;

    bool wonPlayer = false;
    bool wonAI = false;
    bool gameTie = false;
    int result = 10;

    int turnCounter = 0;

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

    public void CheckBoard()
    {
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
                Debug.Log("Win Location:"+ i +" ");

                wonAI = true;
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
                Debug.Log("Win Location:"+ i +" ");

                wonPlayer = true;
            }
        }
        

        if(turnCounter >= 8 && !wonAI && !wonPlayer)
        {
            gameTie = true;
        }


        turnCounter++;

        GameResult();
    }

    int GameResult()
    {
        if(wonPlayer)
        {
            insInputManager.GameResult();

            gameReset();

            print("--Player WON--");

            result = 2;
        }
        else if(wonAI)
        {
            insInputManager.GameResult();

            gameReset();

            print("--AI WON--");

            result = 1;
        }
        else if(gameTie)
        {
            insInputManager.GameResult();

            gameReset();

            print("--Game ended in a TIE--");

            result = 0;
        }

        return result;
    }

    void gameReset()
    {
        wonPlayer = false;
        wonAI = false;
        gameTie = false;
        result = 10;
        turnCounter = 0;
    }
}
