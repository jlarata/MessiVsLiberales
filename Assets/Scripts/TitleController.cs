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


    public void StartNew()
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
