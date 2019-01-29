using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public float Speed = 5;
    private float MinMaxBounds;

    private void Start()
    {
        MinMaxBounds = Screen.width / 2;
    }

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

        //set the boundaries
        if (transform.position.x >= MinMaxBounds)
        {
            transform.position = new Vector3(MinMaxBounds, transform.position.y, 0);
        }
        if (transform.position.x <= -MinMaxBounds)
        {
            transform.position = new Vector3(-MinMaxBounds, transform.position.y, 0);
        }
    }
    
}