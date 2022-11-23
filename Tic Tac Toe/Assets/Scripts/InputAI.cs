using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputAI : MonoBehaviour
{
    InputManager insInputManager;

    int playerID = 1;

    void Start()
    {
        insInputManager = FindObjectOfType<InputManager>();
    }

    public void RequestInput()
    {
        Debug.Log("YEs");
    }
}
