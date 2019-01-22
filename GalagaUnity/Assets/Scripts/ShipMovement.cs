using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public float Speed = 5;
    public float RotateSpeed = 0.5f;
    public float MinMaxBoundsY;
    public float MinMaxBoundsX;

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

        //set the boundaries
        if (transform.position.x >= MinMaxBoundsX)
        {
            transform.position = new Vector3(MinMaxBoundsX, transform.position.y, 0);
        }
        if (transform.position.x <= -MinMaxBoundsX)
        {
            transform.position = new Vector3(-MinMaxBoundsX, transform.position.y, 0);
        }
        if (transform.position.y >= MinMaxBoundsY)
        {
            transform.position = new Vector3(transform.position.x, MinMaxBoundsY, 0);
        }
        if (transform.position.y <= -MinMaxBoundsY)
        {
            transform.position = new Vector3(transform.position.x, -MinMaxBoundsY, 0);
        }
    }
}