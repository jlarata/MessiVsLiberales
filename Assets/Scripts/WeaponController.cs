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
    public float shurikenLvl;
    public float adukeLvl;
    

    public GameObject messi;
    public bool left;
    public int multipleFacing;

    public float messiVelocity;
    protected float horizontalInput;
    protected float verticalInput;
    
    
    // Start is called before the first frame update
    void Start()
    {
        messi = GameObject.Find("Messi");
        messiVelocity = 2.0f;
        multipleFacing = messi.GetComponent<MessiController>().virtualRotation.GetComponent<VirtualRotation>().multipleFacing;
        
       


        
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

    public void WeaponBehaviour()
    {
        //todos estos métodos tendrían que estar en un script class específico de esta arma, 
        //que herede del script padre WeaponController que solo tendría un método Fire vacío, o overrideable
        // switch(left)
        // {
        //     case true:
        //     transform.RotateAround(messi.transform.position, Vector3.forward, speed * Time.deltaTime);
        //     transform.Rotate(new Vector3(0, 0, -1) * rotateSpeed * Time.deltaTime);
        //     break;

        //     case false:
        //     transform.RotateAround(messi.transform.position, Vector3.back, speed * Time.deltaTime);
        //     transform.Rotate(new Vector3(0, 0, 1) * rotateSpeed * Time.deltaTime);
        //     break;
        
        // // método directo, lineal.
        // // transform.Translate(Vector3.down * Time.deltaTime * speed);
        
        // }
    }

    
     }
