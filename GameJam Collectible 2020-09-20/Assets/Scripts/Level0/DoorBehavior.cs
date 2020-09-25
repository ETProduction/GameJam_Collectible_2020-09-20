using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorBehavior : MonoBehaviour
{
    [SerializeField] private Sprite m_NewSprite;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (LevelStates.m_KeyPicked == true && LevelStates.m_CurrentTime == "Present")
        {
            LevelStates.Instructions = "Vous pouvez ouvrir la porte avec Z";
        }
        else if (LevelStates.m_KeyPicked == false && LevelStates.m_CurrentTime == "Present")
        {
            LevelStates.Instructions = "Vous ne pouvez pas ouvrir la porte, vous n'avez pas la clé!";
        }
        else if (LevelStates.m_KeyPicked == true && LevelStates.m_CurrentTime != "Present")
        {
            LevelStates.Instructions = "Vous ne pouvez pas ouvrir la porte, vous n'êtes pas dans le présent!";
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("Door");

        if (Input.GetKeyDown(KeyCode.Z) && LevelStates.m_KeyPicked == true && LevelStates.m_CurrentTime == "Present")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = m_NewSprite;

            gameObject.tag = "DoorOpen";

        }

        if (Input.GetKeyDown(KeyCode.E) && gameObject.tag.Equals("DoorOpen"))
        {
            SceneManager.LoadScene("Level_Selection");
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        LevelStates.Instructions = "";
    }
}
