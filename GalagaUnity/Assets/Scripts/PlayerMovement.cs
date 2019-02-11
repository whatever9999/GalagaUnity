using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : ShipMovement
{
    void Update()
    {
        //Movement      
        if (Input.GetKey("a"))
        {
            transform.Translate(-(speed * Time.deltaTime), 0, 0);
        }
        if (Input.GetKey("d"))
        {
            transform.Translate((speed * Time.deltaTime), 0, 0);
        }

        //set the boundaries
        if (transform.position.x >= MinMaxBounds.x)
        {
            transform.position = new Vector3(MinMaxBounds.x, transform.position.y, 0);
        }
        if (transform.position.x <= -MinMaxBounds.x)
        {
            transform.position = new Vector3(-MinMaxBounds.x, transform.position.y, 0);
        }
    }

}
