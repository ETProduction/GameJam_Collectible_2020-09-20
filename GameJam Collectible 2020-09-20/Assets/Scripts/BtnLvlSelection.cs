using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnLvlSelection : MonoBehaviour
{
    [SerializeField] private int lvlNumber;
    [SerializeField] private Button m_button;

    void Start()
    {
  //      m_button.onClick.AddListener(buttonOnClick);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setLvlNumber(int lvl)
    {
        lvlNumber = lvl;
    }
    private void buttonOnClick()
    {
        LevelStates.m_CurrentLevel = lvlNumber;
        LevelStates.loadLvl();
    }
}
