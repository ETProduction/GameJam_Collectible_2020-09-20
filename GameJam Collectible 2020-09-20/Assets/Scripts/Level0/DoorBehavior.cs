using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorBehavior : MonoBehaviour
{
    [SerializeField] private Sprite m_NewSprite;

    private bool isTrigger;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (LevelStates.m_PlayerIsInteracting && isTrigger)
        {

            gameObject.GetComponent<SpriteRenderer>().sprite = m_NewSprite;
            gameObject.tag = "DoorOpen";

            LevelStates.m_PlayerIsInteracting = false;

            if (gameObject.tag.Equals("DoorOpen"))
            {
                LevelStates.Instructions = "";

                SceneManager.LoadScene("Level_Selection");
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if ((Lvl0States.m_KeyIsPicked == true || Level1States.m_KeyIsPicked == true) && LevelStates.m_CurrentTime == "Present")
        {
            LevelStates.m_PlayerCanInteract = true;
            isTrigger = true;

            LevelStates.Instructions = "Press 'F' to interact";
        }
        else if ((Lvl0States.m_KeyIsPicked == false || Level1States.m_KeyIsPicked == false) && LevelStates.m_CurrentTime == "Present")
        {
            LevelStates.Instructions = "No key!";
        }
        else if ((Lvl0States.m_KeyIsPicked == true || Level1States.m_KeyIsPicked == true) && LevelStates.m_CurrentTime != "Present")
        {
            LevelStates.Instructions = "Wrong time !";
        }
        else if ((Lvl0States.m_KeyIsPicked == false || Level1States.m_KeyIsPicked == false) && LevelStates.m_CurrentTime != "Present")
        {
            LevelStates.Instructions = "No key, Wrong time!";
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {

        if (LevelStates.m_KeyPicked == true && LevelStates.m_CurrentTime == "Present")
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
