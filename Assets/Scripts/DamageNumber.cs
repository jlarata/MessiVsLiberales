using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DamageNumber : MonoBehaviour
{
    public float messiVelocity;
    protected float horizontalInput;
    protected float verticalInput;

    [SerializeField]
    protected TMP_Text damageNumber;
    
    [SerializeField]
    protected Color damageNumberColor;


    void Start()
    {

        

        messiVelocity = 1.0f;
        StartCoroutine(Duration());
        damageNumber = this.gameObject.transform.GetChild(0).GetComponent<TMP_Text>();

        damageNumberColor = damageNumber.color;

        //damageNumber.text = damage;
    }
    

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(-horizontalInput * Time.deltaTime * messiVelocity, 0, 0, Space.World);

        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(0, -verticalInput * Time.deltaTime * messiVelocity, 0, Space.World);

        transform.Translate(0, 0.3f * Time.deltaTime, 0, Space.World);

        damageNumberColor.a = damageNumberColor.a - 0.01f;
        damageNumber.color = damageNumberColor;
    }

    IEnumerator Duration()
    {
        
        yield return new WaitForSeconds(1.3f);
        Autodestroy();
    }

    public void Autodestroy()
    {
        Destroy(gameObject);
    }
}
