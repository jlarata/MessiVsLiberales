using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessiController : MonoBehaviour
{
    

    public float hp;
    public Slider hpSlider;
    public float maxHp;

    // Start is called before the first frame update
    void Start()
    {
        hp = 10.0f;
        hpSlider.maxValue = hp;
        hpSlider.value = 10.0f;
        

    }

    // Update is called once per frame
    void Update()
    {


        //test function, with no use in the game.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PerderHp(0.5f);
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
