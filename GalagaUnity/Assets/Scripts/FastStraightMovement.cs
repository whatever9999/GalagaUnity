using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastStraightMovement : ItemMovement
{
    public int distanceEveryFrame;

    private void Update()
    {
        Vector2 targetPos = transform.position;
        targetPos.y -= distanceEveryFrame;
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
    }
}
