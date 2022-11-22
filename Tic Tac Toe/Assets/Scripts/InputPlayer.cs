using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPlayer : MonoBehaviour
{
    InputManager insInputManager;

    void Start()
    {
        insInputManager = FindObjectOfType<InputManager>();
    }

    public void turnPlayer()
    {
        StartCoroutine(RequestInput());
    }
    private IEnumerator RequestInput()
    {
        while(!Input.GetKeyDown(KeyCode.Mouse0))
        {
            yield return null;
        }

        Debug.Log("--Input By Player--");
        insInputManager.TurnManager();
    }
}
