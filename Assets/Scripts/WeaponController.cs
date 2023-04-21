using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    //como uso vector3.forward, la direccion va a ser relativa al gameobject que tenga el scrtip. nice.
    public float speed = 400.0f;
    public float weaponDamage;
    public GameObject messi;
    public bool left;
    
    // Start is called before the first frame update
    void Start()
    {
        messi = GameObject.Find("Messi");
        
        switch(messi.GetComponent<MessiController>().virtualRotation.GetComponent<VirtualRotation>().hFacing)
        {
            case 3:
            left = false;
            break;

            case 9:
            left = true;
            break;
        }
        StartCoroutine(Duration());
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }
     
    IEnumerator Duration()
    {
        
        yield return new WaitForSeconds(.3f);
        Autodestroy();
    }

    public void Autodestroy()
    {
        Destroy(gameObject);
    }

    public void Fire()
    {
        //todos estos métodos tendrían que estar en un script class específico de esta arma, 
        //que herede del script padre WeaponController que solo tendría un método Fire vacío, o overrideable
        switch(left)
        {
            case true:
            transform.RotateAround(messi.transform.position, Vector3.forward, speed * Time.deltaTime);
            transform.Rotate(new Vector3(0, 0, -1) * 4*speed * Time.deltaTime);
            break;

            case false:
            transform.RotateAround(messi.transform.position, Vector3.back, speed * Time.deltaTime);
            transform.Rotate(new Vector3(0, 0, 1) * 4*speed * Time.deltaTime);
            break;
        
        // método directo, lineal.
        // transform.Translate(Vector3.down * Time.deltaTime * speed);
        
        }
    }

    
     }