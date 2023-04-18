
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnManager : MonoBehaviour
{
    public GameObject enemy01;
    //public GameObject powerup;
    [SerializeField]
    private float spawnRangeY = 5f;
    [SerializeField]
    private float spawnRangeX = 7f;

    [SerializeField]
    float spawnPosX;
    [SerializeField]
    float spawnPosY;

    [SerializeField]
    private Vector3 verticalRandomPos;

    [SerializeField]
    private Vector3 horizontalRandomPos;

    [SerializeField]
    private int leftOrRight;

    [SerializeField]
    private int upOrDown;

    [SerializeField]
    int totalEnemiesCount;
    
    //public int enemy01Count;
    //public int round = 0;
    //public bool stap = false;

    // Start is called before the first frame update
    void Start()
    {
        spawnRangeY = 4f;
        spawnRangeX = 7f;

        
        StartCoroutine(SpawnEnemies());
        
        
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

//generates vertical random position either left or right of screen. to be used by spawner

    private Vector3 GenerateVerticalSpawnPosition()
    {
        leftOrRight = Random.Range(1, 3);
        switch(leftOrRight)
        {
            case 1:
            spawnPosX = -spawnRangeX;
            spawnPosY = Random.Range(-spawnRangeY, spawnRangeY);
            verticalRandomPos = new Vector3(spawnPosX, spawnPosY, -2.02f);
            break;
            case 2:
            spawnPosX = spawnRangeX;
            spawnPosY = Random.Range(-spawnRangeY, spawnRangeY);
            verticalRandomPos = new Vector3(spawnPosX, spawnPosY, -2.02f);
            break;
        }

        return verticalRandomPos;
    }


//generates horizontal random position either top or botton of screen. to be used by spawner

private Vector3 GenerateHorizontalSpawnPosition()
    {
        upOrDown = Random.Range(1, 3);
        switch(upOrDown)
        {
            case 1:
            spawnPosX = Random.Range(-spawnPosX, spawnPosX);
            spawnPosY = -spawnRangeY;
            horizontalRandomPos =  new Vector3(spawnPosX, spawnPosY, -2.02f);
            break;

            case 2:
            spawnPosX = Random.Range(-spawnPosX, spawnPosX);
            spawnPosY = spawnRangeY;
            horizontalRandomPos =  new Vector3(spawnPosX, spawnPosY, -2.02f);
            break;
        }

        return horizontalRandomPos;
    }
//FALTA
// Y meter un método con delay que repita el spawn.



    IEnumerator SpawnEnemies()
    {
        //initializer equals totalEnemiesCount, the for loop stops when totalEnemies reaches 20.
        for(int i = totalEnemiesCount; totalEnemiesCount < 20; i++)
        {
            SpawnEnemy01();
            yield return new WaitForSeconds(1);
        }
    }

     void SpawnEnemy01()
     //im saving this old methods because they could be useful if i want multiple enemies to spam at once.
//    void SpawnEnemy01(int enemies01ToSpawn)
    {
//        for (int i = 0; i < enemies01ToSpawn; i++)
//        
            //every loop will generate two vector3 and two enemies, one vertical and one horizontal.
            GenerateVerticalSpawnPosition();
            GenerateHorizontalSpawnPosition();

            Instantiate(enemy01, verticalRandomPos, enemy01.transform.rotation);
            totalEnemiesCount++;
            Instantiate(enemy01, horizontalRandomPos, enemy01.transform.rotation);
            totalEnemiesCount++;
//        }
    }





    //void SpawnPowerup()
    //{
    //    
    //        Instantiate(powerup, GenerateSpawnPosition(), powerup.transform.rotation);
    //}
}
