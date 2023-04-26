using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MessiController : MonoBehaviour
{
    

    public float hp;
    public Slider hpSlider;
    public float maxHp;

    public bool isFiring;


    //varios campos como este los hice públicos para llamarlos desde otros objetos
    //ideales para protegerlos y meterles getters y setters.
    [SerializeField]
    public GameObject virtualRotation;

    [SerializeField]
    protected GameObject gameController;

    

    public GameObject slash;

    
    // Start is called before the first frame update
    void Start()
    {
        hp = 10.0f;
        hpSlider.maxValue = hp;
        hpSlider.value = 10.0f;
        virtualRotation = transform.Find("VRotation").gameObject;
        //virtualRotationScript = virtualRotation.GetComponent<VirtualRotation>();
        gameController = GameObject.Find("Game Controller");

        isFiring = false;

    }

    // Update is called once per frame
    void Update()
    {

        if (!isFiring)
        {
            //Dentro de Fire puede ir el parametro weaponDelay, que tome el delay especifico 
            // del arma que corresponda. eso implica repensar los métodos cuando haya más de un arma.
            StartCoroutine(Fire(.8f));    
        }

        
        
    }

    public IEnumerator Fire(float delayFire)
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{   
            isFiring = true;
            switch(virtualRotation.GetComponent<VirtualRotation>().hFacing)
            {
            case 9:
            Instantiate(slash, transform.position + new Vector3(-0.3f,0.5f,0), transform.rotation);
            break;

            case 3: 
            Instantiate(slash, transform.position + new Vector3(0.3f,0.5f,0), transform.rotation);
            break;
            }
            yield return new WaitForSeconds(delayFire);
            isFiring = false;
        //}
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



}
