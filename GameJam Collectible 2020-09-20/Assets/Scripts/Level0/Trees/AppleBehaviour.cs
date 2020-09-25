using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AppleBehaviour : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        if (LevelStates.m_PlantedAppleSeed == false && LevelStates.m_PickedApple != true)
        {
            gameObject.GetComponent<PolygonCollider2D>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
        else
        {
            gameObject.GetComponent<PolygonCollider2D>().enabled = true;
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        LevelStates.m_PickedApple = true;
    }


}
