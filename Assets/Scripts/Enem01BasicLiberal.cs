using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enem01BasicLiberal : EnemyController
{
    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GameObject.Find("SpawnManager");
        enemyDamage = 0.5f;
        enemyHp = 1;
        speed = 0.5f;
        //enemyCC2D = GetComponent<CircleCollider2D>();
        enemyRb2D = GetComponent<Rigidbody2D>();
        
        messi = GameObject.Find("Messi");  
        messiVelocity = 2.0f;  
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
