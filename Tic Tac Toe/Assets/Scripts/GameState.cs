using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static string gameResult = "null";

    GameManager insGameManager;

    void Start()
    {
        insGameManager = FindObjectOfType<GameManager>();
    }

    public string CheckResult()
    {
        if((InputManager.Board[3] & InputManager.Board[4] & InputManager.Board[5]) == 1)
        {
            gameResult = "Player";

            insGameManager.Invoke("GameReset",1f);
        } 
        else if(InputManager.turnCount > 7)
        {
            gameResult = "Draw";

            insGameManager.Invoke("GameReset",1f);
        }

        return(gameResult);
    }
}
