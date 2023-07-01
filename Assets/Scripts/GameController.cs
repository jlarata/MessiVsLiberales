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

public class GameController : MonoBehaviour
{
    

    //had to add "G"background to prevent errors with the "background" element of the UI sliders
    [SerializeField]
    protected GameObject gBackground;
    [SerializeField]
    protected Vector3 bgStartPos;

    public GameObject messi;

    
    private float repeatWidth;
    private float repeatHeight;
    
    private float horizontalInput;
    private float verticalInput;
    
    [SerializeField]
    public float messiVelocity;

    public float exp;
    public int iExp;
    public float maxExp;
    public int lvl;


    //UI TMP Text objects
    public TMP_Text lvlAndExp;
    public TMP_Text timeDisplay;
    
    //clock
    public float seconds;
    public float xTime;
    public int iSeconds;
    public int minutes;

    [SerializeField] 
    protected Slider expSlider;


    //pause and endgame Menu and buttons
    [SerializeField]
    protected GameObject pauseMenu;
    [SerializeField]
    protected GameObject pauseText;
    [SerializeField]
    protected GameObject loseText;
    [SerializeField]
    protected Color loseTextColor;
    [SerializeField]
    protected GameObject exitButton;
    [SerializeField]
    protected GameObject restartButton;

    //Lvl up Menu and buttons
    public GameObject LvlUpMenu;
    public GameObject LvlUpText;
    public GameObject LvlUpOption1;
    public GameObject LvlUpOption2;
    public GameObject LvlUpOption3;
    public GameObject LvlUpOption4;
    public GameObject LvlUpOption5;

    //Cursor Controller
    public GameObject cursorController;

    [SerializeField]
    public int wave;

    [SerializeField]
    protected bool pausanias;
    [SerializeField]
    protected bool isLvlUpMenu;

    void Start()
    {
        Time.timeScale = 1;
        

        lvl = 1;
        exp = 0f;
        iExp = 0;
        seconds = 0f;
        xTime = 0f;
        iSeconds = 0;
        minutes = 0;
        wave = 0;
        

        maxExp = 10f;
        gBackground = GameObject.Find("GBackground");
        cursorController = GameObject.Find("Cursor Controller");

        messi = GameObject.Find("Messi");
        messiVelocity = messi.GetComponent<MessiController>().speed;

        pauseText = GameObject.Find("Pause Text");
        pauseText.SetActive(false);

        loseText = GameObject.Find("Lose Text");
        loseText.SetActive(false);
        loseTextColor = loseText.GetComponent<TMP_Text>().color;
        loseTextColor.a = 0f;
        loseText.GetComponent<TMP_Text>().color = loseTextColor;



        pauseMenu = GameObject.Find("Pause Menu");
        pauseMenu.SetActive(false);
        bgStartPos = gBackground.transform.position;
        repeatWidth = gBackground.GetComponent<Renderer>().bounds.size.x / 3;
        repeatHeight = gBackground.GetComponent<Renderer>().bounds.size.y / 3;


        LvlUpMenu = GameObject.Find("LvlUpMenu");
        LvlUpText = GameObject.Find("LvlUpText");
        LvlUpOption1 = GameObject.Find("LvlUpOption1");
        LvlUpOption2 = GameObject.Find("LvlUpOption2");
        LvlUpOption3 = GameObject.Find("LvlUpOption3");
        LvlUpOption4 = GameObject.Find("LvlUpOption4");
        LvlUpOption5 = GameObject.Find("LvlUpOption5");


        
        
        lvlAndExp = GameObject.Find("LvlAndExpDisplay").GetComponent<TMP_Text>();
        timeDisplay = GameObject.Find("TimeDisplay").GetComponent<TMP_Text>();
        
        lvlAndExp.text = "Level: " +lvl + " | Exp: " +exp;
        timeDisplay.text = minutes+":"+iSeconds;


        expSlider = GameObject.Find("ExpSlider").GetComponent<Slider>();
        expSlider.maxValue = maxExp;
        expSlider.value = exp;

        
        //lvlAndExpDisplay = lvlAndExpGameObject.GetComponent<Renderer>(TextMeshPro - Text);
        
        exitButton = GameObject.Find("ExitButton");
        exitButton.SetActive(false);
        restartButton = GameObject.Find("RestartButton");
        restartButton.SetActive(false);



    }

    public void HideLvlUpMenu()
    {
        LvlUpMenu.SetActive(false);
        LvlUpText.SetActive(false);
        LvlUpOption1.SetActive(false);
        LvlUpOption2.SetActive(false);
        LvlUpOption3.SetActive(false);
        LvlUpOption4.SetActive(false);
        LvlUpOption5.SetActive(false);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
        //infinite background
        if ((gBackground.transform.position.x < bgStartPos.x - repeatWidth) | (gBackground.transform.position.x > bgStartPos.x + repeatWidth))
        {
            gBackground.transform.Translate(-gBackground.transform.position.x, 0, 0);
            //background.transform.position = bgStartPos;
        }
        if ((gBackground.transform.position.y < bgStartPos.y - repeatHeight) | (gBackground.transform.position.y > bgStartPos.y + repeatHeight))
        {
            gBackground.transform.Translate(0, 0, -gBackground.transform.position.y);
        }

        //movement controller

        /* Old function.
        horizontalInput = Input.GetAxis("Horizontal");
        gBackground.transform.Translate(Vector3.right * -horizontalInput * Time.deltaTime * messiVelocity *0.5f);

        verticalInput = Input.GetAxis("Vertical");
        gBackground.transform.Translate(Vector3.forward * -verticalInput * Time.deltaTime * messiVelocity *0.5f); */

        horizontalInput = Input.GetAxis("Horizontal");
        gBackground.transform.Translate(-horizontalInput * Time.deltaTime * messiVelocity, 0, 0);

        verticalInput = Input.GetAxis("Vertical");
        gBackground.transform.Translate(0, 0, -verticalInput * Time.deltaTime * messiVelocity);


        if (exp >= maxExp)
        {
            LvlUp(1);
        }


        seconds += Time.deltaTime;
        if (seconds-xTime >=1)
        {
            xTime++;
            UpdateTime();
        }
        
        
        if (seconds >= 59f)
        {
            seconds = 0f;
            iSeconds = 0;
            xTime = 0f;
            minutes++;
        }
        
        if (Input.GetKeyDown(KeyCode.P) | Input.GetKeyDown(KeyCode.Escape))
        {
            PausaniasFunction();
        }
    }

    public void ExpUp(float expGain)
    {
        exp += expGain;
        UpdateLvlAndExpText();
        expSlider.value = exp;
    }

    public void LvlUp(int lvls)
    {
        exp = 0f;
        maxExp *= 1.2f;
        lvl += lvls;
        expSlider.maxValue = maxExp;
        LvlUpMenuFunction();
        
    }

    public void LvlUpMenuFunction()
    {

        isLvlUpMenu = true;
        Time.timeScale = 0;
        LvlUpMenu.SetActive(true);
        LvlUpText.SetActive(true);

        //shuriken
        if (messi.GetComponent<MessiController>().shurikenLvl < 10)
        {  
            LvlUpOption1.SetActive(true);
        }
        //maxhp
        LvlUpOption2.SetActive(true);

        //aduke
        if (messi.GetComponent<MessiController>().adukeLvl < 10)
        {
            LvlUpOption3.SetActive(true);
        }

        //nada
        LvlUpOption4.SetActive(true);

        //dimaria
        if (messi.GetComponent<MessiController>().diMariaLvl < 10)
        {
            LvlUpOption5.SetActive(true);
        }

        //cursor (it's important this is called after every options of lvlup)
        cursorController.GetComponent<CursorController>().SetCursorActive();
        
    }

    public void LvlUpMenuOut()
    {
        Time.timeScale = 1;
        LvlUpMenu.SetActive(false);
        LvlUpText.SetActive(false);
        LvlUpOption1.SetActive(false);
        LvlUpOption2.SetActive(false);
        LvlUpOption3.SetActive(false);
        LvlUpOption4.SetActive(false);
        LvlUpOption5.SetActive(false);
        isLvlUpMenu = false;
    }

    public void UpdateLvlAndExpText()
    {
    //lvlAndExp.text = "Level: " +lvl+ " | Exp: " +exp+ " | Exp to next level: " +(maxExp-exp) ;
    iExp = (int)exp;
    lvlAndExp.text = "Level: " +lvl + " | Exp: " +iExp;
    }

    public void UpdateTime()
    {
    
    // this would be the ENCAPSULATION Setter example
    //en el segundo 30 de cada minuto estaría sumando una wave

    if ((iSeconds == 31) | (iSeconds == 1))
    {
        wave ++;
    }
    
    iSeconds = (int)seconds;
    
    timeDisplay.text = minutes.ToString("00")+":"+iSeconds.ToString("00");
    }

    void PausaniasFunction()
    {
        if (!isLvlUpMenu)
        {
            if (!pausanias)
        {
            pausanias = true;
            pauseMenu.SetActive(true);
            pauseText.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            pausanias = false;
            pauseMenu.SetActive(false);
            pauseText.SetActive(false);
            Time.timeScale = 1;
        }
        }   
    }

    public void GameOver()
    {   
        //Persistence between sessions
        if (MainManager.Instance != null)
        {
            if (lvl > MainManager.Instance.LvlAchieved)
            {
                MainManager.Instance.LvlAchieved = lvl;
            }
            //here would go the conditional that unlockes aduke forever.
            MainManager.Instance.adukeUnlocked = false;
        } else {
        MainManager.Instance.LvlAchieved = lvl;
        MainManager.Instance.adukeUnlocked = false;
        }
        MainManager.Instance.SaveState();


        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        loseText.SetActive(true);
        StartCoroutine(LoseTextAnimation());
        
        exitButton.SetActive(true);
        restartButton.SetActive(true);
    }


    IEnumerator LoseTextAnimation()
    {
        while((loseTextColor.a) < 1.0f)
        {
            loseTextColor.a = loseTextColor.a + 0.005f;
            loseText.GetComponent<TMP_Text>().color = loseTextColor;
            //Debug.Log("a");
            yield return new WaitForSecondsRealtime(0.01f);
        }
    }




    //por prolijidad, buscar cómo se llama el Main Manager en la escena Main y tomar el método de ahí con el 
    //exitButton. 
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
    
    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }


    public void UnlockAndLock()
    {
        if (MainManager.Instance != null)
        {
            MainManager.Instance.UnlockAndLock();
        }
    }
    
    


}