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
    private float moveHorizontal = 0;
    private float moveVertical = 0;
    private Vector2 movement = new Vector2(0,0);


    // Update is called once per frame
    void Update()
    {
        m_Animator.SetFloat("Horizontal", Input.GetAxisRaw("Horizontal"));
        m_Animator.SetFloat("Vertical", Input.GetAxisRaw("Vertical"));
        if (m_Animator.GetFloat("Vertical") > -0.001 && m_Animator.GetFloat("Vertical") < 0.001)
        {
            m_Animator.SetBool("MovingVertical",false);
        }
        else
        {
            m_Animator.SetBool("MovingVertical", true);
        }


         moveHorizontal = Input.GetAxisRaw("Horizontal");

         moveVertical = Input.GetAxisRaw("Vertical");

         movement = new Vector2(moveHorizontal, moveVertical);

    }
    private void FixedUpdate()
    {
        
        transform.Translate(movement.normalized * Time.deltaTime * m_speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("test");
    }
}
