using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CantWalk : MonoBehaviour
{
    [SerializeField] private Sprite m_NewSprite;

    // Start is called before the first frame update
    void Start()
    {
        if (Level1States.m_TorchLight1 == true && Level1States.m_TorchLight2 == true && Level1States.m_IsBridge1 == true)
        {
            if (gameObject.tag.Equals("CantWalk"))
            {
                gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(0.1110166f, -0.03803635f);
                gameObject.GetComponent<BoxCollider2D>().size = new Vector2(3.224189f, 1.760757f);
                gameObject.GetComponent<SpriteRenderer>().sprite = m_NewSprite;
            }
        }

        if (Level1States.m_CanOpenSecondBridge && Level1States.m_IsBridge2 == true)
        {
            if (gameObject.tag.Equals("CantWalk2"))
            {
                gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(0.1110166f, -0.03803635f);
                gameObject.GetComponent<BoxCollider2D>().size = new Vector2(3.224189f, 1.760757f);
                gameObject.GetComponent<SpriteRenderer>().sprite = m_NewSprite;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Level1States.m_TorchLight1 == true && Level1States.m_TorchLight2 == true && Level1States.m_IsBridge1 == false)
        {
            if(gameObject.tag.Equals("CantWalk"))
            {
                Level1States.m_IsBridge1 = true;

                gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(0.1110166f, -0.03803635f);
                gameObject.GetComponent<BoxCollider2D>().size = new Vector2(3.224189f, 1.760757f);
                gameObject.GetComponent<SpriteRenderer>().sprite = m_NewSprite;
            }
        }

        if (Level1States.m_CanOpenSecondBridge && Level1States.m_IsBridge2 == false)
        {
            if (gameObject.tag.Equals("CantWalk2"))
            {
                Level1States.m_IsBridge2 = true;

                gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(0.1110166f, -0.03803635f);
                gameObject.GetComponent<BoxCollider2D>().size = new Vector2(3.224189f, 1.760757f);
                gameObject.GetComponent<SpriteRenderer>().sprite = m_NewSprite;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.tag.Equals("CantWalk") && Level1States.m_IsBridge1 == false)
        {
            LevelStates.m_PlayerIsDead = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (gameObject.tag.Equals("CantWalk2") && Level1States.m_IsBridge2 == false)
        {
            LevelStates.m_PlayerIsDead = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
