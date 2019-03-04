using UnityEngine;

/*
 * The player controls the ship using A (left) and D (right) and they are restrained within the bounds of the screen
 * */
public class PlayerMovement : ShipMovement
{
    void Update()
    {
        //Movement      
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-(speed * Time.deltaTime), 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
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
