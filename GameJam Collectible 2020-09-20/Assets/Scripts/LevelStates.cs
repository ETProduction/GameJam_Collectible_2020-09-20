﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelStates : MonoBehaviour
{
    public static bool m_PlayerIsDead;
    public static int m_numberOfKey;
    public static string m_LvlPast;

    
    public static string m_LvlPresent;
    public static string m_LvlFutur;
    public static int m_CurrentLevel;
    public static string m_CurrentTime ="Present";
    public static bool m_PickedAppleSeeds;
    public static bool m_InitAppleSeeds;
    public static bool m_CanPlantAppleSeed;
    public static bool m_PlantedAppleSeed;
    public static bool m_PickedApple;
    public static bool m_AppleDropped;
    public static bool m_PlayerCanInteract;
    public static bool m_PlayerIsInteracting;
    public static Vector3 m_PlayerPosition = new Vector3(0,0,0);

    internal static void setCurrentLevel(string name)
    {
        if (name.Contains("Past"))
        {
            m_CurrentTime = "Past";
        }
        else if (name.Contains("Present"))
        {
            m_CurrentTime = "Present";

        }
        else if (name.Contains("Future"))
        {
            m_CurrentTime = "Future";
        }
        else
        {
            m_CurrentTime = "Present";
        }
    }

    public static bool m_OnExchanger;
    public static bool m_KeyPicked;

    private static string m_Instructions;

    public static string Instructions { get => m_Instructions; set => m_Instructions = value; }


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static string getLvlPast(int level)
    {
        string lvlName = "Level_" + level + "_Past";
        return lvlName;
    }

    public static string getLvlPresent(int level)
    {
        string lvlName = "Level_" + level + "_Present";
       
        return lvlName;
    }
    public static string getLvlFuture(int level)
    {
        string lvlName = "Level_" + level + "_Future";
       
        return lvlName;
    }

    public static void loadLvl()
    {
        if (m_CurrentLevel != 1)
        {
            m_PlayerPosition = Vector3.zero;
        }
        else
        {
            m_PlayerPosition = Level1States.m_DefaultPosition;
        }

        string sceneName = "Level_" + m_CurrentLevel + "_Present";
        SceneManager.LoadScene(sceneName);
    }

    public static void setKeyStates(int key)
    {
        switch (m_CurrentLevel)
        {
            case 0:
                Lvl0States.setKeyStates(key);
                break;
            case 1:
                Level1States.setKeyStates(key);
                break;
            case 2:
                Lvl2States.setKeyStates(key);
                break;
            default:
                break;
        }
    }
    public static bool getKeyIsPicked(int m_KeyIndex)
    {
        switch (m_KeyIndex)
        {
            case 2:
                return Lvl2States.getKeyIsPicked(m_KeyIndex);

            default:
                return false;
        }
        
    }

    public static void goBackInTime()
    {
        Debug.Log(m_CurrentTime);
        if(m_CurrentTime == "Future")
        {
            SceneManager.LoadScene(getLvlPresent(m_CurrentLevel), LoadSceneMode.Single);
            m_CurrentTime = "Present";
        }
        else if (m_CurrentTime == "Present")
        {
            SceneManager.LoadScene(getLvlPast(m_CurrentLevel), LoadSceneMode.Single);
            m_CurrentTime = "Past";
        }
    }
    public static void goFowardInTime()
    {
        if (m_CurrentTime == "Past")
        {
            SceneManager.LoadScene(getLvlPresent(m_CurrentLevel), LoadSceneMode.Single);
            m_CurrentTime = "Present";
        }else
        if (m_CurrentTime == "Present")
        {
            SceneManager.LoadScene(getLvlFuture(m_CurrentLevel), LoadSceneMode.Single);
            m_CurrentTime = "Future";
        }
    }

}
