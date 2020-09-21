using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float m_speed;
    [SerializeField] private Animator m_Animator;
    private Vector3 m_DirectionX = new Vector3(1, 0, 0);
    

    // Update is called once per frame
    void Update()
    {
        m_Animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        m_Animator.SetFloat("Vertical", Input.GetAxis("Vertical"));
        if (m_Animator.GetFloat("Vertical") > -0.001 && m_Animator.GetFloat("Vertical") < 0.001)
        {
            m_Animator.SetBool("MovingVertical",false);
        }
        else
        {
            m_Animator.SetBool("MovingVertical", true);
        }


        float moveHorizontal = Input.GetAxis("Horizontal");

        //Store the current vertical input in the float moveVertical.
        float moveVertical = Input.GetAxis("Vertical");

        //Use the two store floats to create a new Vector2 variable movement.
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
        transform.Translate(movement.normalized* Time.deltaTime * m_speed);

    }
}
