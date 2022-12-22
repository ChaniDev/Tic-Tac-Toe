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
    int turnCounter = 0;

    void Start()
    {
        insGameManager = FindObjectOfType<GameManager>();
        insInputManager = FindObjectOfType<InputManager>();
    }

    public void CheckBoard()
    {
        if((InputManager.Board[0] & InputManager.Board[1] & InputManager.Board[2]) == 1 )
        {
            wonAI = true;
        }

        if((InputManager.Board[6] & InputManager.Board[7] & InputManager.Board[8]) == 2 )
        {
            wonPlayer = true;
        }

        if(turnCounter > 8 && !wonAI && !wonPlayer)
        {
            gameTie = true;
        }

        GameResult();
    }

    public int GameResult()
    {
        if(wonPlayer)
        {
            insInputManager.GameResult();

            gameReset();
            return 2;
        }
        else if(wonAI)
        {
            insInputManager.GameResult();

            gameReset();
            return 1;
        }
        else if(gameTie)
        {
            insInputManager.GameResult();

            gameReset();
            return 0;
        }

        return 10;
    }

    void gameReset()
    {
        wonPlayer = false;
        wonAI = false;
        gameTie = false;
    }
}
