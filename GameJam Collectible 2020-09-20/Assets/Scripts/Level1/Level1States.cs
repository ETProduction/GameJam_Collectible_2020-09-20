using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1States : LevelStates
{
    public static bool m_IsButtonPressed;
    public static bool m_TorchLight1;
    public static bool m_TorchLight2;
    public static bool m_IsBridge1;

    public static bool m_Plate1Activated;
    public static bool m_Plate2Activated;
    public static bool m_Plate3Activated;
    public static bool m_Plate4Activated;
    public static bool m_Plate5Activated;

    public static bool m_IsOrderGood;
    public static bool m_ResetTile;
    public static bool m_CanOpenSecondBridge;
    public static bool m_IsBridge2;

    public static bool m_GotTheCoin;

    // Start is called before the first frame update
    void Start()
    {
        m_CurrentLevel = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
