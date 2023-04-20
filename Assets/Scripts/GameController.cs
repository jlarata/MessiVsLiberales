using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    private Vector3 bgStartPos;
    

    //had to add "G"background to prevent errors with the "background" element of the UI sliders
    [SerializeField]
    private GameObject gbackground;
    
    private float repeatWidth;
    private float repeatHeight;
    
    private float horizontalInput;
    private float verticalInput;
    
    [SerializeField]
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = 1.0f;

        gbackground = GameObject.Find("GBackground");
        bgStartPos = gbackground.transform.position;
        repeatWidth = gbackground.GetComponent<Renderer>().bounds.size.x / 3;
        repeatHeight = gbackground.GetComponent<Renderer>().bounds.size.y / 3;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
        //infinite background
        if ((gbackground.transform.position.x < bgStartPos.x - repeatWidth) | (gbackground.transform.position.x > bgStartPos.x + repeatWidth))
        {
            gbackground.transform.Translate(-gbackground.transform.position.x, 0, 0);
            //background.transform.position = bgStartPos;
        }
        if ((gbackground.transform.position.y < bgStartPos.y - repeatHeight) | (gbackground.transform.position.y > bgStartPos.y + repeatHeight))
        {
            gbackground.transform.Translate(0, 0, -gbackground.transform.position.y);
        }

        //movement controller
        horizontalInput = Input.GetAxis("Horizontal");
        gbackground.transform.Translate(Vector3.right * -horizontalInput * Time.deltaTime * speed);

        verticalInput = Input.GetAxis("Vertical");
        gbackground.transform.Translate(Vector3.forward * -verticalInput * Time.deltaTime * speed);



        //if (transform.position.x < startPos.x - repeatWidth) {
        //    transform.position = startPos;
        //}
    }
}