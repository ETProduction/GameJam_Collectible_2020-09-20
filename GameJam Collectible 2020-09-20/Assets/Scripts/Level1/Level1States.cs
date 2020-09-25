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
    public static int m_NbrOfTileReste;
    public static bool m_CanOpenSecondBridge;
    public static bool m_IsBridge2;
    public static bool m_KeyIsPicked = false;

    public static bool m_GotTheCoin;
    public static Vector3 m_DefaultPosition = new Vector3(-9.52f, 2.31f, 0);

    public static string m_PreviousPlate;
    public static int m_NbrOfTilePress;

    // Start is called before the first frame update
    void Awake()
    {
        m_CurrentLevel = 1;

        if (m_PlayerIsDead)
        {
            m_PlayerPosition = new Vector3(-9.52f, 2.31f, 0);
        }
    }


    public static void setKeyStates(int keyIndex)
    {
        switch (keyIndex)
        {
            case 0:
                m_KeyIsPicked = true;
                break;
            default:
                break;
        }
    }
}
