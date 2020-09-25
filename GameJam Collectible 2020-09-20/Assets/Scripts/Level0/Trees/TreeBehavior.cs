using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeBehavior : MonoBehaviour
{
    [SerializeField] Level0ObjectsInit m_Levels0ObjectInit;

    BoxCollider2D[] m_BoxColliders;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(LevelStates.m_PlantedAppleSeed);
        m_BoxColliders = gameObject.GetComponents<BoxCollider2D>();

        if (LevelStates.m_PlantedAppleSeed == false)
        {
            foreach (BoxCollider2D boxCol in m_BoxColliders)
            {
                boxCol.enabled = false;
            }
        
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
        else
        {
            foreach (BoxCollider2D boxCol in m_BoxColliders)
            {
                boxCol.enabled = true;
            }
        
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
            m_Levels0ObjectInit.InitApple("GEN");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("col");
        if (Input.GetKeyDown(KeyCode.H) && LevelStates.m_PickedApple != true && LevelStates.m_AppleDropped != true)
        {
            LevelStates.m_AppleDropped = true;
            Debug.Log("HIT");
            Destroy(m_Levels0ObjectInit.m_AppleToHit);
            m_Levels0ObjectInit.InitApple("HIT");
        }
    }

}
