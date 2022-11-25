using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    InputManager insInputManager;

    [SerializeField] private GameObject Cross;
    [SerializeField] private GameObject Circle;

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

    TextMeshProUGUI nameAI;
    TextMeshProUGUI scoreAI;
    TextMeshProUGUI namePlayer;
    TextMeshProUGUI scorePlayer;

    void Start()
    {
        insInputManager = FindObjectOfType<InputManager>();

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
            if(insPlayerID == 0)
            {
                graphicsHolder.Add(
                Instantiate(Cross, plotLocation[insSelectedLocation], Quaternion.identity));
            }
            else
            {
                graphicsHolder.Add(
                Instantiate(Circle, plotLocation[insSelectedLocation], Quaternion.identity));
            }
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
        }      
    }

    public void GameReset()
    {
        for(int i = 0; i < graphicsHolder.Count; i++)
        {
            Destroy(graphicsHolder[i]);
        }
        graphicsHolder.Clear();

        insInputManager.Reset();
    }

    public void PlayerSwitch()
    {
        print(namePlayer.text);
        print(nameAI.text);

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
}
