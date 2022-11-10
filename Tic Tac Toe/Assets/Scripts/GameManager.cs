using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject Cross;
    [SerializeField] private GameObject Circle;


    Vector2[] allLocation = new Vector2[] 
        {
            new Vector2(-2,2),
            new Vector2(0,2),
            new Vector2(2,2),
            new Vector2(-2,0),
            new Vector2(0,0),
            new Vector2(2,0),
            new Vector2(-2,-2),
            new Vector2(0,-2),
            new Vector2(2,-2)
        };

    public void InputLocation(int triggerLocation, string Player)
    {
        if(Player == "Human")
        {
            Instantiate(Cross, allLocation[Random.Range(0,9)], Quaternion.identity);
        }
        else if(Player == "CPU")
        {

        }
        else
        {
            Debug.LogError("No Player Defined");
            Application.Quit();
        }
    }
}
