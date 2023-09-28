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

public class UIButtonsController : MonoBehaviour
{
    public GameObject[] buttonsList;

    void Start()
    {
        InstantiateButtons();
    }

    void Update()
    {
        
    }

    public void InstantiateButtons()
    {
        //set parent object
        GameObject UIButtons = GameObject.Find("UI Buttons");
        //instanciate the button and set UIButton as parent
        GameObject BackButtonInstance = (GameObject)Instantiate(buttonsList[0], new Vector3(0,0,0), new Quaternion(0,0,0,0), UIButtons.transform);
        //move the button to the desired location (regarding the parent object)
        BackButtonInstance.transform.localPosition = new Vector3(-150,0,0);
        
        //set the button component
        UnityEngine.UI.Button BackButtonInstanceBtn = BackButtonInstance.GetComponent<Button>();
        
        //add a function to the button componetn
        BackButtonInstanceBtn.onClick.AddListener(BackToTitles);
        
    }

    public void BackToTitles()
    {
        SceneManager.LoadScene(0);
    }
}
