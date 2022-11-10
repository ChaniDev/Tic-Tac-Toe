using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputID : MonoBehaviour
{
    int locationTrigger;

    void OnMouseDown()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            locationTrigger = System.Convert.ToInt32(this.gameObject.name);
        }
    }
}
