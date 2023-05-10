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
    
    private float repeatWidth;
    private float repeatHeight;
    
    private float horizontalInput;
    private float verticalInput;
    
    [SerializeField]
    private float speed;

    public float exp;
    public float maxExp;
    public int lvl;

    public TMP_Text lvlAndExp;
    public TMP_Text timeDisplay;
    //construir variables segundo, minuto, etc y hacerlas funcionar?
    public float seconds;
    public float xTime;
    public int iSeconds;
    public int minutes;

    [SerializeField] 
    protected Slider expSlider;

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


    //ENCAPSULATION tho not sure if i apllied this how it is supposed to
    [SerializeField]
    private int m_Wave = 0;

    [SerializeField]
    public int Wave
    {
        get { return m_Wave;}
        set { m_Wave = value;}
    }


    [SerializeField]
    protected bool pausanias;    


    void Start()
    {
        Time.timeScale = 1;
        speed = 1.0f;

        lvl = 1;
        exp = 0f;
        seconds = 0f;
        xTime = 0f;
        iSeconds = 0;
        minutes = 0;
        

        maxExp = 10f;
        gBackground = GameObject.Find("GBackground");

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

        //lvlAndExpText = "Level: " +lvl+ " | Exp: " +exp+ " | Exp to next level: " +(maxExp-exp) ;
        

        
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
        horizontalInput = Input.GetAxis("Horizontal");
        gBackground.transform.Translate(Vector3.right * -horizontalInput * Time.deltaTime * speed);

        verticalInput = Input.GetAxis("Vertical");
        gBackground.transform.Translate(Vector3.forward * -verticalInput * Time.deltaTime * speed);

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
        
    }

    public void UpdateLvlAndExpText()
    {
    //lvlAndExp.text = "Level: " +lvl+ " | Exp: " +exp+ " | Exp to next level: " +(maxExp-exp) ;
   
    lvlAndExp.text = "Level: " +lvl + " | Exp: " +exp;
    }

    public void UpdateTime()
    {
    
    // this would be the ENCAPSULATION Setter example
    //en el segundo 30 de cada minuto estaría sumando una wave

    if ((iSeconds == 31) | (iSeconds == 1))
    {
        Wave ++;
    }
    
    iSeconds = (int)seconds;
    
    timeDisplay.text = minutes.ToString("00")+":"+iSeconds.ToString("00");
    }

    void PausaniasFunction()
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

    public void GameOver()
    {   
        
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
            Debug.Log("a");
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

}