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
        Debug.Log(Level1States.m_ResetTile + " allo");
        if (gameObject.name.Equals("Plate1") && Level1States.m_ResetTile == true)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = m_OldSprite;
        }

        if (gameObject.name.Equals("Plate2") && Level1States.m_ResetTile == true)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = m_OldSprite;
        }

        if (gameObject.name.Equals("Plate3") && Level1States.m_ResetTile == true)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = m_OldSprite;
        }

        if (gameObject.name.Equals("Plate4") && Level1States.m_ResetTile == true)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = m_OldSprite;
        }

        if (gameObject.name.Equals("Plate5") && Level1States.m_ResetTile == true)
        {
            Level1States.m_ResetTile = false;
            gameObject.GetComponent<SpriteRenderer>().sprite = m_OldSprite;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.name.Equals("Plate1"))
        {
            Level1States.m_IsOrderGood = true;
            Level1States.m_Plate1Activated = true;
        }
        else if (gameObject.name.Equals("Plate2"))
        {
            if (m_PreviousPlate.name.Equals("Plate1"))
            {
                Level1States.m_IsOrderGood = true;
            }
            else
            {
                Level1States.m_IsOrderGood = false;
            }

            Level1States.m_Plate2Activated = true;
        }
        else if (gameObject.name.Equals("Plate3"))
        {
            if (m_PreviousPlate.name.Equals("Plate2"))
            {
                Level1States.m_IsOrderGood = true;
            }
            else
            {
                Level1States.m_IsOrderGood = false;
            }

            Level1States.m_Plate3Activated = true;
        }
        else if (gameObject.name.Equals("Plate4"))
        {
            if (m_PreviousPlate.name.Equals("Plate3"))
            {
                Level1States.m_IsOrderGood = true;
            }
            else
            {
                Level1States.m_IsOrderGood = false;
            }

            Level1States.m_Plate4Activated = true;
        }
        else
        {
            if (m_PreviousPlate.name.Equals("Plate4"))
            {
                Level1States.m_IsOrderGood = true;
            }
            else
            {
                Level1States.m_IsOrderGood = false;
            }

            Level1States.m_Plate5Activated = true;

            if (Level1States.m_IsOrderGood == true)
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
