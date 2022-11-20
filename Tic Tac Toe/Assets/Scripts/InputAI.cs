using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputAI : MonoBehaviour
{
    int selectedSlot = 0;
    

    public int locationTrigger(List<int> validSlots)
    {
        if(validSlots.Count <= 0)
        {
            return(0);
        }

           

        return(selectedSlot);
    }
}
