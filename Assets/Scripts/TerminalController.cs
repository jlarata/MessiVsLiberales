using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TerminalController : MonoBehaviour
{
    
    
    public GameObject gameController;
    public GameController GameController; 
    public GameObject cheats;
    public CheatsController CheatsController; 

    public bool is1;
    public bool is2;
    public bool is3;
  

    void Start()
    {
        //makes the inputfield Selected when is initiated
        GetComponent<TMP_InputField>().ActivateInputField();
        //el objeto
        gameController = GameObject.Find("Game Controller");
        //el script
        GameController = gameController.GetComponent<GameController>();
        //el objeto
        cheats = GameObject.Find("Cheats");

        

        //el script
        CheatsController = cheats.GetComponent<CheatsController>();

        
    }

    void Update()
    {
        // this was for better UX but i've find that was not very smooth
        // if (Input.GetKeyDown(KeyCode.Return))
        // {
        //     AutoDestroy();
        // }
    }

    public void checkInput()
    {
        var thisInput = GetComponent<TMP_InputField>().text;
        /* just testing
        if(thisInput == "asd" || thisInput == "ASD") 
        {
            Debug.Log("éxito!");
        } */
        if(thisInput == "iddqd" || thisInput == "IDDQD") 
        {
            if (!is1)
            {
                GameObject.Find("Messi").GetComponent<MessiController>().IDDQD();
                Debug.Log("modo diablo perrito malvado!");
                is1 = true;
            }   
        }
        if(thisInput == "maximaciencia" || thisInput == "MAXIMACIENCIA") 
        {
            if (!is2)
            {
                GameController.goTromp();
                Debug.Log("Make Argentina Great Again!");
                is2 = true;
            }   
        }
        if(thisInput == "sgc2c" || thisInput == "SGC2C") 
        {
            if (!is3)
            {
                GameObject.Find("Messi").GetComponent<MessiController>().JohnWick();
                Debug.Log("Never. St0p. Drink'n");
                is3 = true;
            }   
        }
    }

    public void AutoDestroy()
    {
        checkInput();
        CheatsController.isTerminalOpen = false;
        GameController.isTerminalOpen = false;
        GameController.PausaniasFunction();
        Destroy(gameObject);
    }
}
