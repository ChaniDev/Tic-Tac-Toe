using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    InputID insInputID;

//-----


    void Start()
    {
        insInputID = FindObjectOfType<InputID>();
    }

    public void RequestPlayerInput()
    {
        
    }

    public void RequestCPUInput()
    {

    }
}
