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
        m_myBody = GetComponent<Rigidbody2D>();
<<<<<<< HEAD
        LevelStates.m_CurrentLevel = 0;
=======
        
>>>>>>> fc549037733d5a77e551f9196a5d9d693263a156

    }
    // Update is called once per frame
    void Update()
    {
        movementAxis();

<<<<<<< HEAD
        inputKeys();
=======
        if(Input.GetKey(KeyCode.P))
        {
            SceneManager.LoadScene(LevelStates.getLvlPast(LevelStates.m_CurrentLevel), LoadSceneMode.Single);

        } 
        else if(Input.GetKey(KeyCode.N))
        {
            SceneManager.LoadScene(LevelStates.getLvlPresent(LevelStates.m_CurrentLevel), LoadSceneMode.Single);

        }
        else if (Input.GetKey(KeyCode.F))
        {
            SceneManager.LoadScene(LevelStates.getLvlFuture(LevelStates.m_CurrentLevel), LoadSceneMode.Single);
        }
        
        if (Input.GetKey(KeyCode.O) && LevelStates.m_PickedAppleSeeds == true)
        {
            LevelStates.m_PickedAppleSeeds = false;
        }

        Debug.Log(LevelStates.m_PickedAppleSeeds);

        returnToLevelSelect();
    }

    private void returnToLevelSelect()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Level_Selection");
        }
>>>>>>> fc549037733d5a77e551f9196a5d9d693263a156
    }

    private void FixedUpdate()
    {
        m_myBody.velocity = movement.normalized * Time.deltaTime * m_speed;       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Colision");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("TriggerEnter");

        if (collision.tag.Equals("AppleSeeds"))
        {
            Destroy(collision.gameObject);
            LevelStates.m_PickedAppleSeeds = true;
        }

        if (collision.tag.Equals("Garden"))
        {
            LevelStates.m_CanPlantAppleSeed = true;
            //Debug.Log("TriggerGarden");
        }

        if (collision.tag.Equals("MidTree"))
        {
            collision.GetComponent<SpriteRenderer>().sortingOrder = 11;
            //Debug.Log("TriggerTree");
        }

        if (collision.tag.Equals("AppleTree"))
        {
            collision.GetComponent<SpriteRenderer>().sortingOrder = 11;
            //Debug.Log("TriggerTree");
        }

        if (collision.tag.Equals("Apple"))
        {
            Destroy(collision.gameObject);
            LevelStates.m_PickedApple = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log("TriggerExit");

        if (collision.tag.Equals("Garden"))
        {
            LevelStates.m_CanPlantAppleSeed = false;
            //Debug.Log(LevelStates.m_PlantedAppleSeed);
            //Debug.Log("TriggerGarden");
        }

        if (collision.tag.Equals("MidTree"))
        {
            collision.GetComponent<SpriteRenderer>().sortingOrder = 9;
           // Debug.Log("TriggerTree");
        }

        if (collision.tag.Equals("AppleTree"))
        {
            collision.GetComponent<SpriteRenderer>().sortingOrder = 9;
            //Debug.Log("TriggerTree");
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
        if (Input.GetKey(KeyCode.P))
        {
            SceneManager.LoadScene(LevelStates.getLvlPast(LevelStates.m_CurrentLevel), LoadSceneMode.Single);
            LevelStates.m_CurrentTime = "Past";

        }
        else if (Input.GetKey(KeyCode.N))
        {
            SceneManager.LoadScene(LevelStates.getLvlPresent(LevelStates.m_CurrentLevel), LoadSceneMode.Single);
            LevelStates.m_CurrentTime = "Present";
        }
        else if (Input.GetKey(KeyCode.F))
        {
            SceneManager.LoadScene(LevelStates.getLvlFuture(LevelStates.m_CurrentLevel), LoadSceneMode.Single);
            LevelStates.m_CurrentTime = "Future";
        }

        if (Input.GetKey(KeyCode.X) && LevelStates.m_PickedAppleSeeds == true)
        {
            m_LevelsObjectInit.InitSeed();
            LevelStates.m_PickedAppleSeeds = false;
        }

        //Debug.Log(LevelStates.m_PickedAppleSeeds);
        //Debug.Log(LevelStates.m_CanPlantAppleSeed);

        if (Input.GetKey(KeyCode.G) && LevelStates.m_PickedAppleSeeds == true && LevelStates.m_CanPlantAppleSeed == true)
        {
            LevelStates.m_PlantedAppleSeed = true;
            LevelStates.m_PickedAppleSeeds = false;
            //Destroy(collision.gameObject);
            //Debug.Log("Planted");
        }
    }
}
