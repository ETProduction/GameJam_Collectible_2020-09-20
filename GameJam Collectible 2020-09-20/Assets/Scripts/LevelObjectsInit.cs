using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelObjectsInit : MonoBehaviour
{

    [SerializeField] private Object m_AppleSeeds;
    [SerializeField] private Object m_Player;


    private void Awake()
    {
        if (LevelStates.m_PickedAppleSeeds == false)
        {
            Instantiate(m_AppleSeeds, (transform.position + new Vector3(5, 2, 0)), Quaternion.identity);
        }
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitSeed()
    {
        Instantiate(m_AppleSeeds, (new Vector3(GameObject.Find("Player").transform.position.x + 1.5f, GameObject.Find("Player").transform.position.y, 0)), Quaternion.identity);
    }
}
