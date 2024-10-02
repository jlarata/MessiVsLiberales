using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualRotation : MonoBehaviour
{

    
    //varaible not needed anymore? see comment in messicontroller.
    //public int multipleFacing;
    //same. only horizontal
    public int hFacing;
    public Vector2 totalMovement;
    public int totalMovementFacing; 
    

    void Start()
    {
        //multipleFacing = 9;
        hFacing = 9;
        totalMovementFacing = 900;
    }

    void FixedUpdate()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");
        totalMovement = new Vector2(inputX, inputY);

        if (inputX != 0 && inputY != 0)
        {
            if (totalMovement.y == 1 && totalMovement.x == -1)
            { //Debug.Log("up-left");
            totalMovementFacing = 1030;
            }

            if (totalMovement.y == 1 && totalMovement.x == 1)
            { //Debug.Log("up-right");
            totalMovementFacing = 130;
            }

            if (totalMovement.y == -1 && totalMovement.x == -1)
            { //Debug.Log("down-left");
            totalMovementFacing = 730;
            }

            if (totalMovement.y == -1 && totalMovement.x == 1)
            { //Debug.Log("down-right");
            totalMovementFacing = 430;
            }
            
        }
        else
        {
            if (totalMovement.x == -1)
            {
                //Debug.Log("left");
                totalMovementFacing = 900;
            }
            if (totalMovement.x == 1)
            {
                //Debug.Log("right");
                totalMovementFacing = 300;
            }
            if (totalMovement.y == 1)
            {
                //Debug.Log("up");
                totalMovementFacing = 1200;
            }
            if (totalMovement.y == -1)
            {
                //Debug.Log("down");
                totalMovementFacing = 600;
            }
        }
        


        if (Input.GetKey(KeyCode.RightArrow) | Input.GetKey(KeyCode.D))
        //(Input.GetKeyDown(KeyCode.RightArrow) | Input.GetKeyDown(KeyCode.D))

        {
            if (transform.rotation == Quaternion.Euler(-90f, 0f, 0f))
            {
            transform.rotation = Quaternion.Euler(-90f, 90f, 0f);
            }
            else if (transform.rotation == Quaternion.Euler(90f, 0f, 0f))
            {
            transform.rotation = Quaternion.Euler(90f, 90f, 0f);
            } else
            {
            transform.rotation = Quaternion.Euler(0f, 90f, 0f);
            }

            //multipleFacing = 3;
            hFacing = 3;
        }

        if (Input.GetKey(KeyCode.LeftArrow) | Input.GetKey(KeyCode.A))
        //(Input.GetKeyDown(KeyCode.LeftArrow) | Input.GetKeyDown(KeyCode.A))
        {
            if (transform.rotation == Quaternion.Euler(-90f, 0f, 0f))
            {
            transform.rotation = Quaternion.Euler(-90f, -90f, 0f);
            }
            else if (transform.rotation == Quaternion.Euler(90f, 0f, 0f))
            {
            transform.rotation = Quaternion.Euler(90f, -90f, 0f);
            } else
            {
            transform.rotation = Quaternion.Euler(0f, -90f, 0f);
            }
            //multipleFacing = 9;
            hFacing = 9;
        }        
        
        if (Input.GetKey(KeyCode.UpArrow) | Input.GetKey(KeyCode.W))
        //(Input.GetKeyDown(KeyCode.UpArrow) | Input.GetKeyDown(KeyCode.W))
        {
            if (transform.rotation == Quaternion.Euler(0f, 90f, 0f))
            {
            transform.rotation = Quaternion.Euler(90f, 90f, 0f);
            }
            else if (transform.rotation == Quaternion.Euler(0f, -90f, 0f))
            {
            transform.rotation = Quaternion.Euler(90f, -90f, 0f);
            } else
            {
            transform.rotation = Quaternion.Euler(90f, 0f, 0f);
            }
            //multipleFacing = 12;
        }  

        if (Input.GetKey(KeyCode.DownArrow) | Input.GetKey(KeyCode.S))
        //if (Input.GetKeyDown(KeyCode.DownArrow) | Input.GetKeyDown(KeyCode.S))
        {
            if (transform.rotation == Quaternion.Euler(0f, 90f, 0f))
            {
            transform.rotation = Quaternion.Euler(-90f, 90f, 0f);
            }
            else if (transform.rotation == Quaternion.Euler(0f, -90f, 0f))
            {
            transform.rotation = Quaternion.Euler(-90f, -90f, 0f);
            } else
            {
            transform.rotation = Quaternion.Euler(-90f, 0f, 0f);
            }
            //multipleFacing = 6;
        } 
        
    }
}
