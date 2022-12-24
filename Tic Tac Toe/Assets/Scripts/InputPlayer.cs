using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputPlayer : MonoBehaviour
{
    InputManager insInputManager;
    GameState insGameState;

    bool enableInput = false;
    int playerID = 2;

    void Start()
    {
        insInputManager = FindObjectOfType<InputManager>();
        insGameState = FindObjectOfType<GameState>();
    }

    public void RequestInput()
    {
        enableInput = true;
    }

    public void ButtonClick()
    {
        if(enableInput)
        {
            int buttonName = System.Convert.ToInt32(
                EventSystem.current.currentSelectedGameObject.name);

            IfValid(buttonName);
        }
    } 

    void IfValid(int insButtonName)
    {
        foreach(int i in InputManager.validSlotID)
        {
            if(insButtonName.Equals(i))
            {
                InputManager.validSlotID.Remove(i);
                InputManager.Board[i] = 2;

                enableInput = false;
                insInputManager.TurnManager(i,playerID);

                insGameState.CheckBoard();

                break;
            }
        }
    }
}
