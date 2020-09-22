using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelStates : MonoBehaviour
{
    public static int m_numberOfKey;
    public static string m_LvlPast;
    public static string m_LvlPresent;
    public static string m_LvlFutur;
    public static int m_CurrentLevel;

    public static bool m_PickedAppleSeeds;
    public static bool m_CanPlantAppleSeed;
    public static bool m_PlantedAppleSeed;


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
        switch (level)
        {
            case 0:
                m_LvlPast = "Level_0_Past";
                break;
            case 100000:
                m_LvlPast = "Level_0_Past_TestUI";
                break;
            default:
                m_LvlPast = SceneManager.GetActiveScene().name;
                break;
        }
        return m_LvlPast;
    }

    public static string getLvlPresent(int level)
    {
        switch (level)
        {
            case 0:
                m_LvlPresent = "Level_0_Present";
                break;
            case 100000:
                m_LvlPresent = "Level_0_Present_TestUI";
                break;
            default:
                m_LvlPresent = SceneManager.GetActiveScene().name;
                break;
        }
        return m_LvlPresent;
    }
    public static string getLvlFuture(int level)
    {
        switch (level)
        {
            case 0:
                m_LvlFutur = "Level_0_Future";
                break;
            case 100000:
                m_LvlFutur = "Level_0_Future_TestUI";
                break;
            default:
                m_LvlFutur = SceneManager.GetActiveScene().name;
                break;
        }
        return m_LvlFutur;
    }
}
