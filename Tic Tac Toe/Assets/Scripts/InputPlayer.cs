using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputPlayer : MonoBehaviour
{
    InputManager insInputManager;

    bool enableInput = false;
    int PlayerID = 0;

    void Start()
    {
        insInputManager = FindObjectOfType<InputManager>();
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

                enableInput = false;
                insInputManager.TurnManager(i,PlayerID);

                break;
            }
        }
    }
}
