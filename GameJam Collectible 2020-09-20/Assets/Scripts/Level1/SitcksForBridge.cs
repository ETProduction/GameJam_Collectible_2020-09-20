using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SitcksForBridge : MonoBehaviour
{
    [SerializeField] private Sprite m_NewSprite;

    BoxCollider2D[] m_BoxColliders;
    private bool isTrigger;

    // Start is called before the first frame update
    void Start()
    {
        m_BoxColliders = gameObject.GetComponents<BoxCollider2D>();

        if(gameObject.tag.Equals("Torch1"))
        {
            if (Level1States.m_IsButtonPressed == false && Level1States.m_TorchLight1 != true)
            {
                foreach (BoxCollider2D boxCol in m_BoxColliders)
                {
                    boxCol.enabled = false;
                }

                gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
            else
            {
                foreach (BoxCollider2D boxCol in m_BoxColliders)
                {
                    boxCol.enabled = true;
                }

                gameObject.GetComponent<BoxCollider2D>().enabled = true;
            }
        }
        else
        {
            if (Level1States.m_IsButtonPressed == false && Level1States.m_TorchLight2 != true)
            {
                foreach (BoxCollider2D boxCol in m_BoxColliders)
                {
                    boxCol.enabled = false;
                }

                gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
            else
            {
                foreach (BoxCollider2D boxCol in m_BoxColliders)
                {
                    boxCol.enabled = true;
                }

                gameObject.GetComponent<BoxCollider2D>().enabled = true;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (LevelStates.m_PlayerIsInteracting && isTrigger)
        {
            if (gameObject.tag.Equals("Torch1"))
            {
                Level1States.m_TorchLight1 = true;

                gameObject.GetComponent<SpriteRenderer>().sprite = m_NewSprite;

            }
            else
            {
                Level1States.m_TorchLight2 = true;

                gameObject.GetComponent<SpriteRenderer>().sprite = m_NewSprite;

            }

            LevelStates.m_PlayerIsInteracting = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        LevelStates.Instructions = "Press 'F' to interact";

        if (gameObject.tag.Equals("Torch1"))
        {
            LevelStates.m_PlayerCanInteract = true;

            isTrigger = true;
        }
        else
        {
            LevelStates.m_PlayerCanInteract = true;

            isTrigger = true;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {

        if (gameObject.tag.Equals("Torch1"))
        {
            LevelStates.m_PlayerCanInteract = true;

            isTrigger = true;
        }
        else
        {
            LevelStates.m_PlayerCanInteract = true;

            isTrigger = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isTrigger = false;
        LevelStates.m_PlayerCanInteract = false;
        LevelStates.Instructions = "";
    }
}
