using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public float Speed = 1;
    public float RotateSpeed = 5;
    
    void Update()
    {
        //Movement      
        if (Input.GetKey("a"))
        {
            transform.Translate(-(Speed * Time.deltaTime), 0, 0);
        }
        if (Input.GetKey("d"))
        {
            transform.Translate((Speed * Time.deltaTime), 0, 0);
        }
        if(Input.GetKey("w"))
        {
            transform.Translate(0, (Speed * Time.deltaTime), 0);
        }
        if (Input.GetKey("s"))
        {
            transform.Translate(0, -(Speed * Time.deltaTime), 0);
        }

        //Rotation
        transform.Rotate(0, 0, Input.GetAxis("Horizontal") * RotateSpeed * Time.deltaTime);
    }
}