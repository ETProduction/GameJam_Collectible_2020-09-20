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
    private Vector3 m_DirectionX = new Vector3(1, 0, 0);
    private float moveHorizontal = 0;
    private float moveVertical = 0;
    private Vector2 movement = new Vector2(0,0);
    private Rigidbody2D m_myBody;

    

    private void Start()
    {
        m_myBody = GetComponent<Rigidbody2D>();

    }
    // Update is called once per frame
    void Update()
    {
        movementAxis();

        if(Input.GetKey(KeyCode.P))
        {
            SceneManager.LoadScene(0);
        } 
        else if(Input.GetKey(KeyCode.N))
        {
            SceneManager.LoadScene(1);
        }
        else if (Input.GetKey(KeyCode.F))
        {
            SceneManager.LoadScene(2);
        }

        if(Input.GetKey(KeyCode.O) && LevelStates.m_Picked_Apple == true)
        {
            LevelStates.m_Picked_Apple = false;
        }

        Debug.Log(LevelStates.m_Picked_Apple);


    }
    private void FixedUpdate()
    {
        m_myBody.velocity = movement.normalized * Time.deltaTime * m_speed;       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Colision");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name.Contains("Apple"))
        {
            collision.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            LevelStates.m_Picked_Apple = true;
            Debug.Log("Trigger");
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
}
