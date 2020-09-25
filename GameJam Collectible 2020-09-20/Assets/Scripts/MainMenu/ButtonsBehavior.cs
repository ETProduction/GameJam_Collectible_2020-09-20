using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonsBehavior : MonoBehaviour
{
    [SerializeField] private Button m_BtnPlay;
    [SerializeField] private Button m_BtnLvlSel;

    // Start is called before the first frame update
    void Start()
    {
        m_BtnPlay.onClick.AddListener(LoadGame);
        m_BtnLvlSel.onClick.AddListener(LoadLevelSel);
    }

    private void LoadGame()
    {
        SceneManager.LoadScene(LevelStates.getLvlPresent(LevelStates.m_CurrentLevel), LoadSceneMode.Single);
        LevelStates.m_CurrentTime = "Present";
    }

    private void LoadLevelSel()
    {
        SceneManager.LoadScene("Level_Selection");
    }
}
