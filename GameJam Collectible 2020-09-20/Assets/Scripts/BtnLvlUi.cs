using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnLvlUi : MonoBehaviour
{
    [SerializeField] private int requieredNumberOfKeys;
    [SerializeField] private Button btnLock;
    [SerializeField] private Button btnUnlock;
    [SerializeField] private int lvlNumber;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(LevelStates.m_numberOfKey >= requieredNumberOfKeys)
        {           
            btnLock.gameObject.SetActive(false);
            btnUnlock.gameObject.SetActive(true);
        }
        else
        {
            btnUnlock.gameObject.SetActive(false);
            btnLock.gameObject.SetActive(true);
            Text test = btnLock.GetComponentInChildren<Text>();
            test.text = requieredNumberOfKeys.ToString();

        }
    }
    public void buttonOnClick()
    {
        
        LevelStates.m_CurrentLevel = lvlNumber;
        LevelStates.loadLvl();
    }
   

}
