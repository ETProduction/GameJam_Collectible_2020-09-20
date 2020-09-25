using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1ObjectInit : MonoBehaviour
{
    [SerializeField] private GameObject m_Key;
    [SerializeField] private GameObject m_KeyChest;
    [SerializeField] private GameObject m_Coin;

    private GameObject m_CoinDestroy;

    public void ChestOpen()
    {
        m_CoinDestroy = Instantiate(m_Coin, (new Vector3(m_KeyChest.transform.position.x, m_KeyChest.transform.position.y, 0)), Quaternion.identity);

        Destroy(m_CoinDestroy, 2);

        Invoke("KeyDrop", 3);

    }

    private void KeyDrop()
    {
        Instantiate(m_Key, (new Vector3(m_KeyChest.transform.position.x, m_KeyChest.transform.position.y + 1.5f, 0)), Quaternion.identity);
    }
}
