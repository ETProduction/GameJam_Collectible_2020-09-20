using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level0ObjectsInit : MonoBehaviour
{

    [SerializeField] private Object m_AppleSeeds;
    [SerializeField] private Object m_Player;
    [SerializeField] private GameObject m_Apple;
    [SerializeField] private GameObject m_Key;
    [SerializeField] private GameObject m_Exchanger;

    public GameObject m_AppleToHit;
    private GameObject m_AppleToDestroy;

    private void Awake()
    {
        if (LevelStates.m_PickedAppleSeeds == false)
        {
            if(LevelStates.m_CurrentTime == "Future")
            {
                if(LevelStates.m_InitAppleSeeds != true)
                {
                    LevelStates.m_InitAppleSeeds = true;
                    Instantiate(m_AppleSeeds, (transform.position + new Vector3(5, 2, 0)), Quaternion.identity);
                }               
            }
            
        }
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
        else if(action == "DROP")
        {
            m_AppleToDestroy = Instantiate(m_Apple, (new Vector3(m_Exchanger.transform.position.x, m_Exchanger.transform.position.y, 0)), Quaternion.identity);

            Destroy(m_AppleToDestroy, 2);           

            Invoke("ExchangerApple", 3);
        }
        else
        {

            m_AppleToHit = Instantiate(m_Apple, (new Vector3(8.74f, 1.69f, 0)), Quaternion.identity);
        }
    }

    private void ExchangerApple()
    {
        Instantiate(m_Key, (new Vector3(m_Exchanger.transform.position.x + 1.5f, m_Exchanger.transform.position.y, 0)), Quaternion.identity);
    }
}
