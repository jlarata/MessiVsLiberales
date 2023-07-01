using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdukeController : WeaponController
{
    void Start()
    {
        speed = 0.35f;
        messi = GameObject.Find("Messi");
        MessiController = messi.GetComponent<MessiController>();
        messiVelocity = MessiController.speed; 
        //multipleFacing = messi.GetComponent<MessiController>().virtualRotation.GetComponent<VirtualRotation>().multipleFacing;
        totalMovementFacing = messi.GetComponent<MessiController>().virtualRotation.GetComponent<VirtualRotation>().totalMovementFacing;
        weaponDamage = 2.0f;
        weaponDuration = 2.5f;

        adukeLvl = messi.GetComponent<MessiController>().adukeLvl;


    
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
            weaponDuration = 2f;
            scaleChange.x *= 0.7f;
            scaleChange.y *= 0.7f;
            break;
            case 2:
            weaponDuration = 2f;
            scaleChange.x *= 0.9f;
            scaleChange.y *= 0.9f;
            break;
            case 3:
            weaponDuration = 2.5f;
            weaponDamage *= 2f;
            scaleChange.x *= 0.9f;
            scaleChange.y *= 0.9f;
            break;
            case 4:
            weaponDuration = 2.5f;
            weaponDamage *= 2f;
            scaleChange.x *= 1.1f;
            scaleChange.y *= 1.1f;
            break;
            case 5:
            weaponDuration = 2.5f;
            weaponDamage *= 4f;
            scaleChange.x *= 1.1f;
            scaleChange.y *= 1.1f;
            break;
            case 6:
            weaponDuration = 3f;
            weaponDamage *= 4;
            scaleChange.x *= 1.1f;
            scaleChange.y *= 1.1f;
            break;
            case 7:
            weaponDuration = 3f;
            weaponDamage *= 4;
            scaleChange.x *= 1.3f;
            scaleChange.y *= 1.3f;
            break;
            case 8:
            weaponDuration = 3f;
            weaponDamage *= 6;
            scaleChange.x *= 1.3f;
            scaleChange.y *= 1.3f;
            break;
            case 9:
            weaponDuration = 3f;
            weaponDamage *= 6;
            scaleChange.x *= 1.5f;
            scaleChange.y *= 1.5f;
            break;
            case 10:
            weaponDuration = 3.5f;
            weaponDamage *= 6;
            scaleChange.x *= 1.5f;
            scaleChange.y *= 1.5f;
            break;
            case >10:
            weaponDuration = 4f;
            weaponDamage *= 8;
            scaleChange.x *= 1.6f;
            scaleChange.y *= 1.6f;
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
        transform.Translate(-horizontalInput * Time.deltaTime * messiVelocity, 0, 0, Space.World);

        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(0, -verticalInput * Time.deltaTime * messiVelocity, 0, Space.World);
    }
}
