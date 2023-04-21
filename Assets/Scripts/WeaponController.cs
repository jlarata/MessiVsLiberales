using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    //como uso vector3.forward, la direccion va a ser relativa al gameobject que tenga el scrtip. nice.
    public float speed = 30.0f;
    public float weaponDamage;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Duration());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);
        
    }
     
    IEnumerator Duration()
    {
        yield return new WaitForSeconds(0.04f);
        Autodestroy();
    }

    public void Autodestroy()
    {
        Destroy(gameObject);
    }

    
     }
