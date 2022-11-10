using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    GameManager insGameManager;

    void Start()
    {
        insGameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            insGameManager.InputLocation(5 ,"Human");
        }
    }
}
