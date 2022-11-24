using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void Start()
    {
        insInputManager = FindObjectOfType<InputManager>();

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
        Debug.Log("Switch");
    }
}
