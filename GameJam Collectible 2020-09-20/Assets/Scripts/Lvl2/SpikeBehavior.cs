using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpikeBehavior : MonoBehaviour
{
    [SerializeField] private GameObject spikeWall;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if (LevelStates.m_CurrentTime == "Future")
        {
            if (Lvl2States.m_SpikeFloorIsDown)
            {
                for (int i = 0; i < Lvl2States.m_SpikeFloor.transform.childCount; i++)
                {

                    Lvl2States.m_SpikeFloor.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().enabled = false;
                    Lvl2States.m_SpikeFloor.transform.GetComponent<BoxCollider2D>().enabled = false;
                }

            }
            else
            {
                for (int i = 0; i < Lvl2States.m_SpikeFloor.transform.childCount; i++)
                {
                    Lvl2States.m_SpikeFloor.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().enabled = true;
                    Lvl2States.m_SpikeFloor.transform.GetComponent<BoxCollider2D>().enabled = true;

                }

            }
        }
        if (LevelStates.m_CurrentTime == "Present" || LevelStates.m_CurrentTime == "Past")
        {
            if (Lvl2States.m_SpikeFloorIsDown)
            {
                for (int i = 0; i < Lvl2States.m_SpikeFloor.transform.childCount; i++)
                {

                   // Lvl2States.m_SpikeFloor.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().enabled = false;
                    Lvl2States.m_SpikeFloor.transform.GetComponent<BoxCollider2D>().enabled = false;
                }

            }
            else
            {
                for (int i = 0; i < Lvl2States.m_SpikeFloor.transform.childCount; i++)
                {
                    //Lvl2States.m_SpikeFloor.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().enabled = true;
                    Lvl2States.m_SpikeFloor.transform.GetComponent<BoxCollider2D>().enabled = true;

                }

            }
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(LevelStates.m_CurrentLevel);
        SceneManager.LoadScene(LevelStates.getLvlPresent(LevelStates.m_CurrentLevel));
    }
}
