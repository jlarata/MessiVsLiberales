
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnManager : MonoBehaviour
{
    

    public GameObject gameController;
    public GameController GameController;

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
    public int totalEnemiesCount;

    [SerializeField]
    private bool isSpawning;
    
    void Start()
    {
        spawnRangeY = 4f;
        spawnRangeX = 7f;
        //el objeto
        gameController = GameObject.Find("Game Controller");
        //el script
        GameController = gameController.GetComponent<GameController>();
        
        
    }

    void Update()
    {
        if (totalEnemiesCount <= 80 && isSpawning == false)
        {
            //isSpawning = true;
            StartCoroutine(SpawnEnemies());
            //isSpawning = false;
        }

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


    IEnumerator SpawnEnemies()
    {
        //old method for counting total enemies in screen before spawning more.
        //initializer equals totalEnemiesCount, the for loop stops when totalEnemies reaches 20.
        //for(int i = totalEnemiesCount; totalEnemiesCount < 20; i++)
        //{
            isSpawning = true;
            yield return new WaitForSeconds(0.5f);

            //this should be the ENCAPSULATION getter method.
            switch(GameController.wave)
            {
                //wave lower than 10, that's 4 minutes aprox.
                case <10:
                SpawnEnemy01();
                break;
            }
            isSpawning = false;
            
            
            
            
        //}
    }


    //ABSTRACTION the SpawnEnemy01 Functions calls two functions, each one creating a coordinate
    // those coordinates are random but limited: one on top or bottom (randomly) and the other left or right (also randomly)
    // of the screen. then SpawnEnemy01 will spawn 2 enemies, (one horizontally and other vertically) out of
    // the screen. 

     void SpawnEnemy01()

    {

            GenerateVerticalSpawnPosition();
            GenerateHorizontalSpawnPosition();

            
            //enemy01.GetComponent<Enem01BasicLiberal>().speed = 4;
            Instantiate(enemy01, verticalRandomPos, enemy01.transform.rotation);
            totalEnemiesCount++;
            Instantiate(enemy01, horizontalRandomPos, enemy01.transform.rotation);
            totalEnemiesCount++;

    }


}
