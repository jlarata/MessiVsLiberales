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
        weaponDuration = 3f;
        xRange = 4.7f;
        yRange = 2.5f;

        diMariaLvl = messi.GetComponent<MessiController>().diMariaLvl;
        setNewDirection();
        
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
        transform.Translate(-horizontalInput * Time.deltaTime * speed * messiVelocity, 0, 0, Space.World);

        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(0, -verticalInput * Time.deltaTime * speed * messiVelocity, 0, Space.World);
        }
        
        

        
    

}
