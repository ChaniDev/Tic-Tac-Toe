using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    InputManager insInputManager;
//-----

    public static bool gameEnded = false;
    bool matchFound = false;
    int turnCounter = 0;
    int playerCount = 1;

    string playerOneName = "-Unity";
    string playerTwoName = "-ChaniDev";

    [SerializeField] GameObject insCross;
    [SerializeField] GameObject insCrossWin;
    GameObject insCrossScores;

    [SerializeField] GameObject insCircle;
    [SerializeField] GameObject insCircleWin;
    GameObject insCircleScores;

    int player1Score = 0;
    int player2Score = 0;

    int gameTurn = 0;

    int[] gameBoard = new int[9]
    {
        0,0,0,
        0,0,0,
        0,0,0
    };
    List<GameObject> tempHolder = new List<GameObject>();
    List<GameObject> listWinLine = new List<GameObject>();
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

    void Start()
    {
        insInputManager = FindObjectOfType<InputManager>();

        insCrossScores = GameObject.Find("CrossScores");
        insCircleScores = GameObject.Find("CircleScores");

        ScoreHandler();
    }

    void ScoreHandler()
    {
        insCrossScores.GetComponent<TMP_Text>().text = 
            System.Convert.ToString(player1Score);
        insCircleScores.GetComponent<TMP_Text>().text = 
            System.Convert.ToString(player2Score);
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
            GameObject Cross =
                Instantiate(insCross,possibleSlots[selectedLocation], Quaternion.identity);

            tempHolder.Add(Cross);

            gameBoard[selectedLocation] = 1;
        }
        else
        {
            GameObject Circle =
                Instantiate(insCircle,possibleSlots[selectedLocation], Quaternion.identity);
            
            tempHolder.Add(Circle);

            gameBoard[selectedLocation] = 2;
        }

        turnCounter = turnCounter + 1;

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
            matchFound = true;
            CrossWon();
            GameObject crossList 
                = Instantiate(insCrossWin, new Vector2(0,2), Quaternion.Euler(0,0,90));
            listWinLine.Add(crossList);
        }
        if(HL2 == 1)
        {
            matchFound = true;
            CrossWon();
            GameObject crossList 
                = Instantiate(insCrossWin, new Vector2(0,0), Quaternion.Euler(0,0,90));
            listWinLine.Add(crossList);
        }
        if(HL3 == 1)
        {
            matchFound = true;
            CrossWon();
            GameObject crossList 
                = Instantiate(insCrossWin, new Vector2(0,-2), Quaternion.Euler(0,0,90));
            listWinLine.Add(crossList);
        }

    //------
        if(VL1 == 1)
        {
            matchFound = true;
            CrossWon();
            GameObject crossList 
                = Instantiate(insCrossWin, new Vector2(-2,0), Quaternion.Euler(0,0,0));
            listWinLine.Add(crossList);
        }
        if(VL2 == 1)
        {
            matchFound = true;
            CrossWon();
            GameObject crossList 
                = Instantiate(insCrossWin, new Vector2(0,0), Quaternion.Euler(0,0,0));
            listWinLine.Add(crossList);
        }
        if(VL3 == 1)
        {
            matchFound = true;
            CrossWon();
            GameObject crossList 
                = Instantiate(insCrossWin, new Vector2(2,0), Quaternion.Euler(0,0,0));
            listWinLine.Add(crossList);
        }

    //------
        if(DL1 == 1)
        {
            matchFound = true;
            CrossWon();
            GameObject crossList 
                = Instantiate(insCrossWin, new Vector2(0,0), Quaternion.Euler(0,0,45));
            listWinLine.Add(crossList);
        }
        if(DL2 == 1)
        {
            matchFound = true;
            CrossWon();
            GameObject crossList
                = Instantiate(insCrossWin, new Vector2(0,0), Quaternion.Euler(0,0,-45));
            listWinLine.Add(crossList);
        }

    //--------------------------------------------------------------------------
        if(HL1 == 2)
        {
            matchFound = true;
            CircleWon();
            GameObject circleList 
                = Instantiate(insCircleWin, new Vector2(0,2), Quaternion.Euler(0,0,90));
            listWinLine.Add(circleList);
        }
        if(HL2 == 2)
        {
            matchFound = true;
            CircleWon();
            GameObject circleList 
                = Instantiate(insCircleWin, new Vector2(0,0), Quaternion.Euler(0,0,90));
            listWinLine.Add(circleList);
        }
        if(HL3 == 2)
        {
            matchFound = true;
            CircleWon();
            GameObject circleList 
                = Instantiate(insCircleWin, new Vector2(0,-2), Quaternion.Euler(0,0,90));
            listWinLine.Add(circleList);
        }

    //------
        if(VL1 == 2)
        {
            matchFound = true;
            CircleWon();
            GameObject circleList 
                = Instantiate(insCircleWin, new Vector2(-2,0), Quaternion.Euler(0,0,0));
            listWinLine.Add(circleList);
        }
        if(VL2 == 2)
        {
            matchFound = true;
            CircleWon();
            GameObject circleList 
                = Instantiate(insCircleWin, new Vector2(0,0), Quaternion.Euler(0,0,0));
            listWinLine.Add(circleList);
        }
        if(VL3 == 2)
        {
            matchFound = true;
            CircleWon();
            GameObject circleList 
                = Instantiate(insCircleWin, new Vector2(2,0), Quaternion.Euler(0,0,0));
            listWinLine.Add(circleList);
        }

    //------
        if(DL1 == 2)
        {
            matchFound = true;
            CircleWon();
            GameObject circleList 
                = Instantiate(insCircleWin, new Vector2(0,0), Quaternion.Euler(0,0,45));
            listWinLine.Add(circleList);
        }
        if(DL2 == 2)
        {
            matchFound = true;
            CircleWon();
            GameObject circleList 
                =Instantiate(insCircleWin, new Vector2(0,0), Quaternion.Euler(0,0,-45));
            listWinLine.Add(circleList);
        }

    //-----------------------------------------------------------------------------
        if(turnCounter == 9 & matchFound == false)
        {
            GameDraw();
        }
    }

    void TurnSwitch()
    {
        print("COWWWWW- TurnSwitch");
    }

    void CrossWon()
    {
        Debug.Log("Player Cross Won!");

        player1Score = player1Score + 1;
        ScoreHandler();

        gameEnded = true;

        Invoke("BoardReset",3);

        gameTurn++;
    }

    void CircleWon()
    {
        Debug.Log("Player Circle Won!");

        player2Score = player2Score + 1;
        ScoreHandler();

        gameEnded = true;

        Invoke("BoardReset",3);

        gameTurn++;
    }

    void GameDraw()
    {
        Debug.Log("Game ended in a Draw!");

        gameEnded = true;

        Invoke("BoardReset",3);

        gameTurn++;
    }

    void BoardReset()
    {
        if(gameTurn > 4)
        {
            TurnSwitch();
        }

        gameEnded = false;
        PlayerID = "default";
        turnCounter = 0;
        matchFound = false;

        foreach(GameObject i in tempHolder)
        {
            Destroy(i);
        }

        for(int i = 0; i < gameBoard.Length; i++)
        {
            gameBoard[i] = 0;
        }

        tempHolder.Clear();

        insInputManager.Reset();

        foreach(GameObject i in listWinLine)
        {
            Destroy(i);
        }
        listWinLine.Clear();
    }
}
