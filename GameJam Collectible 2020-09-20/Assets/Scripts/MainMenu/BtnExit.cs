using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnExit : MonoBehaviour
{
    [SerializeField] private Button exitbtn;
    // Start is called before the first frame update
    void Start()
    {
        exitbtn.onClick.AddListener(onbtnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void onbtnClick()
    {
        Application.Quit();
    }
}
