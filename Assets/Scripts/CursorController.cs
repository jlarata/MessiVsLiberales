using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class CursorController : MonoBehaviour
{
    public GameObject GameController;
    public GameObject Messi;

    public GameObject OptionsCursor01;
    public GameObject OptionsCursor02;
    public GameObject OptionsCursor03;
    public GameObject OptionsCursor04;
    public GameObject OptionsCursor05;
/*     public GameObject OptionsCursor06;
    public GameObject OptionsCursor07;
    public GameObject OptionsCursor08;
    public GameObject OptionsCursor09;
    public GameObject OptionsCursor10; */

    void Start()
    {
        GameController = GameObject.Find("Game Controller");
        Messi = GameObject.Find("Messi");

        OptionsCursor01 = GameObject.Find("Cursor01");
        OptionsCursor02 = GameObject.Find("Cursor02");
        OptionsCursor03 = GameObject.Find("Cursor03");
        OptionsCursor04 = GameObject.Find("Cursor04");
        OptionsCursor05 = GameObject.Find("Cursor05");
        /* OptionsCursor0 = GameObject.Find("Cursor0");
        OptionsCursor0 = GameObject.Find("Cursor0");
        OptionsCursor0 = GameObject.Find("Cursor0");
        OptionsCursor0 = GameObject.Find("Cursor0");
        OptionsCursor0 = GameObject.Find("Cursor0"); */

        OptionsCursor01.SetActive(true);
        OptionsCursor02.SetActive(false);
        OptionsCursor03.SetActive(false);
        OptionsCursor04.SetActive(false);
        OptionsCursor05.SetActive(false);
     /*    OptionsCursor06.SetActive(false);
        OptionsCursor07.SetActive(false);
        OptionsCursor08.SetActive(false);
        OptionsCursor09.SetActive(false);
        OptionsCursor10.SetActive(false);
         */
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) | Input.GetKeyDown(KeyCode.DownArrow))
        {
            CursorDown();
        }
        if (Input.GetKeyDown(KeyCode.W) | Input.GetKeyDown(KeyCode.UpArrow))
        {
            CursorUp();
        }
        if (Input.GetKeyDown(KeyCode.A) | Input.GetKeyDown(KeyCode.LeftArrow))
        {
            CursorLeft();
        }
        if (Input.GetKeyDown(KeyCode.D) | Input.GetKeyDown(KeyCode.RightArrow))
        {
            CursorRight();
        }

        if (Input.GetKeyDown(KeyCode.Space) | Input.GetKeyDown(KeyCode.Return))
        {
            ExecuteCurrentOption();
        }
    }


    // Next 4 functions activate and deactivate cursor on the options menu. hopefully creating the
    // illusion of movement.

    /*ATENCION: CUANDO BLOQUEE LOS BOTONES EN EL MENU ESTAS FUNCIONES VAN A TIRAR ERROR PROBABLEMENTE
    PUES SE VA A ACTIVAR UN OBJETO (OptionsCursor) Child de otro (OptionButton) que va a estar
    desactivado. ¿Solución? MÁS CONDICIONALES. el siguiente ejemplo iría en cursor down:
    
      if (OptionsCursor01.activeSelf)
     {
        if (MainManager.Instance.adukeUnlocked)
        {
            OptionsCursor01.SetActive(false);
            OptionsCursor02.SetActive(true);
        }
     } 
     
     Y así luego según qué opciones estén unlocked
     la cagada es que estoy operando sobre Objetos por nombre
     Y si eventualmente hago que los botones provean opciones al azar
     voy a tener que reescribir estas funciones
     
     
     NUEVA RESPUESTA, MÁS SENCILLA, QUE TAMBIÉN RESUELVE EL PROBLEMA DE LAS OPCIONES QUE NO SE VEN
     PORQUE YA ESTÁN EN LVL 10: USAR EL OBJETO 
     
     en Start: 
     LvlUpOption2 = GameObject.Find("LvlUpOption2");

     en la función: 

     if (OptionsCursor01.activeSelf)
     {
        if (LvlUpOption2.activeSelf)
        {
            OptionsCursor01.SetActive(false);
            OptionsCursor02.SetActive(true);
        }
     } 

     etc.

     ÚLTIMO PROBLEMA: atención al cursor activo por defecto. si llega a lvl 10 el shuriken: ¿donde
     inicia el cursor?
     
     RESPUESTA: CON EL JUEGO DESPAUSEADO EL CURSOR SE SIGUE MOVIENDO APARENTEMENTE
     CON LO QUE SI BLOQUEO EL SALTO CON ESTA ÚLTIMA SOLUCIÓN DEBERÍA ARREGLARSE TODO
     NO ESTOY SEGURO DE LA EFICIENCIA DE TENER EL COSO SALTIMBANQUEANDO EN INVI*/
     
     
    

    public void CursorDown()
    {
        if (OptionsCursor01.activeSelf)
        {
            OptionsCursor01.SetActive(false);
            OptionsCursor02.SetActive(true);
        }

        else if (OptionsCursor02.activeSelf)
        {
            OptionsCursor02.SetActive(false);
            OptionsCursor03.SetActive(true);
        }
        else if (OptionsCursor03.activeSelf)
        {
            OptionsCursor03.SetActive(false);
            OptionsCursor04.SetActive(true);
        }
    }

    public void CursorUp()
    {
        if (OptionsCursor04.activeSelf)
        {
            OptionsCursor04.SetActive(false);
            OptionsCursor03.SetActive(true);
        }

        else if (OptionsCursor03.activeSelf)
        {
            OptionsCursor03.SetActive(false);
            OptionsCursor02.SetActive(true);
        }
        else if (OptionsCursor02.activeSelf)
        {
            OptionsCursor02.SetActive(false);
            OptionsCursor01.SetActive(true);
        }

    }
    
    public void CursorLeft()
    {
        if (OptionsCursor05.activeSelf)
        {
            OptionsCursor05.SetActive(false);
            OptionsCursor01.SetActive(true);
        }
    }
    public void CursorRight()
    {
        if (OptionsCursor01.activeSelf)
        {
            OptionsCursor01.SetActive(false);
            OptionsCursor05.SetActive(true);
        }
    }



    public void ExecuteCurrentOption()
    {
        if (OptionsCursor01.activeSelf)
        {
            Messi.GetComponent<MessiController>().LvlUpShuriken();
            GameController.GetComponent<GameController>().LvlUpMenuOut();
        }
         else if (OptionsCursor02.activeSelf)
        {
            Messi.GetComponent<MessiController>().LvlUpMaxHp();
            GameController.GetComponent<GameController>().LvlUpMenuOut();
        }
        else if (OptionsCursor03.activeSelf)
        {
            Messi.GetComponent<MessiController>().LvlUpAduke();
            GameController.GetComponent<GameController>().LvlUpMenuOut();
        }
        else if (OptionsCursor04.activeSelf)
        {
            //xD esto no hace nada
            GameController.GetComponent<GameController>().LvlUpMenuOut();
        }
        else if (OptionsCursor05.activeSelf)
        {
            Messi.GetComponent<MessiController>().LvlUpDiMaria();
            GameController.GetComponent<GameController>().LvlUpMenuOut();
        } 
    }

}
