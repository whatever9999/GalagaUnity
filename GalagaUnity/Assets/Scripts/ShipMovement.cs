using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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