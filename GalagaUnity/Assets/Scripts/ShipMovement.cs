using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public float Speed = 5;
    public float RotateSpeed = 0.5f;

    void Update()
    {
        //Movement      
        if (Input.GetKey("a"))
        {
            transform.Rotate(0, 0, RotateSpeed);
        }
        if (Input.GetKey("d"))
        {
            transform.Rotate(0, 0, -RotateSpeed);
        }
        if (Input.GetKey("w"))
        {
            transform.Translate(0, (Speed * Time.deltaTime), 0);
        }
        if (Input.GetKey("s"))
        {
            transform.Translate(0, -(Speed * Time.deltaTime), 0);
        }
    }
}