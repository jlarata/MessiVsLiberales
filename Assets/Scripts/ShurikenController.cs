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
        shurikenLvl = messi.GetComponent<MessiController>().shurikenLvl;

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

        scaleChange = transform.localScale;
        switch(shurikenLvl)
        {
            case 1:
            scaleChange.x *= 0.5f;
            scaleChange.y *= 0.5f;
            break;
            case 2:
            scaleChange.x *= 0.7f;
            scaleChange.y *= 0.7f;
            break;
            case 3:
            weaponDamage *= 2f;
            scaleChange.x *= 0.7f;
            scaleChange.y *= 0.7f;
            break;
            case 4:
            weaponDamage *= 2f;
            scaleChange.x *= 0.9f;
            scaleChange.y *= 0.9f;
            break;
            case 5:
            weaponDamage *= 4f;
            scaleChange.x *= 0.9f;
            scaleChange.y *= 0.9f;
            break;
            case 6:
            weaponDamage *= 4f;
            scaleChange.x *= 1.2f;
            scaleChange.y *= 1.2f;
            break;
            case 7:
            weaponDuration = 0.5f;
            weaponDamage *= 4f;
            scaleChange.x *= 1.2f;
            scaleChange.y *= 1.2f;
            break;
            case 8:
            weaponDuration = 0.5f;
            weaponDamage *= 6f;
            scaleChange.x *= 1.2f;
            scaleChange.y *= 1.2f;
            break;
            case 9:
            weaponDuration = 0.5f;
            weaponDamage *= 6f;
            scaleChange.x *= 1.4f;
            scaleChange.y *= 1.4f;
            break;
            case 10:
            weaponDuration = 0.6f;
            weaponDamage *= 7f;
            scaleChange.x *= 1.5f;
            scaleChange.y *= 1.5f;
            break;
            case > 10:
            weaponDuration = 0.7f;
            weaponDamage *= 7.5f;
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
