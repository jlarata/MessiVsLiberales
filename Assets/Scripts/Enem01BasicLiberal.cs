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





        wave = GameController.Wave;

        enemyDamage = 1f;
        enemyExp = 1.0f;
        enemyHp = 1;
        speed = 0.5f;
        //enemyCC2D = GetComponent<CircleCollider2D>();
        
        
          
        messiVelocity = 2.0f;  
        UpdateToWave();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateToWave()
    {
        switch(wave)
        {
        case (<1):
        enemyDamage = 1f;
        enemyExp = 1.0f;
        enemyHp = 1;
        speed = 0.5f;
        break;
        
        case >1:
        if (wave <4)
        {
            enemyDamage = 4f;
            enemyExp = 4.0f;
            enemyHp = 4;
            speed = 0.6f;
        }
        break;
        }
    }

    

}
