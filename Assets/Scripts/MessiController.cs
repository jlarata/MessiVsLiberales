using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MessiController : MonoBehaviour
{
    

    public float hp;
    public Slider hpSlider;

    public bool isFiringShuriken;
    public bool isFiringAduke;
    public bool isRegen;


    //varios campos como este los hice públicos para llamarlos desde otros objetos
    //ideales para protegerlos y meterles getters y setters.
    [SerializeField]
    public GameObject virtualRotation;

    [SerializeField]
    protected GameObject gameController;

    
    public GameObject[] weapons;
    public GameObject slash;
    //public GameObject aduke;

    //lvlupvariables
    public float messiHpLvl;
    public float regenLvl;
    public float regenRatio;
    public float shurikenLvl;
    public float adukeLvl;
     

    
    // Start is called before the first frame update
    void Start()
    {
        
        messiHpLvl = 1f;
        regenLvl = 0.1f;
        regenRatio = 1f;

        if (MainManager.Instance != null)
        {
        shurikenLvl = MainManager.Instance.shurikenLvl;
        adukeLvl = MainManager.Instance.adukeLvl;
        } else {
        shurikenLvl = 1f;
        adukeLvl = 0f;
        }
        
        
        hp = 10.0f;
        hpSlider.maxValue = hp;
        hpSlider.value = 10.0f;
        virtualRotation = transform.Find("VRotation").gameObject;
        //virtualRotationScript = virtualRotation.GetComponent<VirtualRotation>();
        gameController = GameObject.Find("Game Controller");

        isFiringAduke = false;
        isFiringShuriken = false;
        isRegen = false;

        

    }

    

    void Update()
    {

        if (!isRegen && (hp < hpSlider.maxValue))
        {
            StartCoroutine(regenHP(regenLvl, regenRatio));
        }
        

        if (!isFiringAduke && !(adukeLvl == 0f))
        {
            //Dentro de Fire puede ir el parametro weaponDelay, que tome el delay especifico 
            // del arma que corresponda. eso implica repensar los métodos cuando haya más de un arma.
            StartCoroutine(FireAduke(2f));    
        }

        if (!isFiringShuriken && !(shurikenLvl == 0f))
        {
            //Dentro de Fire puede ir el parametro weaponDelay, que tome el delay especifico 
            // del arma que corresponda. eso implica repensar los métodos cuando haya más de un arma.
            StartCoroutine(FireShuriken(.8f));    
        }

        
        
    }

    public IEnumerator regenHP(float regenLvl, float regenRatio)
    {
        isRegen = true;
        hp += regenLvl;
        hpSlider.value = hp;
        yield return new WaitForSeconds(regenRatio);
        isRegen = false;
        
    }

    public IEnumerator FireAduke(float delayFire)
    {

            isFiringAduke = true;
            
  
            switch(virtualRotation.GetComponent<VirtualRotation>().totalMovementFacing)
            {




        //BUENO aparentemente el quaternion es un bardo de manejar, nunca se maneja una sola de las dimensiones
        //sino que se combinan entre ellas, como ejemplo este delirio que tuve que armar para 4 simples rotaciones.

        //update: the later comment says quaternions are REALLY hard to manage. 
        //as it can be shown in the frst 4 basic facing directions
        //however, the four diagonal-facing instantiating methods are created with a new, better, simpler method.
        // (quaternion.euler)

            //4 basic facing directions
            case 300: 
            Instantiate(weapons[0], transform.position + new Vector3(0.3f,0f,0), new Quaternion(0f,0f,0f,1f));
            break;

            case 600:
            Instantiate(weapons[0], transform.position + new Vector3(0f,-0.2f,0), new Quaternion(0f,0f,-1f,1f));
            break;

            case 900:
            Instantiate(weapons[0], transform.position + new Vector3(-0.3f,0f,0), new Quaternion(0f,0f,1f,0f));
            break;

            case 1200:
            Instantiate(weapons[0], transform.position + new Vector3(0f,0.2f,0), new Quaternion(0f,0f,-1f,-1f));
            break;

            //diagonals. up-left
            case 1030:
            Instantiate(weapons[0], transform.position + new Vector3(-0.3f,0.2f,0), transform.rotation * Quaternion.Euler (0f, 0f, 112.5f));
            break;
            
            //diagonals. up-right
            case 130:
            Instantiate(weapons[0], transform.position + new Vector3(0.3f,0.2f,0), transform.rotation * Quaternion.Euler (0f, 0f, 22.5f));
            break;

            //diagonals. down-left
            case 430:
            Instantiate(weapons[0], transform.position + new Vector3(0.3f,-0.2f,0), transform.rotation * Quaternion.Euler (0f, 0f, -22.5f));
            break;

            //diagonals. down-right
            case 730:
            Instantiate(weapons[0], transform.position + new Vector3(-0.3f,-0.2f,0), transform.rotation * Quaternion.Euler (0f, 0f, -112.5f));
            break;
            }

            yield return new WaitForSeconds(delayFire);
            isFiringAduke = false;

            
        
    }

    public IEnumerator FireShuriken(float delayFire)
    {
        //this is different from aduke because i dont want using up or down input interfering with this value
        //so if i were to use totalMovementFacing, i would have to set a response to 600 and 1200 cases
        //that would bring a new problem because i would want the shuriken "remember" if messi was facing right
        //or left before he went up or down. 

        //because of this, i still need the "hfacing" variable in VirtualRotation script. but (i think) 
        //i wont be using anymore the "multiplefacing" variable anymore. 
            isFiringShuriken = true;
            switch(virtualRotation.GetComponent<VirtualRotation>().hFacing)
            {
            case 9:
            Instantiate(weapons[1], transform.position + new Vector3(-0.3f,0.5f,0), transform.rotation);
            break;

            case 3: 
            Instantiate(weapons[1], transform.position + new Vector3(0.3f,0.5f,0), transform.rotation);
            break;
            }
            yield return new WaitForSeconds(delayFire);
            isFiringShuriken = false;

            
        
    }

    
    

    //function to be called when messi loses life
    public void PerderHp(float hpLoss)
    {
        if(hp>0)
        {
        hp -= hpLoss;
        hpSlider.value = hp;

        } else {
            Debug.Log("le game overino");
            gameController.GetComponent<GameController>().GameOver();
        }
    }

    //these two functions are triggered when LvlupOption2 gameobject button is clicked
    //note that is growing in discrete numbers, always 1f so, 10% of original hp
    //could be rewrited to something like messiHpLvl *= 1.1 / hpSlider.maxValue *= 1.1
    //so it would be always a 10% increment.
    public void LvlUpMaxHp()
    {
        messiHpLvl ++;
        updateMaxHp();
    }

    public void updateMaxHp()
    {
        hpSlider.maxValue++;
    }

    public void LvlUpShuriken()
    {
        shurikenLvl++;
    }

    public void LvlUpAduke()
    {
        adukeLvl++;
    }



}
