using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlates : MonoBehaviour
{
    [SerializeField] private Sprite m_ActivatedTileSprite;
    [SerializeField] private GameObject m_PreviousPlate;
    [SerializeField] private Sprite m_OldSprite;

    // Start is called before the first frame update
    void Start()
    {
        if(gameObject.name.Equals("Plate1") && Level1States.m_Plate1Activated == true)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = m_ActivatedTileSprite;
        }

        if (gameObject.name.Equals("Plate2") && Level1States.m_Plate2Activated == true)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = m_ActivatedTileSprite;
        }

        if (gameObject.name.Equals("Plate3") && Level1States.m_Plate3Activated == true)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = m_ActivatedTileSprite;
        }

        if (gameObject.name.Equals("Plate4") && Level1States.m_Plate4Activated == true)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = m_ActivatedTileSprite;
        }

        if (gameObject.name.Equals("Plate5") && Level1States.m_Plate5Activated == true)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = m_ActivatedTileSprite;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(Level1States.m_ResetTile == true)
        {
            if (gameObject.name.Equals("Plate1"))
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = m_OldSprite;
                Level1States.m_NbrOfTileReste = Level1States.m_NbrOfTileReste + 1;
                Level1States.m_Plate1Activated = false;
            }

            if (gameObject.name.Equals("Plate2"))
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = m_OldSprite;
                Level1States.m_NbrOfTileReste = Level1States.m_NbrOfTileReste + 1;
                Level1States.m_Plate2Activated = false;
            }

            if (gameObject.name.Equals("Plate3"))
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = m_OldSprite;
                Level1States.m_NbrOfTileReste = Level1States.m_NbrOfTileReste + 1;
                Level1States.m_Plate3Activated = false;
            }

            if (gameObject.name.Equals("Plate4"))
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = m_OldSprite;
                Level1States.m_NbrOfTileReste = Level1States.m_NbrOfTileReste + 1;
                Level1States.m_Plate4Activated = false;
            }

            if (gameObject.name.Equals("Plate5"))
            {            
                gameObject.GetComponent<SpriteRenderer>().sprite = m_OldSprite;
                Level1States.m_NbrOfTileReste = Level1States.m_NbrOfTileReste + 1;
                Level1States.m_Plate5Activated = false;
            }

            if(Level1States.m_NbrOfTileReste == 5)
            {
                Level1States.m_ResetTile = false;
                Level1States.m_NbrOfTileReste = 0;
                Level1States.m_NbrOfTilePress = 0;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.name.Equals("Plate1"))
        {
            if (m_PreviousPlate.name == Level1States.m_PreviousPlate)
            {
                Level1States.m_IsOrderGood = true;
            }
            else
            {
                Level1States.m_IsOrderGood = false;
            }

            Level1States.m_PreviousPlate = "Plate1";
            Level1States.m_Plate1Activated = true;
            Level1States.m_NbrOfTilePress = Level1States.m_NbrOfTilePress + 1;
        }
        else if (gameObject.name.Equals("Plate2"))
        {
            if (m_PreviousPlate.name == Level1States.m_PreviousPlate)
            {
                Level1States.m_IsOrderGood = true;
            }
            else
            {
                Level1States.m_IsOrderGood = false;
            }

            Level1States.m_PreviousPlate = "Plate2";
            Level1States.m_Plate2Activated = true;
            Level1States.m_NbrOfTilePress = Level1States.m_NbrOfTilePress + 1;
        }
        else if (gameObject.name.Equals("Plate3"))
        {
            if (m_PreviousPlate.name == Level1States.m_PreviousPlate)
            {
                Level1States.m_IsOrderGood = true;
            }
            else
            {
                Level1States.m_IsOrderGood = false;
            }

            Level1States.m_PreviousPlate = "Plate3";
            Level1States.m_Plate3Activated = true;
            Level1States.m_NbrOfTilePress = Level1States.m_NbrOfTilePress + 1;
        }
        else if (gameObject.name.Equals("Plate4"))
        {
            if (m_PreviousPlate.name == Level1States.m_PreviousPlate)
            {
                Level1States.m_IsOrderGood = true;
            }
            else
            {
                Level1States.m_IsOrderGood = false;
            }

            Level1States.m_PreviousPlate = "Plate4";
            Level1States.m_Plate4Activated = true;
            Level1States.m_NbrOfTilePress = Level1States.m_NbrOfTilePress + 1;
        }
        else
        {
            if (m_PreviousPlate.name == Level1States.m_PreviousPlate)
            {
                Level1States.m_IsOrderGood = true;
            }
            else
            {
                Level1States.m_IsOrderGood = false;
            }

            Level1States.m_PreviousPlate = "Plate5";
            Level1States.m_Plate5Activated = true;
            Level1States.m_NbrOfTilePress = Level1States.m_NbrOfTilePress + 1;

            if (Level1States.m_IsOrderGood == true && Level1States.m_NbrOfTilePress == 5)
            {
                Level1States.m_CanOpenSecondBridge = true;
            }
        }

        gameObject.GetComponent<SpriteRenderer>().sprite = m_ActivatedTileSprite;

    }

    public void ResetPlates(Sprite m_OldSprite)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = m_OldSprite;
    }
}
