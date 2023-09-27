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
        GameObject BackButtonInstance = (GameObject)Instantiate(buttonsList[0], new Vector3(661,60,0), new Quaternion(0,0,0,0), GameObject.Find("UI Buttons").transform);
        //BackButtonInstance.transform.SetParent(GameObject.Find("UI Buttons").transform, false);
        Debug.Log("button created");

        //NO PUEDO CARGARLE LA FUNCION AL PREFAB
        //REVISAR EN EL SCRIPT DE TITLES CONTROLLER. SE LE PUEDEN AGREGAR LAS FUNCINOES DESDE EL 
        //SCRIPT DESPUÉS DE INSTANCIAR.
    }

    public void BackToTitles()
    {
        SceneManager.LoadScene(0);
    }
}
