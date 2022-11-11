using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputAI : MonoBehaviour
{
    int selectedRandom = 0;
    bool randomFound = false;

    public int locationTrigger(List<int> validSlots)
    {
        if(validSlots.Count <= 0)
        {
            return(0);
        }

        while(!randomFound)
        {
            int r = Random.Range(0,9);
            foreach(int i in validSlots)
            {
                if(r == i)
                {
                    randomFound = true;
                    selectedRandom = r;
                }
            }
        }

        randomFound = false;
        return(selectedRandom);
    }
}
