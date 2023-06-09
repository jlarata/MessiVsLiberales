using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdukeController : WeaponController
{
    void Start()
    {
        speed = 0.35f;
        messi = GameObject.Find("Messi");
        //multipleFacing = messi.GetComponent<MessiController>().virtualRotation.GetComponent<VirtualRotation>().multipleFacing;
        totalMovementFacing = messi.GetComponent<MessiController>().virtualRotation.GetComponent<VirtualRotation>().totalMovementFacing;
        weaponDamage = 2.0f;
        weaponDuration = 2.5f;

        adukeLvl = messi.GetComponent<MessiController>().adukeLvl;

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

        scaleChange = transform.localScale;
        switch(adukeLvl)
        {
            case 1:
            scaleChange.x *= 0.7f;
            scaleChange.y *= 0.7f;
            break;
            case 2:
            scaleChange.x *= 0.9f;
            scaleChange.y *= 0.9f;
            break;
            case 3:
            weaponDamage *= 4f;
            scaleChange.x *= 0.9f;
            scaleChange.y *= 0.9f;
            break;
            case 4:
            weaponDamage *= 4f;
            scaleChange.x *= 1.1f;
            scaleChange.y *= 1.1f;
            break;
            case 5:
            weaponDamage *= 6f;
            scaleChange.x *= 1.1f;
            scaleChange.y *= 1.1f;
            break;
            case >5:
            weaponDamage *= 6f;
            scaleChange.x *= 1.3f;
            scaleChange.y *= 1.3f;
            break;
        }
        transform.localScale = scaleChange;


    
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
        
        
        switch(totalMovementFacing)
        {
            
            
            case 900:
            transform.Translate(Vector3.left * Time.deltaTime * speed, Space.World);
            break;            

            case 300:
            transform.Translate(Vector3.right * Time.deltaTime * speed, Space.World);
            break;

            case 600:
            transform.Translate(Vector3.down * Time.deltaTime * speed, Space.World);
            break;

            case 1200:
            transform.Translate(Vector3.up * Time.deltaTime * speed, Space.World);
            break;

            case 1030:
            transform.Translate(Vector3.up * Time.deltaTime * speed, Space.World);
            transform.Translate(Vector3.left * Time.deltaTime * speed, Space.World);
            break;
            
            case 130:
            transform.Translate(Vector3.up * Time.deltaTime * speed, Space.World);
            transform.Translate(Vector3.right * Time.deltaTime * speed, Space.World);
            break;

            case 430:
            transform.Translate(Vector3.right * Time.deltaTime * speed, Space.World);
            transform.Translate(Vector3.down * Time.deltaTime * speed, Space.World);
            break;

            case 730:
            transform.Translate(Vector3.down * Time.deltaTime * speed, Space.World);
            transform.Translate(Vector3.left * Time.deltaTime * speed, Space.World);
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
