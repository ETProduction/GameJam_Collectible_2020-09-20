using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelObjectsInit : MonoBehaviour
{

    [SerializeField] private Object m_AppleSeeds;
    [SerializeField] private Object m_Player;
    [SerializeField] private GameObject m_Apple;

    public GameObject m_AppleToHit;

    private void Awake()
    {
        if (LevelStates.m_PickedAppleSeeds == false)
        {
            if(LevelStates.m_CurrentTime == "Future")
            {
                Instantiate(m_AppleSeeds, (transform.position + new Vector3(5, 2, 0)), Quaternion.identity);
            }
            
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

    public void InitApple(string action)
    {
        m_Apple.transform.localScale = new Vector3(3, 3, 3);

        if(action == "HIT")
        {
            Instantiate(m_Apple, (new Vector3(GameObject.Find("Player").transform.position.x + 1.5f, GameObject.Find("Player").transform.position.y, 0)), Quaternion.identity);
        }  
        else
        {
            m_AppleToHit = Instantiate(m_Apple, (new Vector3(8.74f, 1.69f, 0)), Quaternion.identity);
        }
    }
}
