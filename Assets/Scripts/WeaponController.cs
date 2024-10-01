using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    //como uso vector3.forward, la direccion va a ser relativa al gameobject que tenga el scrtpt. nice.
    public float speed = 400.0f;
    public float rotateSpeed = 1800.0f;
    public float weaponDamage;
    public float weaponDelay;
    public float weaponDuration;
    public Vector3 scaleChange;

    //these variables will be readed from MessiController script, by each weapon.
    // pero ¿es así? diera la impresión de que las lee del Main Manager. salvo que el Main manager las lea de acá 
    public float shurikenLvl;
    public float adukeLvl;
    public float diMariaLvl;
    

    public GameObject messi;
    public MessiController MessiController;

    
    public bool left;
    //varaible not needed anymore? see comment in messicontroller.
    //public int multipleFacing;
    public int totalMovementFacing;
    public float messiVelocity;
    protected float horizontalInput;
    protected float verticalInput;
        
    void Start()
    {
        messi = GameObject.Find("Messi");
        MessiController = messi.GetComponent<MessiController>();
        messiVelocity = MessiController.speed; 
        //multipleFacing = messi.GetComponent<MessiController>().virtualRotation.GetComponent<VirtualRotation>().multipleFacing;
        totalMovementFacing = messi.GetComponent<MessiController>().virtualRotation.GetComponent<VirtualRotation>().totalMovementFacing;
        
        switch(messi.GetComponent<MessiController>().virtualRotation.GetComponent<VirtualRotation>().hFacing)
        {
            case 3:
            left = false;
            break;  

            case 9:
            left = true;
            break;
        }
        StartCoroutine(Duration(10.0f));
    }

    void Update()
    {
        WeaponBehaviour();        
    }

    protected IEnumerator Duration(float time)
    {
        yield return new WaitForSeconds(time);
        Autodestroy();
    }

    
    public void Autodestroy()
    {
        Destroy(gameObject);
    }

    public virtual void WeaponBehaviour()
    {
    }

    
}
