using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enem01BasicLiberal : EnemyController
{
    // INHERITANCE. this class inherits from script EnemyController.cs
    void Start()
    {
        spawnManager = GameObject.Find("SpawnManager");
        gameController = GameObject.Find("Game Controller");
        GameController = gameController.GetComponent<GameController>();
        
        messi = GameObject.Find("Messi");
        enemyRb2D = GetComponent<Rigidbody2D>();

        baseSpeed = 0.6f;
        baseEnemyDamage = 1f;
        baseEnemyExp = 1f;
        baseEnemyHp =1f;

        expNumber = 1.2f;



        wave = GameController.wave;

        //enemyCC2D = GetComponent<CircleCollider2D>();
        
        
          
        messiVelocity = 2.0f;  
        UpdateToWave();
        
    }

    void Update()
    {
        
    }

    void UpdateToWave()
    {
        if (wave > 2)
            {
                enemyDamage = baseEnemyDamage*(Mathf.Pow(expNumber, 3));
                GetComponent<DetectCollisions>().thisEnemyDamage = enemyDamage;
                enemyExp = baseEnemyExp*(Mathf.Pow(expNumber, 3));
                enemyHp = baseEnemyHp*(Mathf.Pow(expNumber, 3));
                speed = baseSpeed;
            } else if (wave > 1)
            {
                enemyDamage = baseEnemyDamage*expNumber;
                GetComponent<DetectCollisions>().thisEnemyDamage = enemyDamage;
                enemyExp = baseEnemyExp*expNumber;
                enemyHp = baseEnemyHp*expNumber;
                speed = baseSpeed;
            } else if (wave >0)
            {
                enemyDamage = baseEnemyDamage;
                GetComponent<DetectCollisions>().thisEnemyDamage = enemyDamage;
                enemyExp = baseEnemyExp;
                enemyHp = baseEnemyHp;
                speed = baseSpeed;
            }
    }           
}