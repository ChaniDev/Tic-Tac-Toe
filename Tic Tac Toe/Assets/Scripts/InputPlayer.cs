using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPlayer : MonoBehaviour
{
    InputManager insInputManager;

//----
    int locationTrigger;

    void Start()
    {
        insInputManager = FindObjectOfType<InputManager>();
    }

    void OnMouseDown()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            locationTrigger = System.Convert.ToInt32(this.gameObject.name);

            insInputManager.PlayerInput(locationTrigger);
        }
    }
}
