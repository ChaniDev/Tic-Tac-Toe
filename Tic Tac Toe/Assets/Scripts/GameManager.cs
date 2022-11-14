using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameEnded = false;

    [SerializeField] GameObject insCross;
    [SerializeField] GameObject insCrossWin;

    [SerializeField] GameObject insCircle;
    [SerializeField] GameObject insCircleWin;

    int[] gameBoard = new int[9]
    {
        0,0,0,
        0,0,0,
        0,0,0
    };

    int selectedLocation = 10;
    string PlayerID = "default";

    Vector2[] possibleSlots = {
        new Vector2(-2,2),
        new Vector2(0,2),
        new Vector2(2,2),
        new Vector2(-2,0),
        new Vector2(0,0),
        new Vector2(2,0),
        new Vector2(-2,-2),
        new Vector2(0,-2),
        new Vector2(2,-2)
        };

    public void InputLocation(int insLocationTrigger, string playerTurn)
    {
        selectedLocation = insLocationTrigger;
        PlayerID = playerTurn;

        print(selectedLocation);
        print(PlayerID);

        DisplayData();
    }

    void DisplayData()
    {
        if(PlayerID == "P1")
        {
            Instantiate(insCross,possibleSlots[selectedLocation], Quaternion.identity);

            gameBoard[selectedLocation] = 1;
        }
        else
        {
            Instantiate(insCircle,possibleSlots[selectedLocation], Quaternion.identity);
            
            gameBoard[selectedLocation] = 2;
        }

        CheckBoard();
    }

    void CheckBoard()
    {
        var HL1 = (gameBoard[0] & gameBoard[1] & gameBoard[2]);
        var HL2 = (gameBoard[3] & gameBoard[4] & gameBoard[5]);
        var HL3 = (gameBoard[6] & gameBoard[7] & gameBoard[8]);

        var VL1 = (gameBoard[0] & gameBoard[3] & gameBoard[6]);
        var VL2 = (gameBoard[1] & gameBoard[4] & gameBoard[7]);
        var VL3 = (gameBoard[2] & gameBoard[5] & gameBoard[8]);

        var DL1 = (gameBoard[0] & gameBoard[4] & gameBoard[8]);
        var DL2 = (gameBoard[2] & gameBoard[4] & gameBoard[6]);

    //--------------------------------------------------------------------------
        if(HL1 == 1)
        {
            Debug.Log("Player 1 Won!");
            gameEnded = true;
            Instantiate(insCrossWin, new Vector2(0,2), Quaternion.Euler(0,0,90));
        }
        if(HL2 == 1)
        {
            Debug.Log("Player 1 Won!");
            gameEnded = true;
            Instantiate(insCrossWin, new Vector2(0,0), Quaternion.Euler(0,0,90));
        }
        if(HL3 == 1)
        {
            Debug.Log("Player 1 Won!");
            gameEnded = true;
            Instantiate(insCrossWin, new Vector2(0,-2), Quaternion.Euler(0,0,90));
        }

    //------
        if(VL1 == 1)
        {
            Debug.Log("Player 1 Won!");
            gameEnded = true;
            Instantiate(insCrossWin, new Vector2(-2,0), Quaternion.Euler(0,0,0));
        }
        if(VL2 == 1)
        {
            Debug.Log("Player 1 Won!");
            gameEnded = true;
            Instantiate(insCrossWin, new Vector2(0,0), Quaternion.Euler(0,0,0));
        }
        if(VL3 == 1)
        {
            Debug.Log("Player 1 Won!");
            gameEnded = true;
            Instantiate(insCrossWin, new Vector2(2,0), Quaternion.Euler(0,0,0));
        }

    //------
        if(DL1 == 1)
        {
            Debug.Log("Player 1 Won!");
            gameEnded = true;
            Instantiate(insCrossWin, new Vector2(0,0), Quaternion.Euler(0,0,45));
        }
        if(DL2 == 1)
        {
            Debug.Log("Player 1 Won!");
            gameEnded = true;
            Instantiate(insCrossWin, new Vector2(0,0), Quaternion.Euler(0,0,-45));
        }

    //--------------------------------------------------------------------------
        if(HL1 == 2)
        {
            Debug.Log("Player 2 Won!");
            gameEnded = true;
            Instantiate(insCircleWin, new Vector2(0,2), Quaternion.Euler(0,0,90));
        }
        if(HL2 == 2)
        {
            Debug.Log("Player 2 Won!");
            gameEnded = true;
            Instantiate(insCircleWin, new Vector2(0,0), Quaternion.Euler(0,0,90));
        }
        if(HL3 == 2)
        {
            Debug.Log("Player 2 Won!");
            gameEnded = true;
            Instantiate(insCircleWin, new Vector2(0,-2), Quaternion.Euler(0,0,90));
        }

    //------
        if(VL1 == 2)
        {
            Debug.Log("Player 2 Won!");
            gameEnded = true;
            Instantiate(insCircleWin, new Vector2(-2,0), Quaternion.Euler(0,0,0));
        }
        if(VL2 == 2)
        {
            Debug.Log("Player 2 Won!");
            gameEnded = true;
            Instantiate(insCircleWin, new Vector2(0,0), Quaternion.Euler(0,0,0));
        }
        if(VL3 == 2)
        {
            Debug.Log("Player 2 Won!");
            gameEnded = true;
            Instantiate(insCircleWin, new Vector2(2,0), Quaternion.Euler(0,0,0));
        }

    //------
        if(DL1 == 2)
        {
            Debug.Log("Player 2 Won!");
            gameEnded = true;
            Instantiate(insCircleWin, new Vector2(0,0), Quaternion.Euler(0,0,45));
        }
        if(DL2 == 2)
        {
            Debug.Log("Player 2 Won!");
            gameEnded = true;
            Instantiate(insCircleWin, new Vector2(0,0), Quaternion.Euler(0,0,-45));
        }
    }
}
