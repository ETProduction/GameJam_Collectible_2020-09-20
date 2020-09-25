using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl0States : LevelStates
{
    public static Vector3 m_DefaultPosition = new Vector3(1, 0, 0);

    public static bool m_KeyIsPicked = false;

    private void Awake()
    {
        m_CurrentLevel = 0;
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
