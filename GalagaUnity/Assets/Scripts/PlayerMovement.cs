using UnityEngine;

/*
 * The player controls the ship using A (left) and D (right) and they are restrained within the bounds of the screen
 * */
public class PlayerMovement : ShipMovement
{
    public KeyCode leftKeyCode = KeyCode.A;
    public KeyCode rightKeyCode = KeyCode.D;

    void Update()
    {
        //Movement      
        if (Input.GetKey(leftKeyCode))
        {
            transform.Translate(-(speed * Time.deltaTime), 0, 0);
        }
        if (Input.GetKey(rightKeyCode))
        {
            transform.Translate((speed * Time.deltaTime), 0, 0);
        }

        //set the boundaries
        Vector3 newPos = transform.position;
        newPos.x = Mathf.Clamp(newPos.x, MinMaxBounds.x, -MinMaxBounds.x);
        transform.position = newPos;
    }

}
