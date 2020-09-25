using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBehavior : MonoBehaviour
{
    [SerializeField] private int m_KeyIndex;
    // Start is called before the first frame update
    void Start()
    {
        if (LevelStates.getKeyIsPicked(m_KeyIndex))
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {
            LevelStates.setKeyStates(m_KeyIndex);
            LevelStates.m_numberOfKey += 1;
            Destroy(gameObject);
        }
    }
}
