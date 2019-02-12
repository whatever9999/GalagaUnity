using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRightMovement : ItemMovement {
    public float xDisplacement = 1.5f;
    public float yDisplacement = 1.5f;

    private bool add = false;
    private Vector2 targetPos;

    void Start()
    {
        targetPos = new Vector2(transform.position.x, transform.position.y);
    }

    private void Update()
    {
        if (new Vector2(transform.position.x, transform.position.y) != targetPos)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        } else
        {
            if (add)
            {
                targetPos = new Vector2(transform.position.x + xDisplacement, transform.position.y - yDisplacement);
            }
            else
            {
                targetPos = new Vector2(transform.position.x - xDisplacement, transform.position.y - yDisplacement);
            }

            add = !add;
        }

        if (transform.position.y < -5) Destroy(gameObject);
    }
}
