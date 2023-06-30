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

    public GameObject LvlUpOption1;
    public GameObject LvlUpOption2;
    public GameObject LvlUpOption3;
    public GameObject LvlUpOption4;
    public GameObject LvlUpOption5;
    /* public GameObject LvlUpOption6;
    public GameObject LvlUpOption7;
    public GameObject LvlUpOption8;
    public GameObject LvlUpOption9;
    public GameObject LvlUpOption10; */
    

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

        LvlUpOption1 = GameObject.Find("LvlUpOption1");
        LvlUpOption2 = GameObject.Find("LvlUpOption2");
        LvlUpOption3 = GameObject.Find("LvlUpOption3");
        LvlUpOption4 = GameObject.Find("LvlUpOption4");
        LvlUpOption5 = GameObject.Find("LvlUpOption5");
        /* LvlUpOption6 = GameObject.Find("LvlUpOption6");
        LvlUpOption7 = GameObject.Find("LvlUpOption7");
        LvlUpOption8 = GameObject.Find("LvlUpOption8");
        LvlUpOption9 = GameObject.Find("LvlUpOption9");
        LvlUpOption10 = GameObject.Find("LvlUpOption10"); */


        OptionsCursor01.SetActive(false);
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

         GameController.GetComponent<GameController>().HideLvlUpMenu();
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
        //cursor is on option 1 (shuriken)
        if (OptionsCursor01.activeSelf)
        {
            //case 1: option 2 (maxHP) not active

            if (!LvlUpOption2.activeSelf)

            {
                //case 1-b option 3 (aduke) not active
                if (!LvlUpOption3.activeSelf)
                {
                    OptionsCursor01.SetActive(false);
                    OptionsCursor04.SetActive(true);
                }
                else
                {
                    //case 1-a option 3 (aduke) active
                    OptionsCursor01.SetActive(false);
                    OptionsCursor03.SetActive(true);    
                }
                
            } else
            {
            //case 2 option 2 (maxHP) active
            OptionsCursor01.SetActive(false);
            OptionsCursor02.SetActive(true);    
            }            
        }
        //cursor is on option 2 (maxhp)
        else if (OptionsCursor02.activeSelf)
        {
            //case 1: option 3 (aduke) not active
            if (!LvlUpOption3.activeSelf)
            {
                if (LvlUpOption4.activeSelf)
                {
                    OptionsCursor02.SetActive(false);
                    OptionsCursor04.SetActive(true);
                }
                
            } else
            {
                //case 2: option 3 (aduke) active
                OptionsCursor02.SetActive(false);
                OptionsCursor03.SetActive(true);                
            }

        }
        else if (OptionsCursor03.activeSelf)
        {
            //only case possible: option 4 (xD) active
            if (LvlUpOption4.activeSelf)
            {
                OptionsCursor03.SetActive(false);
                OptionsCursor04.SetActive(true);
            }
            
        }
    }

    public void CursorUp()
    {
        //cursor is on option 4 (xD)
        if (OptionsCursor04.activeSelf)
        {
            //case 1: option 3 (aduke) is not active
            if (!LvlUpOption3.activeSelf)
                {
                    //case 1-b: option 2 (maxHp) is not active 
                    if (!LvlUpOption2.activeSelf)
                    {
                       //option1 must be active
                        if (LvlUpOption1.activeSelf)
                        {
                            OptionsCursor04.SetActive(false);
                            OptionsCursor01.SetActive(true);
                        }

                    } else
                    {
                    //option 2 active
                    OptionsCursor04.SetActive(false);
                    OptionsCursor02.SetActive(true);
                    }
                    
                } else 
                {
                    //option 3 (aduke) is active
                    OptionsCursor04.SetActive(false);
                    OptionsCursor03.SetActive(true);
                }

        }

        //cursor is on option 3 (aduke)
        else if (OptionsCursor03.activeSelf)
        {
            //option 2 (maxHp) is not active 
            if (!LvlUpOption2.activeSelf)
            {
                //option 1 must be active
                    if (LvlUpOption1.activeSelf)
                    {
                        OptionsCursor03.SetActive(false);
                        OptionsCursor01.SetActive(true);
                    }         
            } else  
            {
            //option 2 (MaxHp) is active
            OptionsCursor03.SetActive(false);
            OptionsCursor02.SetActive(true);
            }
        }
        //cursor is on option 2 (maxHp)
        else if (OptionsCursor02.activeSelf)
        {
            //option 1 (shuriken) must be active
            if (LvlUpOption1.activeSelf)
            {
                OptionsCursor02.SetActive(false);
                OptionsCursor01.SetActive(true);
            }
            
        }

    }
    
    public void CursorLeft()
    {
        if (OptionsCursor05.activeSelf)
        {
            if (LvlUpOption1.activeSelf)
            {
            OptionsCursor01.SetActive(true);
            OptionsCursor05.SetActive(false);
            } else
            if (LvlUpOption2.activeSelf)
            {
            OptionsCursor02.SetActive(true);
            OptionsCursor05.SetActive(false);
            } else
            if (LvlUpOption3.activeSelf)
            {
            OptionsCursor03.SetActive(true);
            OptionsCursor05.SetActive(false);
            } else 
            if (LvlUpOption4.activeSelf)
            {
            OptionsCursor04.SetActive(true);
            OptionsCursor05.SetActive(false);
            }
        }
    }

    public void CursorRight()
    {
        if (OptionsCursor01.activeSelf)
        {
            if (LvlUpOption5.activeSelf)
            {
            OptionsCursor01.SetActive(false);
            OptionsCursor05.SetActive(true);
            } /*else
            if (LvlUpOption6.activeSelf)
            {
            OptionsCursor01.SetActive(false);
            OptionsCursor06.SetActive(true);
            } else
            if (LvlUpOption7.activeSelf)
            {
            OptionsCursor01.SetActive(false);
            OptionsCursor07.SetActive(true);
            } else 
            if (LvlUpOption8.activeSelf)
            {
            OptionsCursor01.SetActive(false);
            OptionsCursor08.SetActive(true);
            }*/
        } else
        if (OptionsCursor02.activeSelf)
        {
            /*if (LvlUpOption6.activeSelf)
            {
            OptionsCursor02.SetActive(false);
            OptionsCursor06.SetActive(true);
            }*/
            if (LvlUpOption5.activeSelf)
            {
            OptionsCursor02.SetActive(false);
            OptionsCursor05.SetActive(true);
            } /*else
            if (LvlUpOption7.activeSelf)
            {
            OptionsCursor02.SetActive(false);
            OptionsCursor07.SetActive(true);
            } else 
            if (LvlUpOption8.activeSelf)
            {
            OptionsCursor02.SetActive(false);
            OptionsCursor08.SetActive(true);
            }*/
        } else
        if (OptionsCursor03.activeSelf)
        {
            /*
            if (LvlUpOption7.activeSelf)
            {
            OptionsCursor03.SetActive(false);
            OptionsCursor07.SetActive(true);
            } else            
            if (LvlUpOption6.activeSelf)
            {
            OptionsCursor03.SetActive(false);
            OptionsCursor06.SetActive(true);
            } else 
            if (LvlUpOption8.activeSelf)
            {
            OptionsCursor03.SetActive(false);
            OptionsCursor08.SetActive(true);
            } else */
            if (LvlUpOption5.activeSelf)
            {
            OptionsCursor03.SetActive(false);
            OptionsCursor05.SetActive(true);
            } 
        } else
        if (OptionsCursor04.activeSelf)
        {
            /*
            if (LvlUpOption8.activeSelf)
            {
            OptionsCursor04.SetActive(false);
            OptionsCursor08.SetActive(true);
            } else
            if (LvlUpOption7.activeSelf)
            {
            OptionsCursor04.SetActive(false);
            OptionsCursor07.SetActive(true);
            } else            
            if (LvlUpOption6.activeSelf)
            {
            OptionsCursor04.SetActive(false);
            OptionsCursor06.SetActive(true);
            } else 
             */
            if (LvlUpOption5.activeSelf)
            {
            OptionsCursor04.SetActive(false);
            OptionsCursor05.SetActive(true);
            } 
        }

    }



    public void ExecuteCurrentOption()
    {
        if (OptionsCursor01.activeSelf)
        {
            OptionsCursor01.SetActive(false);
            Messi.GetComponent<MessiController>().LvlUpShuriken();
            GameController.GetComponent<GameController>().LvlUpMenuOut();
        }
         else if (OptionsCursor02.activeSelf)
        {
            OptionsCursor02.SetActive(false);
            Messi.GetComponent<MessiController>().LvlUpMaxHp();
            GameController.GetComponent<GameController>().LvlUpMenuOut();
        }
        else if (OptionsCursor03.activeSelf)
        {
            OptionsCursor03.SetActive(false);
            Messi.GetComponent<MessiController>().LvlUpAduke();
            GameController.GetComponent<GameController>().LvlUpMenuOut();
        }
        else if (OptionsCursor04.activeSelf)
        {
            OptionsCursor04.SetActive(false);
            //xD esto no hace nada
            GameController.GetComponent<GameController>().LvlUpMenuOut();
        }
        else if (OptionsCursor05.activeSelf)
        {
            OptionsCursor05.SetActive(false);
            Messi.GetComponent<MessiController>().LvlUpDiMaria();
            GameController.GetComponent<GameController>().LvlUpMenuOut();
        } 
    }

    // this is the function called from the GameController: activates the cursor on the 
    // first option avaiable 
    public void SetCursorActive()
    {
        if (LvlUpOption1.activeSelf)
        {
            OptionsCursor01.SetActive(true);
        } else if (LvlUpOption2.activeSelf)
        {
            OptionsCursor02.SetActive(true);
        } else if (LvlUpOption3.activeSelf)
        {
            OptionsCursor03.SetActive(true);
        } else if (LvlUpOption4.activeSelf)
        {
            OptionsCursor04.SetActive(true);
        } else if (LvlUpOption5.activeSelf)
        {
            OptionsCursor05.SetActive(true);
        } /* else if (LvlUpOption1.activeSelf)
        {
            OptionsCursor01.SetActive(true);
        } else if (LvlUpOption1.activeSelf)
        {
            OptionsCursor01.SetActive(true);
        } else if (LvlUpOption1.activeSelf)
        {
            OptionsCursor01.SetActive(true);
        } else if (LvlUpOption1.activeSelf)
        {
            OptionsCursor01.SetActive(true);
        } else if (LvlUpOption1.activeSelf)
        {
            OptionsCursor01.SetActive(true);
        }  */ 
        
    }

}
