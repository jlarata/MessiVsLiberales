using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DetectCollisions : MonoBehaviour
{

  //AudioSource source;
  //public GameObject gameObjectQueManejeElAudio;
    public GameObject messi;
    public MessiController messiController;

    public GameObject damageNumberEO;
    //public TMP_Text damageNumber;

    //this should be a protected variable with a setter...
    //in any case: it's setted from every child enemy script.
    public float thisEnemyDamage;

    void Start()
    {
      messi = GameObject.Find("Messi");
      messiController = messi.GetComponent<MessiController>();

      
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
          //Debug.Log("Reno");
          messiController.PerderHp(thisEnemyDamage);
        }

        if (other.gameObject.tag == "Weapons")
        {

          float currentWeaponDamage = other.GetComponent<WeaponController>().weaponDamage;
          GameObject newDNO = Instantiate(damageNumberEO, transform.position, transform.rotation);
          newDNO.gameObject.transform.GetChild(0).GetComponent<TMP_Text>().text = currentWeaponDamage.ToString();
          
          if (currentWeaponDamage <= 1.0f)
          {
            Color lowerDamageNumberColor = new Color(0f, 32f, 166f, 255f);
            newDNO.gameObject.transform.GetChild(0).GetComponent<TMP_Text>().color = lowerDamageNumberColor;
          }
          else if (currentWeaponDamage >1.0f)
          {
            Color lowDamageNumberColor = new Color(140f, 213f, 0f, 255f);
            newDNO.gameObject.transform.GetChild(0).GetComponent<TMP_Text>().color = lowDamageNumberColor;
          }



          GetComponent<EnemyController>().loseHp(other.GetComponent<WeaponController>().weaponDamage);
          GetComponent<EnemyController>().HitAnimationF();
          

          //other.GetComponent<WeaponController>
            
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