using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static string gameResult = "null";

    GameManager insGameManager;

    bool wonPlayer = false;
    bool wonAI = false;
    bool gameTie = false;

    bool gameActive = false;

    void Start()
    {
        insGameManager = FindObjectOfType<GameManager>();
    }

    void CheckBoard()
    {
        
    }

    public int GameResult()
    {
        if(wonPlayer)
        {
            return 2;
        }
        else if(wonAI)
        {
            return 1;
        }
        else if(gameTie)
        {
            return 0;
        }

        return 10;
    }
}
