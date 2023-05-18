using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenController : WeaponController
{
    void Start()
    {
        speed = 400.0f;
        rotateSpeed = 1800.0f;

        weaponDuration = 0.3f;

        messi = GameObject.Find("Messi");

        weaponDamage = 1.0f;

        switch(messi.GetComponent<MessiController>().virtualRotation.GetComponent<VirtualRotation>().hFacing)
        {
            case 3:
            left = false;
            break;

            case 9:
            left = true;
            break;
        }
        StartCoroutine(Duration(weaponDuration));
    }

    void Update()
    {
        WeaponBehaviour();
    }

    new public void WeaponBehaviour()
    {
        switch(left)
        {
            case true:
            transform.RotateAround(messi.transform.position, Vector3.forward, speed * Time.deltaTime);
            transform.Rotate(new Vector3(0, 0, -1) * rotateSpeed * Time.deltaTime);
            break;

            case false:
            transform.RotateAround(messi.transform.position, Vector3.back, speed * Time.deltaTime);
            transform.Rotate(new Vector3(0, 0, 1) * rotateSpeed * Time.deltaTime);
            break;
        
        
        }
    }
}
