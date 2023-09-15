using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalController : MonoBehaviour
{
    
    
    public GameObject gameController;
    public GameController GameController; 
    public GameObject cheats;
    public CheatsController CheatsController; 

    void Start()
    {
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
        // if (Input.GetKeyDown(KeyCode.Return))
        // {
        //     AutoDestroy();
        // }
    }

    public void AutoDestroy()
    {
        CheatsController.isTerminalOpen = false;
        GameController.isTerminalOpen = false;
        GameController.PausaniasFunction();
        Destroy(gameObject);
    }
}
