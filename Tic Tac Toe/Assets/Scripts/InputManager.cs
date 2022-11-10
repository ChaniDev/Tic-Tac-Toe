using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    GameManager insGameManager;

//-----
    int insLocationTrigger = 10;
    List<int> validSlots = new List<int>();

    void Start()
    {
        insGameManager = FindObjectOfType<GameManager>();

        for(int i = 0; i < 9; i++)
        {
            validSlots.Add(i);
        }
    }

    public void P1Input(int locationTrigger)
    {
        insLocationTrigger = locationTrigger;

        IsValid();
    }

    void IsValid()
    {
        foreach(int i in validSlots)
        {
            if(insLocationTrigger.Equals(i))
            {
                insGameManager.InputLocation(insLocationTrigger);
                validSlots.Remove(i);
                break;
            }
            else
            {
                Debug.LogWarning("Invalid Location!");
            }
        }
    }
}
