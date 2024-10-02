using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DropsController : MonoBehaviour
{
    
    public GameObject messi;
    public MessiController MessiController;
    public GameObject gameController;
    public GameController GameController;

    public float messiVelocity;
    public float speed;

    public float horizontalInput;
    public float verticalInput;

    public int value;
    
    void Start()
    {
        messi = GameObject.Find("Messi");
        MessiController = messi.GetComponent<MessiController>();
        messiVelocity = MessiController.speed;

        //el objeto:
        gameController = GameObject.Find("Game Controller");
        //el script:
        GameController = gameController.GetComponent<GameController>(); 
        speed = 0.5f;
        
        SetValue();
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(-horizontalInput * Time.deltaTime * messiVelocity, 0, 0, Space.World);

        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(0, -verticalInput * Time.deltaTime * messiVelocity, 0, Space.World);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Messi")
        {
            GameController.UpdateCurrentWealth(value);
            Destroy(gameObject);
        }
    }

    public void SetValue()
    {
        if (this.name == "Messimoleon Copper(Clone)")
        {
            value = 1;
        } else
        if (this.name == "Messimoleon Silver(Clone)")
        {
            value = 5;
        } else
        if (this.name == "Messimoleon Gold(Clone)")
        {
            value = 20;
        } else
        if (this.name == "Messimoleon Gold Several1(Clone)" || this.name == "Messimoleon Gold Several2(Clone)")
        {
            value = 80;
        } else
        if (this.name == "Messimoleon Goldbag(Clone)")
        {
            value = 300;
        }  
        
    }
}
