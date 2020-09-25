using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.Experimental.AssetImporters;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float m_speed;
    [SerializeField] private Animator m_Animator;
    [SerializeField] LevelObjectsInit m_LevelsObjectInit;

    private float moveHorizontal = 0;
    private float moveVertical = 0;
    private Vector2 movement = new Vector2(0,0);
    private Rigidbody2D m_myBody;

    private void Start()
    {
        transform.position = LevelStates.m_PlayerPosition;
        LevelStates.m_PlayerIsDead = false;
        m_myBody = GetComponent<Rigidbody2D>();

    }
    private void Awake()
    {
        LevelStates.setCurrentLevel(SceneManager.GetActiveScene().name);
    }
    // Update is called once per frame
    void Update()
    {
        if (LevelStates.m_PlayerIsDead)
        {
            movement = new Vector2(0, 0);
        }
        else
        {
            movementAxis();

            updatePlayerPosition();

            inputKeys();


            returnToLevelSelect();
        }
       
        
        
    }

    private void updatePlayerPosition()
    {
        LevelStates.m_PlayerPosition = transform.position;
        if (LevelStates.m_PlayerIsDead)
        {
            LevelStates.m_PlayerPosition = Lvl2States.m_DefaultPosition;
        }
    }

    private void returnToLevelSelect()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Level_Selection");
        }
    }

    private void FixedUpdate()
    {
        m_myBody.velocity = movement.normalized * Time.deltaTime * m_speed;       
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.tag.Equals("AppleSeeds"))
        {
            Destroy(collision.gameObject);
            LevelStates.m_PickedAppleSeeds = true;
        }

        if (collision.tag.Equals("Garden"))
        {
            LevelStates.m_CanPlantAppleSeed = true;

        }

        if (collision.tag.Equals("MidTree"))
        {
            collision.GetComponent<SpriteRenderer>().sortingOrder = 11;

        }

        if (collision.tag.Equals("AppleTree"))
        {
            collision.GetComponent<SpriteRenderer>().sortingOrder = 11;

        }

        if (collision.tag.Equals("Apple"))
        {
            Destroy(collision.gameObject);
            LevelStates.m_PickedApple = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.tag.Equals("Garden"))
        {
            LevelStates.m_CanPlantAppleSeed = false;
        }

        if (collision.tag.Equals("MidTree"))
        {
            collision.GetComponent<SpriteRenderer>().sortingOrder = 9;

        }

        if (collision.tag.Equals("AppleTree"))
        {
            collision.GetComponent<SpriteRenderer>().sortingOrder = 9;

        }
    }

    private void movementAxis() 
    {
        m_Animator.SetFloat("Horizontal", Input.GetAxisRaw("Horizontal"));
        m_Animator.SetFloat("Vertical", Input.GetAxisRaw("Vertical"));

        if (m_Animator.GetFloat("Vertical") > -0.001 && m_Animator.GetFloat("Vertical") < 0.001)
        {
            m_Animator.SetBool("MovingVertical", false);
        }
        else
        {
            m_Animator.SetBool("MovingVertical", true);
        }


        moveHorizontal = Input.GetAxisRaw("Horizontal");

        moveVertical = Input.GetAxisRaw("Vertical");

        movement = new Vector2(moveHorizontal, moveVertical);
    }

    private void inputKeys()
    {

        if (Input.GetKeyUp(KeyCode.F))
        {
            if (LevelStates.m_PlayerCanInteract)
            {
                LevelStates.m_PlayerIsInteracting = true;
            }
        }

        if (Input.GetKeyUp(KeyCode.Q))
        {
            
            LevelStates.goBackInTime();
            
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            LevelStates.goFowardInTime();

        }
        

        if (Input.GetKey(KeyCode.X) && LevelStates.m_PickedAppleSeeds == true)
        {
            m_LevelsObjectInit.InitSeed();
            LevelStates.m_PickedAppleSeeds = false;
        }



        if (Input.GetKey(KeyCode.G) && LevelStates.m_PickedAppleSeeds == true && LevelStates.m_CanPlantAppleSeed == true)
        {
            LevelStates.m_PlantedAppleSeed = true;
            LevelStates.m_PickedAppleSeeds = false;

        }
    }
}
