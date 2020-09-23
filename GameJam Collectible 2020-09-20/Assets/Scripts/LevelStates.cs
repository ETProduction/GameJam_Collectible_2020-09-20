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
    public static string m_CurrentTime;
    public static bool m_PickedAppleSeeds;
    public static bool m_CanPlantAppleSeed;
    public static bool m_PlantedAppleSeed;
    public static bool m_PickedApple;
    public static bool m_AppleDropped;


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
        string sceneName = "Level_" + m_CurrentLevel + "_Present";
        SceneManager.LoadScene(sceneName);
    }
}
