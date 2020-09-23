using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl2States : LevelStates
{
    // Start is called before the first frame update
    public static bool m_SpikeFloorIsDown;
    public static bool m_SpikeWall1IsDown;
    public static bool m_SpikeWall2IsDown;
    public static bool m_SpikeWall3IsDown;

    [SerializeField] public static GameObject m_SpikeWall1;
    [SerializeField] public static GameObject m_SpikeWall2;

    internal static bool LeverIsOff(int m_LeverIndex)
    {
        switch (m_LeverIndex)
        {
            case 1:
                return m_SpikeFloorIsDown;
                break;
            default:
                return false;
                break;
        }
    }

    [SerializeField] public static GameObject m_SpikeWall3;
    [SerializeField] public static GameObject m_SpikeFloor;

    private void Start()
    {
        LevelStates.m_CurrentLevel = 2;
        for(int i =0; i< GameObject.FindGameObjectsWithTag("Spike").Length; i++)
        {
            if (GameObject.FindGameObjectsWithTag("Spike")[i].name.Contains("Floor"))
            {
                m_SpikeFloor = GameObject.FindGameObjectsWithTag("Spike")[i];
            }
            else if (GameObject.FindGameObjectsWithTag("Spike")[i].name.Contains("Wall1"))
            {
                m_SpikeWall1 = GameObject.FindGameObjectsWithTag("Spike")[i];

            }
            else if (GameObject.FindGameObjectsWithTag("Spike")[i].name.Contains("Wall2"))
            {
                m_SpikeWall2 = GameObject.FindGameObjectsWithTag("Spike")[i];

            }
            else if (GameObject.FindGameObjectsWithTag("Spike")[i].name.Contains("Wall3"))
            {
                m_SpikeWall3 = GameObject.FindGameObjectsWithTag("Spike")[i];

            }
        }
       
    }

    internal static void ChangeSpikeStates(int m_LeverIndex)
    {
        switch (m_LeverIndex)
        {
            case 1:
                m_SpikeFloorIsDown = !m_SpikeFloorIsDown;
                break;
            default:
                break;
        }
    }
}
