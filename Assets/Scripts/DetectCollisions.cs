using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DetectCollisions : MonoBehaviour
{
  //originally a script to attach to an empty GObject 
  //but i realised it was easier to add this script to the enemies prefabs.
  // so when collision they can check if messi or weapon. there is no more posibilities, i think.


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
          messiController.PerderHp(thisEnemyDamage);
        }

        if (other.gameObject.tag == "Weapons")
        {

          //takes value from the weaponDamage variable of the weapon collided
          //and creats a float with that value
          float currentWeaponDamage = other.GetComponent<WeaponController>().weaponDamage;

          //instantiate the emptygameobject prefab named damageNumberEO. this has a TMP as a child
          GameObject newDNO = Instantiate(damageNumberEO, transform.position, transform.rotation);

          //takes weapon damage, converts it to string and sends it to child TMP, 
          newDNO.transform.GetChild(0).GetComponent<TMP_Text>().text = currentWeaponDamage.ToString();
          
          // note: i was having difficulties implementing this part. 
          // i learned that when you have normal TMP objects and TMPUGUI (the ones with canvas, i guess)
          // and they both share the same material preset, this produces bad behaviour "as the MeshRenderer and
          // CanvasRenderer systems are fighting over the ZTest on these objects" (?)
          // so: i duplicated the material (that has the font) and changed the material in the MeshRenderer
          // of the normal TMP (the child, in this case). Just in case i've also changed the font in the TMP_text component
          // maybe the later is not necesary, i dont know and i wont know. 

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
    
 }