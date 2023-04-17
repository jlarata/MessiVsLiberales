
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnManager : MonoBehaviour
{
    public GameObject enemy01;
    //public GameObject powerup;
    [SerializeField]
    private float spawnRangeY = 3;
    [SerializeField]
    private float spawnRangeX = 7;

    [SerializeField]
    float spawnPosX;
    [SerializeField]
    float spawnPosY;

    [SerializeField]
    private Vector3 verticalRandomPos;

    [SerializeField]
    private int leftOrRight;
    //public int enemy01Count;
    //public int round = 0;
    //public bool stap = false;

    // Start is called before the first frame update
    void Start()
    {
        
        SpawnEnemy01();
        
//        GenerateSpawnPosition();
    }

    // Update is called once per frame
    void Update()
    {
//        {
//            SpawnHolandaWave(ronda);
//            ronda +=1;
//            if (ronda%2 == 0)
//            {
//                SpawnPowerup();
//            }
//        }
        
    }

//generates random vertical spawns either left or right of screen

    private Vector3 GenerateVerticalSpawnPosition()
    {
        leftOrRight = Random.Range(1, 3);

        if (leftOrRight == 1)
        {
            spawnPosX = -spawnRangeX;
            spawnPosY = Random.Range(-spawnRangeY, spawnRangeY);
            verticalRandomPos = new Vector3(spawnPosX, spawnPosY, -2.02f);
        } 
        if (leftOrRight == 2)
        {
            spawnPosX = spawnRangeX;
            spawnPosY = Random.Range(-spawnRangeY, spawnRangeY);
            verticalRandomPos = new Vector3(spawnPosX, spawnPosY, -2.02f);
        }

        return verticalRandomPos;
    }

// FALTA hacer el horizontal
// Y meter un método con delay que repita el spawn.

//cambiar los if del método de generacion vertical con un switch - case? ya deberia ser más facil porque resolví el problema que era otro (volvía a meter los tipos en el método que ya estaban definidos antes)


    void SpawnEnemy01()
//    void SpawnEnemy01(int enemies01ToSpawn)
    {
//        for (int i = 0; i < enemies01ToSpawn; i++)
//        
            GenerateVerticalSpawnPosition();
            Instantiate(enemy01, verticalRandomPos, enemy01.transform.rotation);
//        }
    }

    //void SpawnPowerup()
    //{
    //    
    //        Instantiate(powerup, GenerateSpawnPosition(), powerup.transform.rotation);
    //}
}
