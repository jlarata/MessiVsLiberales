using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessiController : MonoBehaviour
{
    

    public float hp;
    public Slider hpSlider;
    public float maxHp;

    [SerializeField]
    protected GameObject virtualRotation;

    

    public GameObject slash;

    // Start is called before the first frame update
    void Start()
    {
        hp = 10.0f;
        hpSlider.maxValue = hp;
        hpSlider.value = 10.0f;
        virtualRotation = transform.Find("VRotation").gameObject;
        //virtualRotationScript = virtualRotation.GetComponent<VirtualRotation>();
        

    }

    // Update is called once per frame
    void Update()
    {

        //test function. fire first weapon Slash.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            switch(virtualRotation.GetComponent<VirtualRotation>().hFacing)
            {
            case 9:
            Instantiate(slash, transform.position + new Vector3(-0.5f,0.5f,0), transform.rotation);
            break;
            case 3: 
            Instantiate(slash, transform.position + new Vector3(0.5f,0.5f,0), transform.rotation);
            break;
            }
        }
    }
    

    //function to be called when messi loses life
    public void PerderHp(float hpLoss)
    {
        if(hp>0)
        {
        hp -= hpLoss;
        hpSlider.value = hp;

        } else {
            //worldText.text = "la re viviste máquina. geim over";
            Debug.Log("le game overino");
        }
    }



}
