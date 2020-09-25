using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonWall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(LevelStates.m_CurrentTime == "Past")
        {
            LevelStates.Instructions = "Appuyez sur le bouton avec Z pour allumer les torches du présent.";

            if (Input.GetKeyDown(KeyCode.Z))
            {
                Level1States.m_IsButtonPressed = true;
            }
        }

        if (LevelStates.m_CurrentTime == "Future")
        {
            LevelStates.Instructions = "Appuyez sur le bouton avec Z pour remmetre à zéro les tuiles.";

            if (Input.GetKeyDown(KeyCode.Z))
            {
                Level1States.m_ResetTile = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        LevelStates.Instructions = "";
    }
}
