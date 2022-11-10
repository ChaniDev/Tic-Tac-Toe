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

    public int RequestP1Input()
    {
        return(10);
    }

    public int RequestP2Input()
    {
        return(10);
    }
}
