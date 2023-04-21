using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    
    //[SerializeField]    
    //protected string lvlAndExpText;

    [SerializeField] 
    protected Slider expSlider;

    
    // Start is called before the first frame update
    void Start()
    {
        speed = 1.0f;

        lvl = 1;
        exp = 0f;
        
        maxExp = 10f;
        gBackground = GameObject.Find("GBackground");
        bgStartPos = gBackground.transform.position;
        repeatWidth = gBackground.GetComponent<Renderer>().bounds.size.x / 3;
        repeatHeight = gBackground.GetComponent<Renderer>().bounds.size.y / 3;

        //lvlAndExpText = "Level: " +lvl+ " | Exp: " +exp+ " | Exp to next level: " +(maxExp-exp) ;
        

        
        lvlAndExp = GameObject.Find("LvlAndExpDisplay").GetComponent<TMP_Text>();
        
        lvlAndExp.text = "Level: " +lvl + " | Exp: " +exp;

        expSlider = GameObject.Find("ExpSlider").GetComponent<Slider>();
        expSlider.maxValue = maxExp;
        expSlider.value = exp;

        
        //lvlAndExpDisplay = lvlAndExpGameObject.GetComponent<Renderer>(TextMeshPro - Text);
        


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

        //if (transform.position.x < startPos.x - repeatWidth) {
        //    transform.position = startPos;
        //}
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
    
}