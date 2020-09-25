using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonWall : MonoBehaviour
{
    private bool isTrigger;

    // Update is called once per frame
    void Update()
    {
        if (LevelStates.m_PlayerIsInteracting && isTrigger)
        {
            if (LevelStates.m_CurrentTime == "Past")
            {

                Level1States.m_IsButtonPressed = true;

            }

            if (LevelStates.m_CurrentTime == "Future")
            {
                Level1States.m_ResetTile = true;
            }

            LevelStates.m_PlayerIsInteracting = false;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        LevelStates.m_PlayerCanInteract = true;
        isTrigger = true;

        LevelStates.Instructions = "Press 'F' to interact";
    }

    private void OnTriggerStay2D(Collider2D collision)
    {   

        LevelStates.m_PlayerCanInteract = true;
        isTrigger = true;         

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isTrigger = false;

        LevelStates.m_PlayerCanInteract = false;
        LevelStates.Instructions = "";
    }
}
