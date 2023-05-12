using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdukeController : WeaponController
{
    void Start()
    {
        speed = 1;
        messi = GameObject.Find("Messi");
        multipleFacing = messi.GetComponent<MessiController>().virtualRotation.GetComponent<VirtualRotation>().multipleFacing;
 


        messiVelocity = 1f;
    
        // switch(messi.GetComponent<MessiController>().virtualRotation.GetComponent<VirtualRotation>().hFacing)
        // {
        //     case 3:
        //     left = false;
        //     break;

        //     case 9:
        //     left = true;
        //     break;
        // }

 
        


        StartCoroutine(Duration());
    }
    

    void Update()
    {
        WeaponBehaviour();
        
        
    }
    void LateUpdate()
    {
        
        

    }


    IEnumerator Duration()
    {
        
        yield return new WaitForSeconds(2.5f);
        Autodestroy();
    }

     public void Autodestroy()
    {
        Destroy(gameObject);
    }

    public void WeaponBehaviour()
    {
        //todos estos métodos tendrían que estar en un script class específico de esta arma, 
        //que herede del script padre WeaponController que solo tendría un método Fire vacío, o overrideable
        
        
        switch(multipleFacing)
        {
            case 9:
            transform.Translate(Vector3.left * Time.deltaTime * speed * 0.8f, Space.World);
            break;

            case 3:
            transform.Translate(Vector3.right * Time.deltaTime * speed * 0.8f, Space.World);
            break;

            case 6:
            transform.Translate(Vector3.down * Time.deltaTime * speed * 0.8f, Space.World);
            break;

            case 12:
            transform.Translate(Vector3.up * Time.deltaTime * speed * 0.8f, Space.World);
            break;
        
        }
        
        // switch(left)
        // {
        //     case true:
        //     transform.Translate(Vector3.left * Time.deltaTime * speed * 0.8f, Space.World);
        //     break;

        //     case false:
        //     transform.Translate(Vector3.right * Time.deltaTime * speed * 0.8f, Space.World);
        //     break;
        
        // }

        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(-horizontalInput * Time.deltaTime * speed * messiVelocity, 0, 0, Space.World);

        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(0, -verticalInput * Time.deltaTime * speed * messiVelocity, 0, Space.World);
    }
}
