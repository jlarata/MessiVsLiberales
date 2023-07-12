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


public class TitleController : MonoBehaviour
{

    public GameObject optionsPanel;
    //public GameObject optionsPanelStartButton;
    public GameObject[] buttonsList;


    void Start()
    {
        optionsPanel = GameObject.Find("OptionsPanel");
        optionsPanel.SetActive(false);

        //buttonInstance();
    }



    public void buttonInstance()
    {
        GameObject canvas = GameObject.Find("Canvas");
        GameObject buttonInstance = (GameObject)Instantiate(buttonsList[0], new Vector3(0,0,0), new Quaternion(0,0,0,0));
        Debug.Log("button created");

        UnityEngine.UI.Button buttonInstanceBtn = buttonInstance.GetComponent<Button>();

        buttonInstance.GetComponentInChildren<TMP_Text>().text = "button Text";

        Debug.Log("text changed");

        buttonInstance.transform.SetParent(canvas.transform);
        buttonInstance.transform.localPosition = new Vector3(1,1,0);

        buttonInstanceBtn.onClick.AddListener(SomeFunction);

    }

    public void SomeFunction()
    {
        Debug.Log("onclick event added");
    }
    



    public void StartWithShuriken()
    {
        MainManager.Instance.shurikenLvl = 1;
        MainManager.Instance.adukeLvl = 0;
    }

    public void StartWithAduke()
    {
        MainManager.Instance.adukeLvl = 1;
        MainManager.Instance.shurikenLvl = 0;
    }

    public void StartWithDiMaria()
    {
        MainManager.Instance.adukeLvl = 0;
        MainManager.Instance.shurikenLvl = 0;
        MainManager.Instance.diMariaLvl = 1;
    }

    public void StartNew()
    {

        if (MainManager.Instance.optionsUnlocked)
        {
            StartWithOptions();
        } else
        {
            StartWithoutOptions();
        }
    }

    public void StartWithOptions()
    {
        if (!optionsPanel.activeSelf)
        {
            optionsPanel.SetActive(true);
        } else 
        {
            SceneManager.LoadScene(1);
        }
    }    

    public void StartWithoutOptions()
    {
        SceneManager.LoadScene(1);
    }



    public void Exit()
    {

        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit(); //original code to quit unity.
        #endif
    }
}
