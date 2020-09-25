using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LevelStates.m_KeyPicked = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {
            LevelStates.m_KeyPicked = true;
            LevelStates.m_numberOfKey += 1;
            Destroy(gameObject);
        }

    }
}
