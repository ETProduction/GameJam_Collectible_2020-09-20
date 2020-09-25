using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlatesFuture : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.name.Equals("Plate1"))
        {
            LevelStates.Instructions = "Plaque1";
        }
        else if (gameObject.name.Equals("Plate2"))
        {
            LevelStates.Instructions = "Plaque2";
        }
        else if (gameObject.name.Equals("Plate3"))
        {
            LevelStates.Instructions = "Plaque3";
        }
        else if (gameObject.name.Equals("Plate4"))
        {
            LevelStates.Instructions = "Plaque4";
        }
        else
        {
            LevelStates.Instructions = "Plaque5";
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
          LevelStates.Instructions = "";
    }
}
