using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// INHERITANCE this class is to be parent of all enemies child class.
public class EnemyController : MonoBehaviour
{
    
    //[SerializeField]
    //private CircleCollider2D enemyCC2D;
    [SerializeField]
    protected Rigidbody2D enemyRb2D;

    //base variables to multiply
    public float baseSpeed;
    public float baseEnemyDamage;
    public float baseEnemyExp;
    public float baseEnemyHp;


    //the variables to change on wave
    public float speed;
    public float enemyDamage;
    public float enemyExp;
    public float enemyHp;

   //a list of drops to be used
    public GameObject[] dropList; 
    public int dropRandomNumber;

    //the exponential number (just an arbitrary number)
    public float expNumber;

    [SerializeField]
    protected GameObject messi;
    [SerializeField]
    protected MessiController MessiController;


    [SerializeField]
    protected GameObject spawnManager;

    [SerializeField]
    protected GameObject gameController;
    [SerializeField]
    protected GameController GameController;
    [SerializeField]
    protected int wave;

    [SerializeField]
    protected Color enemyColor;


    public float messiVelocity;

    protected float horizontalInput;
    protected float verticalInput;


    void Start()
    {
        //remember: all this variables needs to be ALSO inicializated in the child classes.
        spawnManager = GameObject.Find("SpawnManager");
        //el objeto:
        gameController = GameObject.Find("GameController");
        //el script:
        GameController = gameController.GetComponent<GameController>();
        wave = GameController.wave;

        enemyRb2D = GetComponent<Rigidbody2D>();

        messi = GameObject.Find("Messi");
        MessiController = messi.GetComponent<MessiController>();
        /*messiVelocity = MessiController.speed; */

        
    

        enemyColor = GetComponent<SpriteRenderer>().color;
        enemyColor.a = 1.0f;
        GetComponent<SpriteRenderer>().color = enemyColor;

        speed = 0.5f;
        //enemyCC2D = GetComponent<CircleCollider2D>();
        
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //old method, using AddForce (physics)
        //Vector3 lookDirection = (messi.transform.position - transform.position).normalized;
        //enemyRb2D.AddForce(lookDirection * speed);


        //new method, using transform position with a Vector3.MoveTowards (so enemies dont push too much eachother)
        transform.position = Vector3.MoveTowards(transform.position, messi.transform.position, Time.deltaTime * speed);


        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(-horizontalInput * Time.deltaTime * messiVelocity, 0, 0);

        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(0, -verticalInput * Time.deltaTime * messiVelocity, 0);
    }

    public void normalDrop()
    {   
        //this conditional prevents errors in case of having an enemy without elemnts in the array dropList.
        if (!(dropList.Length == 0))
        {
            dropRandomNumber = Random.Range(1, 100);
            if (dropRandomNumber >89)
            {
                Instantiate(dropList[1], transform.position, transform.rotation * Quaternion.Euler (0, 0, 90));
            }
            else if (dropRandomNumber >49)
            {
                Instantiate(dropList[0], transform.position, transform.rotation * Quaternion.Euler (0, 0, 90));
            }
            
        }
        
        
    }

    //POLYMORPHISM i have no use for this at this point, so i've imagined one
    // if i would create an "armor" for the enemies, i could implement this method overriding it
    // so it could LoseHp with a modification (-armor). 
    // another possibility: splash damage when damaged. 

    public virtual void loseHp(float weaponDamage)
    {
        enemyHp -= weaponDamage;

        if (enemyHp <= 0)
        {
            normalDrop();
            Destroy(gameObject);
            spawnManager.GetComponent<SpawnManager>().totalEnemiesCount--;
            gameController.GetComponent<GameController>().ExpUp(enemyExp);
        }
    }

    public void HitAnimationF()
    {
        StartCoroutine(HitAnimation());
    }

    public IEnumerator HitAnimation()
        {
            enemyColor.a = 0.5f;
            GetComponent<SpriteRenderer>().color = new Color (255f, 255f, 255f, enemyColor.a);
            yield return new WaitForSecondsRealtime(0.01f); 
            enemyColor.a = 1f;
            GetComponent<SpriteRenderer>().color = new Color (255f, 255f, 255f, enemyColor.a);
            enemyColor.a = 0.5f;
            GetComponent<SpriteRenderer>().color = new Color (255f, 255f, 255f, enemyColor.a);
            yield return new WaitForSecondsRealtime(0.01f); 
            enemyColor.a = 1f;
            GetComponent<SpriteRenderer>().color = new Color (255f, 255f, 255f, enemyColor.a);
            
        }
    

    //why do i have this function for? maybe copied from spawnManager without noticing it.
    public void Autodestroy()
    {
        Destroy(gameObject);
    }
}
