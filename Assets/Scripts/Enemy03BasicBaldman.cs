using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy03BasicBaldman : EnemyController
{
    // INHERITANCE. this class inherits from script EnemyController.cs
    void Start()
    {
        spawnManager = GameObject.Find("SpawnManager");
        gameController = GameObject.Find("Game Controller");
        GameController = gameController.GetComponent<GameController>();
        
        messi = GameObject.Find("Messi");
        MessiController = messi.GetComponent<MessiController>();
        
        messiVelocity = MessiController.speed; 

        enemyRb2D = GetComponent<Rigidbody2D>();

        baseSpeed = 0.5f;
        baseEnemyDamage = 3f;
        baseEnemyExp = 3f;
        baseEnemyHp = 3f;

        expNumber = 1.5f;



        wave = GameController.wave;

        //enemyCC2D = GetComponent<CircleCollider2D>();
        
        UpdateToWave();
        
    }

    void Update()
    {
        
    }

    void UpdateToWave()
    {
        if (wave > 9)
            {
                enemyDamage = baseEnemyDamage*(Mathf.Pow(expNumber, 2));
                GetComponent<DetectCollisions>().thisEnemyDamage = enemyDamage;
                enemyExp = baseEnemyExp*(Mathf.Pow(expNumber, 2));
                enemyHp = baseEnemyHp*(Mathf.Pow(expNumber, 2));
                speed = baseSpeed;
            } else if (wave > 7)
            {
                enemyDamage = baseEnemyDamage*expNumber;
                GetComponent<DetectCollisions>().thisEnemyDamage = enemyDamage;
                enemyExp = baseEnemyExp*expNumber;
                enemyHp = baseEnemyHp*expNumber;
                speed = baseSpeed;
            } else if (wave > 5)
            {
                enemyDamage = baseEnemyDamage;
                GetComponent<DetectCollisions>().thisEnemyDamage = enemyDamage;
                enemyExp = baseEnemyExp;
                enemyHp = baseEnemyHp;
                speed = baseSpeed;
            }
    }           
}