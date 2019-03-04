using UnityEngine;

/*
 * All ships have a speed variable and access to the bounds of the screen
 * In the case of enemy ships the bounds may be used to determine the pattern they move in
 * This is why this variable is here instead of in the PlayerMovement class
 * */
public class ShipMovement : MonoBehaviour
{
    public float speed;
    protected Vector2 MinMaxBounds;

    private void Start()
    {
        MinMaxBounds.x = Screen.width / 2;
        MinMaxBounds.y = Screen.height / 2;
    }
}