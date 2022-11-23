using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputPlayer : MonoBehaviour
{
    InputManager insInputManager;

    bool enableInput = false;
    string buttonName = "100";

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
            // enableInput = false;
            buttonName = EventSystem.current.currentSelectedGameObject.name;
            print (buttonName);
        }
    } 
}
