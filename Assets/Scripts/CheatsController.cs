using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatsController : MonoBehaviour
{
    public GameObject[] terminales;
    public GameObject gameController;
    public GameController GameController; 
    public bool isTerminalOpen;

    void Start()
    {
        //el objeto
        gameController = GameObject.Find("Game Controller");
        //el script
        GameController = gameController.GetComponent<GameController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.LeftControl))
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                if (!isTerminalOpen)
                {
                    GameController.PausaniasFunction();
                    GameController.isTerminalOpen = true;
                    OpenTerminal();
                    isTerminalOpen = true;
                }
            }
        }
        
  
    }

    void OpenTerminal()

    {
        Instantiate(terminales[0], this.transform);
    }
}
