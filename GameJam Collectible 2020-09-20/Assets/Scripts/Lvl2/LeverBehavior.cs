using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverBehavior : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private GameObject m_Lever;
    [SerializeField] private Sprite m_OffStates;
    [SerializeField] private Sprite m_OnStates;
    [SerializeField] private int m_LeverIndex;

    private float m_lastleverInteraction=0;
    private float m_leverCooldown = 0.3f;

    private bool isTrigger;
 
    void Update()
    {

        

        if (Lvl2States.LeverIsOff(m_LeverIndex))
        {
            m_Lever.GetComponent<SpriteRenderer>().sprite = m_OffStates;
        }
        else
        {
            m_Lever.GetComponent<SpriteRenderer>().sprite = m_OnStates;
        }

        if (LevelStates.m_PlayerIsInteracting && isTrigger)
        {
            
            leverAction();          
            LevelStates.m_PlayerIsInteracting = false;
        }
    }

    private void leverCooldown()
    {

        if (m_lastleverInteraction > (Time.timeSinceLevelLoad -m_leverCooldown))
        {
           isTrigger = false;
        }
        else
        {
            isTrigger = false;


        }
    }

    private void leverAction()
    {
        if (Lvl2States.m_SpikeFloorIsDown)
        {

            m_Lever.GetComponent<SpriteRenderer>().sprite = m_OffStates;
            Lvl2States.ChangeSpikeStates(m_LeverIndex);
        }
        else
        {
      
            m_Lever.GetComponent<SpriteRenderer>().sprite = m_OnStates;
            Lvl2States.ChangeSpikeStates(m_LeverIndex);
        }
        m_lastleverInteraction = Time.timeSinceLevelLoad;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        LevelStates.m_PlayerCanInteract = true;
        isTrigger = true;
       
        LevelStates.Instructions = "Press 'F' to interact";
        
       
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        LevelStates.m_PlayerCanInteract = true;
        isTrigger = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isTrigger = false;
        LevelStates.m_PlayerCanInteract = false;
        LevelStates.Instructions = "";

    }

}
