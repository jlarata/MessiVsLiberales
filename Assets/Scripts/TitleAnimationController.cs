using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;


public class TitleAnimationController : MonoBehaviour
{

    [SerializeField]
    protected TMP_Text titleA;
    [SerializeField]
    protected Vector3 titleAStartPos;
    [SerializeField]
    protected TMP_Text titleB;
    [SerializeField]
    protected Vector3 titleBStartPos;
    public GameObject startButton;

    public Vector3 startButtonStartPos;
    
    public GameObject exitButton;
    
    public Vector3 exitButtonStartPos;
    public Vector3 marketButtonStartPos;
    
    
    [SerializeField]
    protected GameObject messiFondo;
    
    [SerializeField]
    protected GameObject d3c;
    

    [SerializeField]
    protected bool moveRestOfTitles;

    [SerializeField]
    protected bool fadeIn;

    [SerializeField]
    protected bool moveFirstTitle;

    [SerializeField]
    protected Color messiColor;

    [SerializeField]
    protected Color d3cColor;

    public GameObject[] buttonsList;
    public GameObject titleController;

    //buttons
    public GameObject StartButtonInstance;
    public GameObject ExitButtonInstance;
    public GameObject MarketButtonInstance;
    //titles
    public GameObject titleBInstance;
    public GameObject titleAInstance;
    public Color titleAInstanceColor;

    // Start is called before the first frame update
    void Start()
    {

        titleController = GameObject.Find("Title Controller");
        
        ButtonsInstance();
       
        

        
        StartCoroutine(TranslateTitlesAndFadeIn());
    
        
        titleAInstanceColor = titleAInstance.GetComponent<TMP_Text>().color;
        titleAInstanceColor.a = 0f;
        titleAInstance.GetComponent<TMP_Text>().color = titleAInstanceColor;        




        messiFondo = GameObject.Find("Messi Fondo");
        messiColor = messiFondo.GetComponent<SpriteRenderer>().color;
        messiColor.a = 0f;
        messiFondo.GetComponent<SpriteRenderer>().color = messiColor;


        d3c = GameObject.Find("d3c");
        d3cColor = d3c.GetComponent<TMP_Text>().color;
        d3cColor.a = 0f;
        d3c.GetComponent<TMP_Text>().color = d3cColor;

        /* this was for testing only, not needed anymore.
        it calls a mainmanager function that search the object and sets its text
        the new method in MarketScene is more complex because first it creates the button
        and then references to it in order to sets its text
        if (MainManager.Instance != null)
        {
            MainManager.Instance.IniciateWealthDisplay();
        }*/
        
    }

    IEnumerator TranslateTitlesAndFadeIn()
    {
        
        yield return new WaitForSeconds(3f);
        fadeIn = true;
        moveFirstTitle = true;
        yield return new WaitForSeconds(3f);
        moveRestOfTitles = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (moveFirstTitle)
        
        {
            if (titleAInstanceColor.a < .9f)
            {
                titleAInstanceAlfa();
            }
            
            if (!(titleAInstance.transform.position.y <= (titleAStartPos.y -370)))
            {
                titleAInstance.transform.Translate(0, -1.5f, 0 * Time.deltaTime);
            }

        }

        

        if (fadeIn)
        {
            if (messiColor.a < .6f)
            {
                messiColor.a = messiColor.a + 0.01f;
                messiFondo.GetComponent<SpriteRenderer>().color = messiColor;
                d3cColor.a = d3cColor.a + 0.01f;
                d3c.GetComponent<TMP_Text>().color = d3cColor;
            }
            
            
        }

        if (moveRestOfTitles)
        {

            /*if (!(titleB.transform.position.x >= (titleBStartPos.x + 800))) 
            {
            titleB.transform.Translate(25, 0, 0 * Time.deltaTime);
            }*/

            /*if (!(startButton.transform.position.y >= (startButtonStartPos.y + 700))) 
            {
            startButton.transform.Translate(0, 32, 0 * Time.deltaTime);
            }*/

            if (!(titleBInstance.transform.position.x >= (titleBStartPos.x + 1800))) 
            {
            titleBInstance.transform.Translate(50, 0, 0 * Time.deltaTime);
            }

            if (!(StartButtonInstance.transform.position.y >= (startButtonStartPos.y + 700))) 
            {
            StartButtonInstance.transform.Translate(0, 16, 0 * Time.deltaTime);
            }

            if (!(ExitButtonInstance.transform.position.y >= (exitButtonStartPos.y + 700))) 
            {
            ExitButtonInstance.transform.Translate(0, 32, 0 * Time.deltaTime);
            }

            if (!(MarketButtonInstance.transform.position.y >= (marketButtonStartPos.y + 600)))
            {
                MarketButtonInstance.transform.Translate(0, 8, 0 * Time.deltaTime);
            }

            if (!(MarketButtonInstance.transform.position.x >= (marketButtonStartPos.x + 200)))
            {
                
                MarketButtonInstance.transform.Translate(2.8f, 0, 0 * Time.deltaTime);
            }
            


        }
    }

    public void ButtonsInstance()
    {

        //this is going to get .setParent from the buttons and titles instantiation
        GameObject canvas = GameObject.Find("Canvas");
        //in Canvas, sorting order is organized by scene hierarchy. so i use empty objects to control that hierarchy:
        GameObject TitlesCanvas = GameObject.Find("TitlesCanvas");
        GameObject TitleACanvas = GameObject.Find("TitleACanvas");


        //Set each title starting position and then set that Vector3 as a variable
        //to be used on the movement animation
        titleBInstance = Instantiate(buttonsList[1], new Vector3(-600,-518,0), new Quaternion(0,0,0,0));
        
        titleAInstance = Instantiate(buttonsList[2], new Vector3(400,0,0), new Quaternion(0,0,0,0));
        
        
        StartButtonInstance = Instantiate(buttonsList[0], new Vector3(0,0,0), new Quaternion(0,0,0,0));
        ExitButtonInstance = Instantiate(buttonsList[0], new Vector3(0,0,0), new Quaternion(0,0,0,0));

        //third button: market. this sets the parent object directly in the instantation.
        MarketButtonInstance = (GameObject)Instantiate(buttonsList[0], new Vector3(0,0,0), new Quaternion(0,0,0,0), canvas.transform);

        //Debug.Log("buttons created");

        //titleBInstance.GetComponentInChildren<TMP_Text>().text = "Vs \r\n Liberals";
        StartButtonInstance.GetComponentInChildren<TMP_Text>().text = "Start";
        ExitButtonInstance.GetComponentInChildren<TMP_Text>().text = "Exit";
        MarketButtonInstance.GetComponentInChildren<TMP_Text>().text = "Free Market";

        //Debug.Log("text changed");

        titleBInstance.transform.SetParent(TitlesCanvas.transform);
        
        titleAInstance.transform.SetParent(TitleACanvas.transform);
        

        StartButtonInstance.transform.SetParent(canvas.transform);
        ExitButtonInstance.transform.SetParent(canvas.transform);

        titleBInstance.transform.localPosition = new Vector3(-2000,100,0);
        titleBStartPos = titleBInstance.transform.position;
        titleAInstance.transform.localPosition = new Vector3(-50, 618,0);
        titleAStartPos = titleAInstance.transform.position;
        
        //Set each button starting position and then set that Vector3 as a variable
        //to be used on the movement animation
        StartButtonInstance.transform.localPosition = new Vector3(-400,-800,0);
        startButtonStartPos = StartButtonInstance.transform.position;
        ExitButtonInstance.transform.localPosition = new Vector3(400,-850,0);
        exitButtonStartPos = ExitButtonInstance.transform.position;
        MarketButtonInstance.transform.localPosition = new Vector3(-200, -800, 0);
        marketButtonStartPos = MarketButtonInstance.transform.position;
        

        UnityEngine.UI.Button StartButtonInstanceBtn = StartButtonInstance.GetComponent<Button>();
        UnityEngine.UI.Button ExitButtonInstanceBtn = ExitButtonInstance.GetComponent<Button>();
        UnityEngine.UI.Button MarketButtonInstanceBtn = MarketButtonInstance.GetComponent<Button>();

        StartButtonInstanceBtn.onClick.AddListener(StartNew);
        ExitButtonInstanceBtn.onClick.AddListener(Exit);
        MarketButtonInstanceBtn.onClick.AddListener(Market);

    }

    

    public void StartNew()
    {
        titleController.GetComponent<TitleController>().StartNew();
    }
    public void Exit()
    {
        titleController.GetComponent<TitleController>().Exit();
    }

    public void Market()
    {
        titleController.GetComponent<TitleController>().Market();
    }


    public void titleAInstanceAlfa()
    {
        if (titleAInstanceColor.a < 1f)
            {
                titleAInstanceColor.a = titleAInstanceColor.a + 0.005f;
                titleAInstance.GetComponent<TMP_Text>().color = titleAInstanceColor;
            }
    }
    
}
