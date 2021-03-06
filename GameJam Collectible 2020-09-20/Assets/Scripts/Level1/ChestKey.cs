﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestKey : MonoBehaviour
{
    [SerializeField] private Sprite m_OpenedChest;
    [SerializeField] private Level1ObjectInit m_Levels1ObjectInit;

    private bool isTrigger;

    // Update is called once per frame
    void Update()
    {
        if (LevelStates.m_PlayerIsInteracting && isTrigger)
        {

            gameObject.GetComponent<SpriteRenderer>().sprite = m_OpenedChest;

            m_Levels1ObjectInit.ChestOpen();

            Level1States.m_GotTheCoin = false;
            LevelStates.m_PlayerIsInteracting = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Level1States.m_GotTheCoin == true)
        {
            LevelStates.m_PlayerCanInteract = true;
            isTrigger = true;

            LevelStates.Instructions = "Press 'F' to interact";

        }
        else
        {
            LevelStates.Instructions = "Coute 1 piece!";
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(Level1States.m_GotTheCoin == true)
        {
            LevelStates.m_PlayerCanInteract = true;
            isTrigger = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isTrigger = false;

        LevelStates.m_PlayerCanInteract = false;
        LevelStates.Instructions = "";
    }
}
