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
    public static bool m_SpikeDoor5IsDown;

    public static GameObject m_SpikeWall1;
    public static GameObject m_SpikeWall2;
    public static GameObject m_SpikeWall3;
    public static GameObject m_SpikeFloor;

    public static GameObject m_SpikeDoor1;
    public static GameObject m_SpikeDoor2;
    public static GameObject m_SpikeDoor3;
    public static GameObject m_SpikeDoor4;
    public static GameObject m_SpikeDoor5;

    public static bool m_Key1IsPicked = false;
    public static bool m_Key2IsPicked = false;
    public static bool m_Key3IsPicked = false;
    public static Vector3 m_DefaultPosition = new Vector3(1,0,0);

    internal static bool LeverIsOff(int m_LeverIndex)
    {
        switch (m_LeverIndex)
        {
            case 1:
                return m_SpikeFloorIsDown;
            case 2:
                return m_SpikeWall3IsDown;
            case 3:
                return m_SpikeWall2IsDown;
            case 4:
                return m_SpikeWall1IsDown;
            case 5:
                return m_SpikeDoor5IsDown;
            default:
                return false;

        }
    }
    private void Awake()
    {
        LevelStates.m_CurrentLevel = 2;
        if (LevelStates.m_PlayerIsDead)
        {
            LevelStates.m_PlayerPosition = new Vector3(1, 0, 0);
            m_SpikeFloorIsDown = false;
            m_SpikeWall1IsDown = false;
            m_SpikeWall2IsDown = false;
            m_SpikeWall3IsDown = false;
            m_SpikeDoor5IsDown = false;
        }
    }
    private void Start()
    {

        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Spike").Length; i++)
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
            else if (GameObject.FindGameObjectsWithTag("Spike")[i].name.Contains("Door"))
            {
                if (GameObject.FindGameObjectsWithTag("Spike")[i].name.Contains("1"))
                {
                    m_SpikeDoor1 = GameObject.FindGameObjectsWithTag("Spike")[i];
                }
                else if (GameObject.FindGameObjectsWithTag("Spike")[i].name.Contains("2"))
                {
                    m_SpikeDoor2 = GameObject.FindGameObjectsWithTag("Spike")[i];
                }
                else if (GameObject.FindGameObjectsWithTag("Spike")[i].name.Contains("3"))
                {
                    m_SpikeDoor3 = GameObject.FindGameObjectsWithTag("Spike")[i];
                }
                else if (GameObject.FindGameObjectsWithTag("Spike")[i].name.Contains("4"))
                {
                    m_SpikeDoor4 = GameObject.FindGameObjectsWithTag("Spike")[i];
                }
                else if (GameObject.FindGameObjectsWithTag("Spike")[i].name.Contains("5"))
                {
                    m_SpikeDoor5 = GameObject.FindGameObjectsWithTag("Spike")[i];
                }

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
            case 2:
                m_SpikeWall3IsDown = !m_SpikeWall3IsDown;
                break;
            case 3:
                m_SpikeWall2IsDown = !m_SpikeWall2IsDown;
                break;
            case 4:
                m_SpikeWall1IsDown = !m_SpikeWall1IsDown;
                break;
            case 5:
                m_SpikeDoor5IsDown = !m_SpikeDoor5IsDown;
                break;
            default:
                break;
        }
    }
    public static void setKeyStates(int keyIndex)
    {
        switch (keyIndex)
        {
            case 1:
                m_Key1IsPicked = true;
                break;
            case 2:
                m_Key2IsPicked = true;

                break;
            case 3:
                m_Key3IsPicked = true;

                break;
            default:
                break;
        }
    }

    public static bool getKeyIsPicked(int m_KeyIndex)
    {
        switch (m_KeyIndex)
        {
            case 1:
                return m_Key1IsPicked;
            case 2:
                return m_Key2IsPicked;
            case 3:
                return m_Key3IsPicked;
            default:
                return false;
        }
    }
}