using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayBtn : MonoBehaviour
{
    [SerializeField] private Button m_BtnPlay;

    // Start is called before the first frame update
    void Start()
    {
        m_BtnPlay.onClick.AddListener(LoadGame);
    }

    private void LoadGame()
    {
        SceneManager.LoadScene(LevelStates.getLvlPresent(LevelStates.m_CurrentLevel), LoadSceneMode.Single);
        LevelStates.m_CurrentTime = "Present";
    }
}
