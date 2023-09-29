using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine.UI;
using TMPro;

public class BuyButtonsController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] buttonsList;
    public int adukeValue = 100;
    public int diMariaValue = 10000;

    void Start()
    {
        InstantiateButtons();

        if (MainManager.Instance != null)
        {
            MainManager.Instance.IniciateMarketWealthDisplay();
        }

        InstantiateProductButtons();
    }

    void Update()
    {
        
    }

    public void InstantiateButtons()
    {
        //set parent object
        GameObject BuyButtons = GameObject.Find("BuyButtons");
        //instanciate the button and set UIButton as parent
        GameObject MarketWealthDisplayInstance = (GameObject)Instantiate(buttonsList[0], new Vector3(0,0,0), new Quaternion(0,0,0,0), BuyButtons.transform);
        //move the button to the desired location (regarding the parent object)
        MarketWealthDisplayInstance.transform.localPosition = new Vector3(-300,2,0);
        
        //set the button component
        UnityEngine.UI.Button MarketWealthDisplayInstanceBtn = MarketWealthDisplayInstance.GetComponent<Button>();
        
        //add a function to the button componetn
        //BackButtonInstanceBtn.onClick.AddListener(BackToTitles);
        
    }

    public void InstantiateProductButtons()
    {
        //set parent object 
        GameObject productsWindow = GameObject.Find("ProductsWindow");
        //instanciate the button and set UIButton as parent
        GameObject diMariaProductInstance = (GameObject)Instantiate(buttonsList[1], new Vector3(0,0,0), new Quaternion(0,0,0,0), productsWindow.transform);
        GameObject adukeProductInstance = (GameObject)Instantiate(buttonsList[2], new Vector3(0,0,0), new Quaternion(0,0,0,0), productsWindow.transform);

        Color notAffordableColor = new Color (1f, 0f, 0f, 255f);
        Color affordableColor = new Color (0f, 1f, 0f, 255f);

        if (MainManager.Instance != null)
        {
            if (MainManager.Instance.totalWealth < diMariaValue)
            {
                diMariaProductInstance.GetComponent<TMP_Text>().color = notAffordableColor;
            } else
            {
                diMariaProductInstance.GetComponent<TMP_Text>().color = affordableColor;
            }

            if (MainManager.Instance.totalWealth < adukeValue)
            {
                adukeProductInstance.GetComponent<TMP_Text>().color = notAffordableColor;
            } else
            {
                adukeProductInstance.GetComponent<TMP_Text>().color = affordableColor;
            }
        }
        

       






        //move the button to the desired location (regarding the parent object)
        diMariaProductInstance.transform.localPosition = new Vector3(34,80,0);
        adukeProductInstance.transform.localPosition = new Vector3(34,25,0);
        
        //set the button component
        UnityEngine.UI.Button diMariaProductInstanceBtn = diMariaProductInstance.GetComponent<Button>();
        UnityEngine.UI.Button adukeProductInstanceBtn = adukeProductInstance.GetComponent<Button>();


        //add a function to the button componetn
        //BackButtonInstanceBtn.onClick.AddListener(BackToTitles);
        
    }
}
