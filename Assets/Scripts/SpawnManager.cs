
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnManager : MonoBehaviour
{
    public GameObject gameController;
    public GameController GameController;
    public GameObject[] enemiesList;
    //public GameObject powerup; <-- qué sería esto? un reminder?
    [SerializeField]
    private float spawnRangeY = 5f;
    [SerializeField]
    private float spawnRangeX = 7f;
    [SerializeField]
    private float spawnPosX;
    [SerializeField]
    private float spawnPosY;
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
        if (totalEnemiesCount <= 140 && isSpawning == false)
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
            isSpawning = true;
            yield return new WaitForSeconds(0.5f);

            //this should be the ENCAPSULATION getter method. <- qué demonios quise decir?
            switch(GameController.wave)
            {
                //wave lower than 10, that's 4 minutes aprox.
                case <2:
                SpawnEnemy01();
                break;
                case 2:
                SpawnEnemy0102();
                break;
                case 3:
                SpawnEnemy0102();
                break;
                case 4:
                SpawnEnemy02();
                break;
                case 5:
                SpawnEnemy02();
                break;
                case 6:
                SpawnEnemy0203();
                break;
                case 7:
                SpawnEnemy0203();
                break;
                case 8:
                SpawnEnemy03();
                break;
                case 9:
                SpawnEnemy03();
                break;
                case 10:
                SpawnEnemy0304();
                break;
                case 11:
                SpawnEnemy0304();
                break;
                case 12:
                SpawnEnemy04();
                break;
                case 13:
                SpawnEnemy04();
                break;
            }
            isSpawning = false;
    }
    
    // SpawnEnemy01() calls another two methods, each one creating a coordinate
    // those coordinates are random but limited: one on top or bottom (randomly) and the other left or right (also randomly)
    // of the screen. then SpawnEnemy01() will spawn 2 enemies, (one horizontally and other vertically) out of
    // the screen. 

     void SpawnEnemy01()
    {
            GenerateVerticalSpawnPosition();
            GenerateHorizontalSpawnPosition();

            Instantiate(enemiesList[0], verticalRandomPos, enemiesList[0].transform.rotation);
            totalEnemiesCount++;
            Instantiate(enemiesList[0], horizontalRandomPos, enemiesList[0].transform.rotation);
            totalEnemiesCount++;
    }

    void SpawnEnemy0102()

    {
            GenerateVerticalSpawnPosition();
            GenerateHorizontalSpawnPosition();

            Instantiate(enemiesList[0], verticalRandomPos, enemiesList[0].transform.rotation);
            totalEnemiesCount++;
            Instantiate(enemiesList[1], horizontalRandomPos, enemiesList[0].transform.rotation);
            totalEnemiesCount++;
    }


    void SpawnEnemy02()
    {
            GenerateVerticalSpawnPosition();
            GenerateHorizontalSpawnPosition();
            
            Instantiate(enemiesList[1], verticalRandomPos, enemiesList[1].transform.rotation);
            totalEnemiesCount++;
            Instantiate(enemiesList[1], horizontalRandomPos, enemiesList[1].transform.rotation);
            totalEnemiesCount++;
    }

    void SpawnEnemy0203()
    {
            GenerateVerticalSpawnPosition();
            GenerateHorizontalSpawnPosition();

            Instantiate(enemiesList[1], verticalRandomPos, enemiesList[0].transform.rotation);
            totalEnemiesCount++;
            Instantiate(enemiesList[2], horizontalRandomPos, enemiesList[0].transform.rotation);
            totalEnemiesCount++;
    }

    void SpawnEnemy03()
    {
            GenerateVerticalSpawnPosition();
            GenerateHorizontalSpawnPosition();       
            Instantiate(enemiesList[2], verticalRandomPos, enemiesList[1].transform.rotation);
            totalEnemiesCount++;
            Instantiate(enemiesList[2], horizontalRandomPos, enemiesList[1].transform.rotation);
            totalEnemiesCount++;
    }

    void SpawnEnemy0304()
    {
            GenerateVerticalSpawnPosition();
            GenerateHorizontalSpawnPosition();

            Instantiate(enemiesList[2], verticalRandomPos, enemiesList[0].transform.rotation);
            totalEnemiesCount++;
            Instantiate(enemiesList[3], horizontalRandomPos, enemiesList[0].transform.rotation);
            totalEnemiesCount++;
    }

    void SpawnEnemy04()
    {
            GenerateVerticalSpawnPosition();
            GenerateHorizontalSpawnPosition();       
            Instantiate(enemiesList[3], verticalRandomPos, enemiesList[1].transform.rotation);
            totalEnemiesCount++;
            Instantiate(enemiesList[3], horizontalRandomPos, enemiesList[1].transform.rotation);
            totalEnemiesCount++;
    }
}
