using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject prefabCross;
    [SerializeField] private GameObject prefabCircle;


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

    public void Initiate(int triggerLocation, string playerID)
    {
        if(playerID == "Human")
        {
            Instantiate(prefabCross, allLocation[Random.Range(0,9)], Quaternion.identity);
        }
        else if(playerID == "CPU")
        {
            Instantiate(prefabCircle, allLocation[Random.Range(0,9)], Quaternion.identity);
        }
        else
        {
            Debug.LogError("No Player Defined- -GameManager");
            Application.Quit();
        }
    }
}
