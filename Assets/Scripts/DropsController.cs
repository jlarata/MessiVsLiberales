using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DropsController : MonoBehaviour
{
    
    public GameObject messi;
    public float messiVelocity;
    public float speed;

    public float horizontalInput;
    public float verticalInput;
    
    void Start()
    {
        messi = GameObject.Find("Messi");
        messiVelocity = 2.0f;  
        speed = 0.5f;
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(-horizontalInput * Time.deltaTime * speed * messiVelocity, 0, 0);

        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(0, -verticalInput * Time.deltaTime * speed * messiVelocity, 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Messi")
        {
          Destroy(gameObject);
        }
    }
}
