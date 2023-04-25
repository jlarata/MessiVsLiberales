using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualRotation : MonoBehaviour
{

    
    //just gonna create a int for "facing" imitating the clock numbers.
    public int multipleFacing;
    //same. only horizontal
    public int hFacing;
    

    void Start()
    {
        multipleFacing = 9;
        hFacing = 9;
    }

    // Update is called once per frame
    void Update()
    {


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

            multipleFacing = 3;
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
            multipleFacing = 9;
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
            multipleFacing = 12;
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
            multipleFacing = 6;
        } 
        
        

        // if (Input.GetKey(KeyCode.RightArrow) | Input.GetKey(KeyCode.D))
        // {
        //     if (transform.rotation.y < .5)
        //     {
        //     transform.Rotate(transform.rotation.x, 90f, 0f, Space.World); 
        //     }
        // }


        // if (Input.GetKey(KeyCode.LeftArrow)| Input.GetKey(KeyCode.A))
        // {
        //     if (transform.rotation.y > -.5)
        //     {
        //     transform.Rotate(transform.rotation.x, -90f, 0f, Space.World); 
        //     }
        // }
        // if (Input.GetKey(KeyCode.UpArrow) | Input.GetKey(KeyCode.W))
        
        //     if (transform.rotation.x < .5)
        //     {
        //     transform.Rotate(90f, transform.rotation.y, 0f, Space.World); 
        //     }
        
        //{
        //    transform.rotation = Quaternion.Euler(90f, 0f, 0f);
        //}
        // if (Input.GetKey(KeyCode.DownArrow)| Input.GetKey(KeyCode.S))
        // {
        //     if (transform.rotation.x > -.5)
        //     {
        //     transform.Rotate(-90f, transform.rotation.y, 0f, Space.World); 
        //     }
        // }

    


        //if ((Input.GetKey(KeyCode.RightArrow) | Input.GetKey(KeyCode.D)) && (GetKey(KeyCode.DownArrow) | Input.GetKey(KeyCode.S)))
        //{
        //    transform.rotation = Quaternion.Euler(-90f, 90f, 0f);
        //}


        //do i want the rotator to have a neutral/standard rotation when not pressed?
        // if i do, i can decomment this else
        //else 
        //{
        //    transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        //}
        
        
        
        //horizontalInput = Input.GetAxis("Horizontal");
        //transform.Rotate(0f, -horizontalInput, 0f, Space.World);

        //verticalInput = Input.GetAxis("Vertical");
        //transform.Rotate()
    }
}
