using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private Vector3 bgStartPos;
    
    [SerializeField]
    private GameObject background;
    
    private float repeatWidth;
    private float repeatHeight;
    
    private float horizontalInput;
    private float verticalInput;
    
    [SerializeField]
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = 1f;

        background = GameObject.Find("Background");
        bgStartPos = background.transform.position;
        repeatWidth = background.GetComponent<Renderer>().bounds.size.x / 3;
        repeatHeight = background.GetComponent<Renderer>().bounds.size.y / 3;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
        //infinite background
        if ((background.transform.position.x < bgStartPos.x - repeatWidth) | (background.transform.position.x > bgStartPos.x + repeatWidth))
        {
            background.transform.Translate(-background.transform.position.x, 0, 0);
            //background.transform.position = bgStartPos;
        }
        if ((background.transform.position.y < bgStartPos.y - repeatHeight) | (background.transform.position.y > bgStartPos.y + repeatHeight))
        {
            background.transform.Translate(0, 0, -background.transform.position.y);
        }

        //movement controller
        horizontalInput = Input.GetAxis("Horizontal");
        background.transform.Translate(Vector3.right * -horizontalInput * Time.deltaTime * speed);

        verticalInput = Input.GetAxis("Vertical");
        background.transform.Translate(Vector3.forward * -verticalInput * Time.deltaTime * speed);



        //if (transform.position.x < startPos.x - repeatWidth) {
        //    transform.position = startPos;
        //}
    }
}