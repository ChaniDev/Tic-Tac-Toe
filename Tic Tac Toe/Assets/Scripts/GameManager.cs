using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    InputManager insInputManager;
    InputAI insInputAI;
    SoundHandler insSoundHandler;

    [SerializeField] private bool AI = true;

    [SerializeField] private GameObject Cross;
    [SerializeField] private GameObject Circle;
    [SerializeField] private GameObject WinCross;
    [SerializeField] private GameObject WinCircle;

    List<GameObject> graphicsHolder = new List<GameObject>();
    Vector2[] plotLocation = new Vector2[]
    {
        new Vector2(-2,2),
        new Vector2(0,2),
        new Vector2(2,2),
        new Vector2(-2,0),
        new Vector2(0,0),
        new Vector2(2,0),
        new Vector2(-2,-2),
        new Vector2(0,-2),
        new Vector2(2,-2),
    };
    
    Vector3[] winPosition = new Vector3[]
    {
        new Vector3(0,2,90),
        new Vector3(0,0,90),
        new Vector3(0,-2,90),
        new Vector3(-2,0,0),
        new Vector3(0,0,0),
        new Vector3(2,0,0),
        new Vector3(0,0,45),
        new Vector3(0,0,-45)
    };

    TextMeshProUGUI nameAI;
    TextMeshProUGUI scoreAI;
    TextMeshProUGUI namePlayer;
    TextMeshProUGUI scorePlayer;

    [SerializeField] GameObject winScreen;
    [SerializeField] GameObject loseScreen;
    [SerializeField] GameObject drawScreen;

    void Update()
    {
       insInputAI.SettingsAI(AI);
    }

    void Start()
    {
        insInputManager = FindObjectOfType<InputManager>();
        insInputAI = FindObjectOfType<InputAI>();
        insSoundHandler = FindObjectOfType<SoundHandler>();

        nameAI = GameObject.Find("AI").GetComponent<TMPro.TextMeshProUGUI>();
        scoreAI = GameObject.Find("CircleScores").GetComponent<TMPro.TextMeshProUGUI>();

        namePlayer = GameObject.Find("Player").GetComponent<TMPro.TextMeshProUGUI>();
        scorePlayer = GameObject.Find("CrossScores").GetComponent<TMPro.TextMeshProUGUI>();

        StartGame();
    }

    void StartGame()
    {
        insInputManager.TriggerStartTurn();
    }

    public void DisplayHandler(int insSelectedLocation, 
        int insPlayerID, bool insPlayerIsCross)
    {
        if(insPlayerIsCross == true)
        {
            if(insPlayerID == 2)
            {
                graphicsHolder.Add(
                Instantiate(Cross, plotLocation[insSelectedLocation], Quaternion.identity));
            }
            else
            {
                graphicsHolder.Add(
                Instantiate(Circle, plotLocation[insSelectedLocation], Quaternion.identity));
            }

            insSoundHandler.PlaySFX("Click");
        }
        else
        {
            if(insPlayerID == 1)
            {
                graphicsHolder.Add(
                Instantiate(Cross, plotLocation[insSelectedLocation], Quaternion.identity));
            }
            else
            {
                graphicsHolder.Add(
                Instantiate(Circle, plotLocation[insSelectedLocation], Quaternion.identity));
            }

            insSoundHandler.PlaySFX("Click");
        }      
    }

    public void WinHandler(bool isPlayerCross, int drawLocation, int playerID)
    {
        if(isPlayerCross && playerID == 1)
        {
            graphicsHolder.Add(
            Instantiate(WinCircle, 
            new Vector3(winPosition[drawLocation].x, winPosition[drawLocation].y,0), 
            Quaternion.Euler(0,0,winPosition[drawLocation].z)));
            
            ScoreSystem(1);
        }
        else if(!isPlayerCross && playerID == 1)
        {
            graphicsHolder.Add(
            Instantiate(WinCross, 
            new Vector3(winPosition[drawLocation].x, winPosition[drawLocation].y,0), 
            Quaternion.Euler(0,0,winPosition[drawLocation].z)));

            ScoreSystem(2);
        }
        else if(isPlayerCross && playerID == 2)
        {
            graphicsHolder.Add(
            Instantiate(WinCross, 
            new Vector3(winPosition[drawLocation].x, winPosition[drawLocation].y,0), 
            Quaternion.Euler(0,0,winPosition[drawLocation].z)));

            ScoreSystem(2);
        }
        else if(!isPlayerCross && playerID == 2)
        {
            graphicsHolder.Add(
            Instantiate(WinCircle, 
            new Vector3(winPosition[drawLocation].x, winPosition[drawLocation].y,0), 
            Quaternion.Euler(0,0,winPosition[drawLocation].z)));

            ScoreSystem(1);
        }
    }

    void ScoreSystem(int playerID)
    {
        if(playerID == 1)
        {
            int currentAIScore = System.Convert.ToInt32(scoreAI.text);
            currentAIScore++;

            scoreAI.text = System.Convert.ToString(currentAIScore);
        }
        else if(playerID == 2)
        {
            int currentPlayerScore = System.Convert.ToInt32(scorePlayer.text);
            currentPlayerScore++;

            scorePlayer.text = System.Convert.ToString(currentPlayerScore);
        }
    }

    public void GameReset()
    {
        for(int i = 0; i < graphicsHolder.Count; i++)
        {
            Destroy(graphicsHolder[i]);
        }
        graphicsHolder.Clear();

        DrawResult("Reset");

        insInputManager.Reset();
    }

    public void PlayerSwitch()
    {
        if(namePlayer.text == "-Player" & nameAI.text == "-AI")
        {
            string playerName = namePlayer.text;
            string playerScores = scorePlayer.text;
            string aiName = nameAI.text;
            string aiScores = scoreAI.text;

            namePlayer.text = aiName;
            scorePlayer.text = aiScores;
            nameAI.text = playerName;
            scoreAI.text = playerScores;
        }
        else
        {
            string playerName = namePlayer.text;
            string playerScores = scorePlayer.text;
            string aiName = nameAI.text;
            string aiScores = scoreAI.text;
            
            namePlayer.text = aiName;
            scorePlayer.text = aiScores;
            nameAI.text = playerName;
            scoreAI.text = playerScores;
        }
    }

    public void DrawResult(string Result)
    {
        if(Result == "Win")
        {
            winScreen.SetActive(true);
            insSoundHandler.PlaySFX("Win");
        }
        else if(Result == "Lose")
        {
            loseScreen.SetActive(true);
            insSoundHandler.PlaySFX("Lose");
        }
        else if(Result == "Draw")
        {
            drawScreen.SetActive(true);
            insSoundHandler.PlaySFX("Draw");
        }
        else if(Result == "Reset")
        {
            winScreen.SetActive(false);
            loseScreen.SetActive(false);
            drawScreen.SetActive(false);
        }
    }
}
