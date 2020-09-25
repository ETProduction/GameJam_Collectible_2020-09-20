using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIItemFiller : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Image UITab;
    [SerializeField] private Sprite m_AppleSeedSprite;
    [SerializeField] private Sprite m_AppleSprite;
    [SerializeField] private Sprite m_CoinSprite;
    [SerializeField] private Text m_Past;
    [SerializeField] private Text m_Present;
    [SerializeField] private Text m_Future;
    [SerializeField] private Text m_numberKey;
    [SerializeField] private Text m_Instructions;

    private GameObject appleSeedSprite;
    private GameObject appleSprite;
    private GameObject coinSprite;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        setEpoqueText();
        SetInstructions();
        initiateAppleSeedUI();
        initiateAppleUI();
        initiateCoinUI();

        m_numberKey.text = LevelStates.m_numberOfKey.ToString();

    }

    private void initObjectInInventory(Sprite m_AppleSeedSprite)
    {
        throw new NotImplementedException();
    }

    private void initiateAppleSeedUI()
    {
        if (LevelStates.m_PickedAppleSeeds && appleSeedSprite == null)
        {

            appleSeedSprite = new GameObject(); //Create the GameObject
            Image NewImage = appleSeedSprite.AddComponent<Image>(); //Add the Image Component script
            NewImage.sprite = m_AppleSeedSprite; //Set the Sprite of the Image Component on the new GameObject
            appleSeedSprite.GetComponent<RectTransform>().SetParent(transform); //Assign the newly created Image GameObject as a Child of the Parent Panel.
            appleSeedSprite.SetActive(true); //Activate the GameObject
            appleSeedSprite.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            appleSeedSprite.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);


            float posX = UITab.rectTransform.localPosition.x;
            float posY = UITab.rectTransform.localPosition.y;
            float posZ = UITab.rectTransform.localPosition.z;

            int numberOfImage = UITab.rectTransform.parent.gameObject.GetComponentsInChildren<Image>().Length;
            float uiWidth = UITab.rectTransform.rect.width;
            float uiHeight = UITab.rectTransform.rect.height;

            appleSeedSprite.transform.localPosition = new Vector3(posX- (uiWidth/2),posY+ (uiHeight/2), posZ);
            
        }
        else if (appleSeedSprite != null && LevelStates.m_PickedAppleSeeds == false)
        {
            Destroy(appleSeedSprite);
        }
       
        

    }

    private void initiateAppleUI()
    {
        if (LevelStates.m_PickedApple && appleSprite == null)
        {
            Debug.Log("Hello");
            appleSprite = new GameObject(); //Create the GameObject
            Image NewImage = appleSprite.AddComponent<Image>(); //Add the Image Component script
            NewImage.sprite = m_AppleSprite; //Set the Sprite of the Image Component on the new GameObject
            appleSprite.GetComponent<RectTransform>().SetParent(transform); //Assign the newly created Image GameObject as a Child of the Parent Panel.
            appleSprite.SetActive(true); //Activate the GameObject
            appleSprite.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);

              appleSprite.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);


            float posX = UITab.rectTransform.localPosition.x;
            float posY = UITab.rectTransform.localPosition.y;
            float posZ = UITab.rectTransform.localPosition.z;

            float uiWidth = UITab.rectTransform.rect.width;

            float uiHeight = UITab.rectTransform.rect.height;

            appleSprite.transform.localPosition = new Vector3(posX - (uiWidth / 2), posY + (uiHeight / 2), posZ);

        }
        else if (appleSprite != null && LevelStates.m_PickedApple == false)
        {
            Destroy(appleSprite);
        }
    }

    private void initiateCoinUI()
    {
        if (Level1States.m_GotTheCoin && coinSprite == null)
        {

            coinSprite = new GameObject(); //Create the GameObject
            Image NewImage = coinSprite.AddComponent<Image>(); //Add the Image Component script
            NewImage.sprite = m_CoinSprite; //Set the Sprite of the Image Component on the new GameObject
            coinSprite.GetComponent<RectTransform>().SetParent(transform); //Assign the newly created Image GameObject as a Child of the Parent Panel.
            coinSprite.SetActive(true); //Activate the GameObject
            coinSprite.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
            coinSprite.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);

            float posX = UITab.rectTransform.localPosition.x;
            float posY = UITab.rectTransform.localPosition.y;
            float posZ = UITab.rectTransform.localPosition.z;

            int numberOfImage = UITab.transform.parent.gameObject.GetComponentsInChildren<Image>().Length;
            float uiWidth = UITab.rectTransform.rect.width;

            float uiHeight = UITab.rectTransform.rect.height;

            coinSprite.transform.localPosition = new Vector3(posX - (uiWidth / 2), posY + (uiHeight / 2), posZ);

        }
        else if (coinSprite != null && Level1States.m_GotTheCoin == false)
        {
            Destroy(coinSprite);
        }
    }

    private void setEpoqueText()
    {
        string epoque = SceneManager.GetActiveScene().name;    
        if (epoque.Contains("Past"))
        {
            m_Past.color = Color.red;
            m_Present.color = Color.white;
            m_Future.color = Color.white;
        }
        else if (epoque.Contains("Present"))
        {
            m_Past.color = Color.white;
            m_Present.color = Color.red;
            m_Future.color = Color.white;
        }
        else if (epoque.Contains("Futur"))
        {
            m_Past.color = Color.white;
            m_Present.color = Color.white;
            m_Future.color = Color.red;
        }
        else
        {
            m_Past.color = Color.white;
            m_Present.color = Color.white;
            m_Past.color = Color.white;
        }
    }

    public void SetInstructions()
    {
            //m_Instructions.gameObject.SetActive(isShown);
        m_Instructions.text = LevelStates.Instructions;
        
    }
}
