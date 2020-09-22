using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelObjectsInit : MonoBehaviour
{

    [SerializeField] private Object m_Apple;

    // Start is called before the first frame update
    void Start()
    {
        if(LevelStates.m_Picked_Apple == false)
        {
            Instantiate(m_Apple, (transform.position + new Vector3(5, 2, 0)), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
