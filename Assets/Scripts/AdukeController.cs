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
        weaponDamage = 2.0f;
        weaponDuration = 2.5f;

        //if i lower this messivelocity, it reduces the factor of modification of the weapon fired as the
        //player moves. but that also reduces the effect of the aduken staying on axis while player moving
        // this is a problem. don't know how to solve.
       //one obvious solution is making the aduken faster. but that would make, well, faster adukens. 

        messiVelocity = 0.8f;
    
        // switch(messi.GetComponent<MessiController>().virtualRotation.GetComponent<VirtualRotation>().hFacing)
        // {
        //     case 3:
        //     left = false;
        //     break;

        //     case 9:
        //     left = true;
        //     break;
        // }

 
        


        StartCoroutine(Duration(weaponDuration));
    }
    

    void Update()
    {
        WeaponBehaviour();
        
        
    }
    void LateUpdate()
    {
        
        

    }




    new public void Autodestroy()
    {
        Destroy(gameObject);
    }

    //Both Autodestroy and WeaponBehaviour are hiding inherited functions from WeaponController.
    //To do so, i've added the "new" word. I've read some warnings against this so, lets be aware of possible
    //malcfunctions on these two.

    new public void WeaponBehaviour()
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
