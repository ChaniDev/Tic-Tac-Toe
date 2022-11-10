using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputID : MonoBehaviour
{
    InputManager insInputManager;
    string TriggerID = "Default";

    void Start()
    {
        insInputManager = FindObjectOfType<InputManager>();
    }

    void OnMouseDown()
    {
        if(Input.GetKey(KeyCode.Mouse0))
        {
            Debug.Log("CLICK!");
            DisableTrigger();
        }
    }

    void DisableTrigger()
    {
        this.gameObject.SetActive(false);
    }
}
