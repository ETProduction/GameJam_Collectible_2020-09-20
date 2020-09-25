using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exchanger : MonoBehaviour
{
    [SerializeField] private Level0ObjectsInit m_Levels0ObjectInit;

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

            m_Levels0ObjectInit.InitApple("DROP");

            LevelStates.m_PickedApple = false;
            LevelStates.m_PlayerIsInteracting = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (LevelStates.m_PickedApple == true)
        {
            LevelStates.m_PlayerCanInteract = true;
            isTrigger = true;

            LevelStates.Instructions = "Press 'F' to interact";
        }
        else
        {
            LevelStates.Instructions = "Nothing to exchange!";
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (LevelStates.m_PickedApple == true)
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
