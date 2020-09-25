using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SitcksForBridge : MonoBehaviour
{
    [SerializeField] private Sprite m_NewSprite;

    BoxCollider2D[] m_BoxColliders;

    // Start is called before the first frame update
    void Start()
    {
        m_BoxColliders = gameObject.GetComponents<BoxCollider2D>();

        if (Level1States.m_IsButtonPressed == false)
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

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        LevelStates.Instructions = "Allumer les flammes avec la touche i";

        if (Input.GetKey(KeyCode.I))
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
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        LevelStates.Instructions = "";
    }
}
