using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBehavior : MonoBehaviour
{
    [SerializeField] private int m_KeyIndex;
    // Start is called before the first frame update
    void Start()
    {
<<<<<<< HEAD
        LevelStates.m_KeyPicked = false;
=======
        if (LevelStates.getKeyIsPicked(m_KeyIndex))
        {
            Destroy(gameObject);
        }
>>>>>>> master
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {
<<<<<<< HEAD
            LevelStates.m_KeyPicked = true;
=======
            LevelStates.setKeyStates(m_KeyIndex);
>>>>>>> master
            LevelStates.m_numberOfKey += 1;
            Destroy(gameObject);
        }

    }
}
