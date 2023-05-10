using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// INHERITANCE this class is to be parent of all enemies child class.
public class EnemyController : MonoBehaviour
{
    [SerializeField]
    public float speed;
    //[SerializeField]
    //private CircleCollider2D enemyCC2D;
    [SerializeField]
    protected Rigidbody2D enemyRb2D;
    
    public float enemyDamage;
    public float enemyExp;

    [SerializeField]
    protected float enemyHp;

    [SerializeField]
    protected GameObject messi;
    
    [SerializeField]
    protected GameObject spawnManager;

    [SerializeField]
    protected GameObject gameController;
    [SerializeField]
    protected GameController GameController;

    [SerializeField]
    protected Color enemyColor;

    [SerializeField]
    protected int wave;


    public float messiVelocity;

    protected float horizontalInput;
    protected float verticalInput;


    void Start()
    {
        //remember: all this variables needs to be inicializated in the child classes.
        spawnManager = GameObject.Find("SpawnManager");
        //el objeto:
        gameController = GameObject.Find("GameController");
        //el script:
        GameController = gameController.GetComponent<GameController>();
        
        enemyRb2D = GetComponent<Rigidbody2D>();

        messi = GameObject.Find("Messi");  

        enemyColor = GetComponent<SpriteRenderer>().color;
        enemyColor.a = 1.0f;
        GetComponent<SpriteRenderer>().color = enemyColor;

        speed = 0.5f;
        //enemyCC2D = GetComponent<CircleCollider2D>();
        
        
        messiVelocity = 2.0f;  
        
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
        transform.Translate(-horizontalInput * Time.deltaTime * speed * messiVelocity, 0, 0);

        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(0, -verticalInput * Time.deltaTime * speed * messiVelocity, 0);

        if (enemyHp <= 0)
        {
            Destroy(gameObject);
            spawnManager.GetComponent<SpawnManager>().totalEnemiesCount--;
            gameController.GetComponent<GameController>().ExpUp(enemyExp);
        }
    }

    //POLYMORPHISM i have no use for this at this point, so i've imagined one
    // if i would create an "armor" for the enemies, i could implement this method overriding it
    // so it could LoseHp with a modification (-armor). 
    // another possibility: splash damage when damaged. 

    public virtual void loseHp(float weaponDamage)
    {
        enemyHp -= weaponDamage;
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
