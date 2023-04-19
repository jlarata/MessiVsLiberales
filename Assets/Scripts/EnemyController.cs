using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    public float speed;
    //[SerializeField]
    //private CircleCollider2D enemyCC2D;
    [SerializeField]
    private Rigidbody2D enemyRb2D;
    [SerializeField]
    private GameObject messi;

    private float horizontalInput;
    private float verticalInput;


    // Start is called before the first frame update
    void Start()
    {

        speed = 0.2f;
        //enemyCC2D = GetComponent<CircleCollider2D>();
        enemyRb2D = GetComponent<Rigidbody2D>();
        
        messi = GameObject.Find("Messi");    
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //old method, using AddForce (physics)
        //Vector3 lookDirection = (messi.transform.position - transform.position).normalized;
        //enemyRb2D.AddForce(lookDirection * speed);


        //new method, using transform position with a Vector3.Lerp (so enemies dont push too much eachother)
        transform.position = Vector3.Lerp(transform.position, messi.transform.position, Time.deltaTime * speed);


        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(-horizontalInput * Time.deltaTime * speed * 1.5f, 0, 0);

        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(0, -verticalInput * Time.deltaTime * speed * 1.5f, 0);


    }
}
