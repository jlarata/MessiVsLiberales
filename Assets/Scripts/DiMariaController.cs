using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiMariaController : WeaponController
{
    public float xRandomDirection;
    public float yRandomDirection;
    public Vector3 randomDirection;

    public float xRange;
    public float yRange;

    // Start is called before the first frame update
    void Start()
    {
        speed = 1.5f;
        messi = GameObject.Find("Messi");
        totalMovementFacing = messi.GetComponent<MessiController>().virtualRotation.GetComponent<VirtualRotation>().totalMovementFacing;


        weaponDamage = 1.0f;
        
        xRange = 4.7f;
        yRange = 2.5f;

        diMariaLvl = messi.GetComponent<MessiController>().diMariaLvl;
        setNewDirection();
        

        scaleChange = transform.localScale;
        switch(diMariaLvl)
        {
            case 1:
            weaponDuration = 1f;
            scaleChange.x *= 0.7f;
            scaleChange.y *= 0.7f;
            break;
            case 2:
            weaponDuration = 1f;
            scaleChange.x *= 0.9f;
            scaleChange.y *= 0.9f;
            break;
            case 3:
            weaponDuration = 1f;
            weaponDamage *= 2f;
            scaleChange.x *= 0.9f;
            scaleChange.y *= 0.9f;
            break;
            case 4:
            weaponDuration = 1f;
            weaponDamage *= 2f;
            scaleChange.x *= 1.1f;
            scaleChange.y *= 1.1f;
            break;
            case 5:
            weaponDuration = 1.5f;
            weaponDamage *= 2f;
            scaleChange.x *= 1.1f;
            scaleChange.y *= 1.1f;
            break;
            case 6:
            weaponDuration = 1.5f;
            weaponDamage *= 2f;
            scaleChange.x *= 1.3f;
            scaleChange.y *= 1.3f;
            break;
            case 7:
            weaponDuration = 1.5f;
            weaponDamage *= 2f;
            scaleChange.x *= 1.5f;
            scaleChange.y *= 1.5f;
            break;
            case 8:
            weaponDuration = 2f;
            weaponDamage *= 2f;
            scaleChange.x *= 1.5f;
            scaleChange.y *= 1.5f;
            break;
            case 9:
            weaponDuration = 2f;
            weaponDamage *= 3f;
            scaleChange.x *= 1.5f;
            scaleChange.y *= 1.5f;
            break;
            case 10:
            weaponDuration = 2.5f;
            weaponDamage *= 3f;
            scaleChange.x *= 1.7f;
            scaleChange.y *= 1.7f;
            break;
            case >10:
            weaponDuration = 2.5f;
            weaponDamage *= 3f;
            scaleChange.x *= 1.7f;
            scaleChange.y *= 1.7f;
            break;

        }
        transform.localScale = scaleChange;

    }

    // Update is called once per frame
    void Update()
    {
        WeaponBehaviour();
    }

    void setNewDirection()
    {
        xRandomDirection = Random.Range(-1f, 1f);
        yRandomDirection = Random.Range(-1f, 1f);
        randomDirection.x = xRandomDirection;
        randomDirection.y = yRandomDirection;
        randomDirection.z = 0f;
    }

    

    new public void Autodestroy()
    {
        Destroy(gameObject);
    }

    new public void WeaponBehaviour()
    {
        transform.Translate(randomDirection * Time.deltaTime * speed, Space.World);

        if (transform.position.x > xRange || transform.position.x < -xRange)
        {
            setNewDirection();
        }

        if (transform.position.y < -yRange || transform.position.y > yRange)
        {
            setNewDirection();
        }
        
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(-horizontalInput * Time.deltaTime * messiVelocity, 0, 0, Space.World);

        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(0, -verticalInput * Time.deltaTime * messiVelocity, 0, Space.World);
    }

    
        
        

        
    

}
