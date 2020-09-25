using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleSeeds : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        LevelStates.m_PickedAppleSeeds = true;
    }
}
