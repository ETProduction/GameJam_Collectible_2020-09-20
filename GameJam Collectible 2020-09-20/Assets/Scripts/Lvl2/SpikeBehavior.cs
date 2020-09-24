using System;
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

        setSpikesFloorStates();
        setSpikeWall1States();
        setSpikeWall2States();
        setSpikeWall3States();
        setSpikeDoorStates();


    }

    

    private void setUpStates(GameObject spike)
    {
        if (LevelStates.m_CurrentTime == "Future")
        {
            for (int i = 0; i < spike.transform.childCount; i++)
            {
                spike.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().enabled = true;
                spike.transform.GetComponent<BoxCollider2D>().enabled = true;

            }
        }
        else
        {
            for (int i = 0; i < spike.transform.childCount; i++)
            {
                spike.transform.GetComponent<BoxCollider2D>().enabled = true;

            }
        }
    }

    private void setDownStates(GameObject spike)
    {
        if (LevelStates.m_CurrentTime == "Future")
        {
            for (int i = 0; i < spike.transform.childCount; i++)
            {

                spike.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().enabled = false;
                spike.transform.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
        else
        {
            for (int i = 0; i < Lvl2States.m_SpikeDoor5.transform.childCount; i++)
            {
                spike.transform.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }

    private void setSpikeDoorStates()
    {
        if (Lvl2States.m_SpikeDoor5IsDown)
        {
            setDownStates(Lvl2States.m_SpikeDoor5);

        }
        else
        {
            setUpStates(Lvl2States.m_SpikeDoor5);

        }

    }
    private void setSpikeWall3States()
    {
        if (Lvl2States.m_SpikeWall3IsDown)
        {
            setDownStates(Lvl2States.m_SpikeWall3);  
            setDownStates(Lvl2States.m_SpikeDoor4);

        }
        else
        {
            setUpStates(Lvl2States.m_SpikeWall3);    
            setUpStates(Lvl2States.m_SpikeDoor4);

        }
    }

    private void setSpikeWall2States()
    {
        if (Lvl2States.m_SpikeWall2IsDown)
        {
            setDownStates(Lvl2States.m_SpikeWall2);  
            setDownStates(Lvl2States.m_SpikeDoor3);

        }
        else
        {
            setUpStates(Lvl2States.m_SpikeWall2);    
            setUpStates(Lvl2States.m_SpikeDoor3);

        }
    }

    private void setSpikeWall1States()
    {
        if (Lvl2States.m_SpikeWall1IsDown)
        {
            setDownStates(Lvl2States.m_SpikeWall1);   
            setDownStates(Lvl2States.m_SpikeDoor2);

        }
        else
        {
            setUpStates(Lvl2States.m_SpikeWall1); 
            setUpStates(Lvl2States.m_SpikeDoor2);

        }
    }

    private void setSpikesFloorStates()
    {
        if (Lvl2States.m_SpikeFloorIsDown)
        {
            setDownStates(Lvl2States.m_SpikeFloor);
            setDownStates(Lvl2States.m_SpikeDoor1);
        }
        else
        {
            setUpStates(Lvl2States.m_SpikeFloor);
            setUpStates(Lvl2States.m_SpikeDoor1);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(LevelStates.m_CurrentLevel);
        SceneManager.LoadScene(LevelStates.getLvlPresent(LevelStates.m_CurrentLevel));
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("grgr");
    }
}
