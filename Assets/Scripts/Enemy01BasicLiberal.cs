using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy01BasicLiberal : EnemyController
{
    void Start()
    {
        //all this variables needs to be inicializated in the child classes.
        spawnManager = GameObject.Find("SpawnManager");
        //el objeto:
        gameController = GameObject.Find("Game Controller");
        //el script:
        GameController = gameController.GetComponent<GameController>();
        

        messi = GameObject.Find("Messi");
        MessiController = messi.GetComponent<MessiController>();
        
        messiVelocity = MessiController.speed; 

        enemyRb2D = GetComponent<Rigidbody2D>();

        baseSpeed = 0.5f;
        baseEnemyDamage = 1f;
        baseEnemyExp = 1f;
        baseEnemyHp =1f;

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
            //second wave (from 10 to 14)
            if (wave > 13)
            {
                enemyDamage = baseEnemyDamage*(Mathf.Pow(expNumber, 10));
                GetComponent<DetectCollisions>().thisEnemyDamage = enemyDamage;
                enemyExp = baseEnemyExp*(Mathf.Pow(expNumber, 10));
                enemyHp = baseEnemyHp*(Mathf.Pow(expNumber, 10));
                speed = baseSpeed;
            } else if (wave > 11)
            {
                enemyDamage = baseEnemyDamage*(Mathf.Pow(expNumber, 9));
                GetComponent<DetectCollisions>().thisEnemyDamage = enemyDamage;
                enemyExp = baseEnemyExp*(Mathf.Pow(expNumber, 9));
                enemyHp = baseEnemyHp*(Mathf.Pow(expNumber, 9));
                speed = baseSpeed;
            } else if (wave > 9)
            {
                enemyDamage = baseEnemyDamage*(Mathf.Pow(expNumber, 8));
                GetComponent<DetectCollisions>().thisEnemyDamage = enemyDamage;
                enemyExp = baseEnemyExp*(Mathf.Pow(expNumber, 8));
                enemyHp = baseEnemyHp*(Mathf.Pow(expNumber, 8));
                speed = baseSpeed;
            }

            // first wave (from 0 to 4)
            else if (wave > 2)
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
            } else if (wave > 0)
            {
                enemyDamage = baseEnemyDamage;
                GetComponent<DetectCollisions>().thisEnemyDamage = enemyDamage;
                enemyExp = baseEnemyExp;
                enemyHp = baseEnemyHp;
                speed = baseSpeed;
            } else if (wave == 0)
            {
                enemyDamage = baseEnemyDamage;
                GetComponent<DetectCollisions>().thisEnemyDamage = enemyDamage;
                enemyExp = baseEnemyExp;
                enemyHp = baseEnemyHp;
                speed = baseSpeed;
            }
    }           
}