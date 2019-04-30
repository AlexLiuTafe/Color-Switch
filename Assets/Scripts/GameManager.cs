using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Transform environment;



    public void Restart()
    {
        //Restart logic for the player
        player.Restart();

        //loop through all children in environmen
        for (int i = 0; i < environment.childCount; i++)
        {
            Transform child = environment.GetChild(i);
            //Destroy each child
            Destroy(child.gameObject);
        }
    }

}
