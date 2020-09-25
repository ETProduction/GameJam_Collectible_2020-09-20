using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestKey : MonoBehaviour
{
    [SerializeField] private Sprite m_OpenedChest;
    [SerializeField] private Level1ObjectInit m_Levels1ObjectInit;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(Level1States.m_GotTheCoin == true)
        {
            LevelStates.Instructions = "Vous pouvez ouvrir le coffre avec Z";
            
            if(Input.GetKeyDown(KeyCode.Z))
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = m_OpenedChest;

                m_Levels1ObjectInit.ChestOpen();

                Level1States.m_GotTheCoin = false;
            }
        }
        else
        {
            LevelStates.Instructions = "Coute 1 piece!";
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        LevelStates.Instructions = "";
    }
}
