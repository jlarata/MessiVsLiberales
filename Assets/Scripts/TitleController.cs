using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class TitleController : MonoBehaviour
{

    public GameObject optionsPanel;
    //public GameObject optionsPanelStartButton;

    void Start()
    {
        optionsPanel = GameObject.Find("OptionsPanel");
        optionsPanel.SetActive(false);
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
