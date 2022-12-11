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
}
