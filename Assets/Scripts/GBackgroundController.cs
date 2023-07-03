using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GBackgroundController : MonoBehaviour
{
    
    public GameObject messi;
    
    public float messiVelocity;

    protected float horizontalInput;
    protected float verticalInput;
    
    void Start()
    {
        messi = GameObject.Find("Messi");
        
/*      One of the problems was the order of execution of scripts. I couldn't make it so GBackController's 
        Start() executes after messicontroller's Start(). because of that, this script can bind the 
        gameobject but not the variable "speed" that uses in messivelocity. Enemies dont have this problem
        because they are instantiated (that is: after the original scripts execution)
 */

        StartCoroutine(IniciateMessiVelocity());   
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(-horizontalInput * Time.deltaTime * messiVelocity, 0, 0);

        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(0, 0, -verticalInput * Time.deltaTime * messiVelocity);
    }

    public IEnumerator IniciateMessiVelocity()
    {
            yield return new WaitForSecondsRealtime(0.01f);
            SetMessiVelocity();
    }

    public void SetMessiVelocity()
    {
        messiVelocity = messi.GetComponent<MessiController>().speed;
    }
}
