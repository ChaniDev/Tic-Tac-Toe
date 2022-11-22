using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPlayer : MonoBehaviour
{
    bool enableInput = false;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) & enableInput)
        {
            Debug.Log("HIT");

            enableInput = false;
        }
    } 

    public void turnPlayer()
    {
        enableInput = true;
    }
}
