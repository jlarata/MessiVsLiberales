using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    [SerializeField]
    protected GameObject startButton;
    [SerializeField]
    protected Vector3 startButtonStartPos;
    [SerializeField]
    protected GameObject exitButton;
    [SerializeField]
    protected Vector3 exitButtonStartPos;
    
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

    // Start is called before the first frame update
    void Start()
    {
        titleA = GameObject.Find("TitleA").GetComponent<TMP_Text>();
        titleAStartPos = titleA.transform.position;
        titleB = GameObject.Find("TitleB").GetComponent<TMP_Text>();
        titleBStartPos = titleB.transform.position;
        StartCoroutine(TranslateTitlesAndFadeIn());
    
        



        startButton = GameObject.Find("StartButton");
        startButtonStartPos = startButton.transform.position;
        exitButton = GameObject.Find("ExitButton");
        exitButtonStartPos = exitButton.transform.position;
        


        messiFondo = GameObject.Find("Messi Fondo");
        messiColor = messiFondo.GetComponent<SpriteRenderer>().color;
        messiColor.a = 0f;
        messiFondo.GetComponent<SpriteRenderer>().color = messiColor;


        d3c = GameObject.Find("d3c");
        d3cColor = d3c.GetComponent<TMP_Text>().color;
        d3cColor.a = 0f;
        d3c.GetComponent<TMP_Text>().color = d3cColor;


        if (MainManager.Instance != null)
        {
            MainManager.Instance.IniciateWealthDisplay();
        }
        
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
            if (!(titleA.transform.position.y <= (titleAStartPos.y -270)))
            {
                titleA.transform.Translate(0, -1.5f, 0 * Time.deltaTime);
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
            if (!(titleB.transform.position.x >= (titleBStartPos.x + 800))) 
            {
            titleB.transform.Translate(25, 0, 0 * Time.deltaTime);
            }

            if (!(startButton.transform.position.y >= (startButtonStartPos.y + 400))) 
            {
            startButton.transform.Translate(0, 16, 0 * Time.deltaTime);
            }

            if (!(exitButton.transform.position.y >= (exitButtonStartPos.y + 400))) 
            {
            exitButton.transform.Translate(0, 16, 0 * Time.deltaTime);
            }


        }
    }
}
