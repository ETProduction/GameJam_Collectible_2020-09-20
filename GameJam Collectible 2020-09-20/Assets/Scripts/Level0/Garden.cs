using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garden : MonoBehaviour
{
    private bool isTrigger;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (LevelStates.m_PlayerIsInteracting && isTrigger)
        {

            LevelStates.m_PlantedAppleSeed = true;
            LevelStates.m_PickedAppleSeeds = false;

            LevelStates.m_PlayerIsInteracting = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (LevelStates.m_PickedAppleSeeds == true && LevelStates.m_CurrentTime == "Past")
        {
            LevelStates.m_PlayerCanInteract = true;
            isTrigger = true;

            LevelStates.Instructions = "Press 'F' to interact";
        }
        else if (LevelStates.m_PickedAppleSeeds == true && LevelStates.m_CurrentTime != "Past")
        {
            LevelStates.Instructions = "Wrong time to plant!";
        }
        else
        {
            LevelStates.Instructions = "No seed!";
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (LevelStates.m_PickedAppleSeeds == true)
        {
            LevelStates.m_PlayerCanInteract = true;
            isTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isTrigger = false;

        LevelStates.m_PlayerCanInteract = false;
        LevelStates.Instructions = "";
    }
}
