using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIItemFiller : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Image UITab;
    [SerializeField] private Sprite m_AppleSprite;
    private GameObject appleSprite;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(UITab.transform.parent.gameObject.GetComponentsInChildren<Image>().Length);
        if (LevelStates.m_PickedAppleSeeds && appleSprite ==null)
        {
            appleSprite = new GameObject(); //Create the GameObject
            Image NewImage = appleSprite.AddComponent<Image>(); //Add the Image Component script
            NewImage.sprite = m_AppleSprite; //Set the Sprite of the Image Component on the new GameObject
            appleSprite.GetComponent<RectTransform>().SetParent(transform); //Assign the newly created Image GameObject as a Child of the Parent Panel.
            appleSprite.SetActive(true); //Activate the GameObject

            float posX = UITab.transform.position.x;
            float posY = UITab.transform.position.y;
            float posZ = UITab.transform.position.z;

            int numberOfImage = UITab.transform.parent.gameObject.GetComponentsInChildren<Image>().Length;
            float uiWidth = UITab.rectTransform.rect.width;

            Debug.Log(((uiWidth / 2) - ((uiWidth / 2) )));
            float newPosX = posX - ((uiWidth / 2) - ((uiWidth / 2) / (numberOfImage-1)));

            appleSprite.transform.position = new Vector3(newPosX, posY, posZ);
            Debug.Log(UITab.rectTransform.rect.width);

        }else if(appleSprite != null && LevelStates.m_PickedAppleSeeds == false)
        {
            Destroy(appleSprite);
        }
    }
}
