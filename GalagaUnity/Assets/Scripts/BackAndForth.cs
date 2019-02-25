using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackAndForth : ItemMovement
{
    private Vector3 targetPos;
    private bool goingForth;
    public float distanceBack;
    public float distanceForth;

    private void Start()
    {
        targetPos = transform.position;
        goingForth = true;
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, targetPos) < 0.1f)
        {
            goingForth = !goingForth;

            if (goingForth)
            {
                targetPos.y -= distanceForth;
            }
            else
            {
                targetPos.y += distanceBack;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
    }
}
