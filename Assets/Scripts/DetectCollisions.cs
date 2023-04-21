using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{

  //AudioSource source;
  //public GameObject gameObjectQueManejeElAudio;
    public GameObject messi;
    public MessiController messiController;
    [SerializeField]
    private float thisEnemyDamage;

    void Start()
    {
      messi = GameObject.Find("Messi");
      messiController = messi.GetComponent<MessiController>();
      thisEnemyDamage = GetComponent<EnemyController>().enemyDamage;
      //gameObjectQueManejeElAudio = GameObject.Find("GameObjectQueManejeElAudio");
      //source = GetComponent<AudioSource>();
    }


    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Messi")
        {
            messiController.PerderHp(thisEnemyDamage);
        }

        if (other.gameObject.tag == "Weapons")
        {
          GetComponent<EnemyController>().loseHp(other.GetComponent<WeaponController>().weaponDamage);
          //other.GetComponent<WeaponController>
            Debug.Log("colision detectada con "+other.name);
            
            //Destroy(gameObject);
            //other.gameObject.GetComponent<Enem01BasicLiberal>().Autodestroy();
            
        }
        
    }
    
    // void OnTriggerEnter(Collider other) {
      
    //   if (!(other.gameObject.name == "Animal_Moose_02(Clone)"))
    //   {
    //      if (!(this.gameObject.name == "Animal_Moose_02(Clone)")) 

    //     {
    //     if (!(other.gameObject.name == "Messi"))
    //     {
    //       mlemmanager.GetComponent<MlemManager>().Suena();

    //       if (gameObject.GetComponent<AnimalHunger>().currentFedAmount == 0)
    //       {
    //         messi.GetComponent<MessiController>().SumarPerritosAlimentados();
    //       }

    //       if (gameObject.GetComponent<AnimalHunger>().currentFedAmount >=
    //           gameObject.GetComponent<AnimalHunger>().amountToBeFed)
    //           {
    //             gameObject.GetComponent<BoxCollider>().enabled=false;
    //           }
          
    //       //Destroy(gameObject);
    //       Destroy(other.gameObject);
    //       gameObject.GetComponent<AnimalHunger>().FeedAnimal(1);
    //     } else {
    //     messi.GetComponent<MessiController>().PerderUnaVida();
    //     }
    //   }
      
    //   //aca va codigo si sos alce 
    //   if ((other.gameObject.name == "Messi"))
    //   {
    //     messi.GetComponent<MessiController>().ALaPuta();
    //     messi.GetComponent<MessiController>().PerderUnaVida();
    //   }
    //   else
    //   {
    //   //  Debug.Log("Reno");
    //   }
    // }
  
    // }
}