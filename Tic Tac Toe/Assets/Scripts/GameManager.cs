using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static bool gameEnded = false;

    int playerCount = 0;

    [SerializeField] GameObject insCross;
    [SerializeField] GameObject insCrossWin;

    [SerializeField] GameObject insCircle;
    [SerializeField] GameObject insCircleWin;

    string player1Score = "0";
    string player2Score = "0";

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

    void Awake()
    {
        GameObject insCrossScores = GameObject.Find("CrossScores");
        GameObject insCircleScores = GameObject.Find("CircleScores");

        player1Score = "69";
        player2Score = "96";

        insCrossScores.GetComponent<TMP_Text>().text = player1Score;
        insCircleScores.GetComponent<TMP_Text>().text = player2Score;
    }

    public int PlayerAmount()
    {
        return (playerCount);
    }

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
        if(PlayerID == "Cross")
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
            CrossWon();
            Instantiate(insCrossWin, new Vector2(0,2), Quaternion.Euler(0,0,90));
        }
        if(HL2 == 1)
        {
            CrossWon();
            Instantiate(insCrossWin, new Vector2(0,0), Quaternion.Euler(0,0,90));
        }
        if(HL3 == 1)
        {
            CrossWon();
            Instantiate(insCrossWin, new Vector2(0,-2), Quaternion.Euler(0,0,90));
        }

    //------
        if(VL1 == 1)
        {
            CrossWon();
            Instantiate(insCrossWin, new Vector2(-2,0), Quaternion.Euler(0,0,0));
        }
        if(VL2 == 1)
        {
            CrossWon();
            Instantiate(insCrossWin, new Vector2(0,0), Quaternion.Euler(0,0,0));
        }
        if(VL3 == 1)
        {
            CrossWon();
            Instantiate(insCrossWin, new Vector2(2,0), Quaternion.Euler(0,0,0));
        }

    //------
        if(DL1 == 1)
        {
            CrossWon();
            Instantiate(insCrossWin, new Vector2(0,0), Quaternion.Euler(0,0,45));
        }
        if(DL2 == 1)
        {
            CrossWon();
            Instantiate(insCrossWin, new Vector2(0,0), Quaternion.Euler(0,0,-45));
        }

    //--------------------------------------------------------------------------
        if(HL1 == 2)
        {
            CircleWon();
            Instantiate(insCircleWin, new Vector2(0,2), Quaternion.Euler(0,0,90));
        }
        if(HL2 == 2)
        {
            CircleWon();
            Instantiate(insCircleWin, new Vector2(0,0), Quaternion.Euler(0,0,90));
        }
        if(HL3 == 2)
        {
            CircleWon();
            Instantiate(insCircleWin, new Vector2(0,-2), Quaternion.Euler(0,0,90));
        }

    //------
        if(VL1 == 2)
        {
            CircleWon();
            Instantiate(insCircleWin, new Vector2(-2,0), Quaternion.Euler(0,0,0));
        }
        if(VL2 == 2)
        {
            CircleWon();
            Instantiate(insCircleWin, new Vector2(0,0), Quaternion.Euler(0,0,0));
        }
        if(VL3 == 2)
        {
            CircleWon();
            Instantiate(insCircleWin, new Vector2(2,0), Quaternion.Euler(0,0,0));
        }

    //------
        if(DL1 == 2)
        {
            CircleWon();
            Instantiate(insCircleWin, new Vector2(0,0), Quaternion.Euler(0,0,45));
        }
        if(DL2 == 2)
        {
            CircleWon();
            Instantiate(insCircleWin, new Vector2(0,0), Quaternion.Euler(0,0,-45));
        }
    }

    void CrossWon()
    {
        Debug.Log("Player Cross Won!");
        gameEnded = true;
    }

    void CircleWon()
    {
        Debug.Log("Player Circle Won!");
        gameEnded = true;
    }
}
