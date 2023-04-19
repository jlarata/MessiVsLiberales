using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    public float speed = 3.0f;
    [SerializeField]
    private CircleCollider2D enemyCC2D;
    [SerializeField]
    private Rigidbody2D enemyRb2D;
    [SerializeField]
    private GameObject messi;

    // Start is called before the first frame update
    void Start()
    {

        enemyCC2D = GetComponent<CircleCollider2D>();
        enemyRb2D = GetComponent<Rigidbody2D>();
        
        messi = GameObject.Find("Messi");    
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (messi.transform.position - transform.position).normalized;

        enemyRb2D.AddForce(lookDirection * speed);

    }
}
