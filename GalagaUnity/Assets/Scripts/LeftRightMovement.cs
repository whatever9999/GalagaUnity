using UnityEngine;

/*
 * Item moves left and right as it goes down the screen
 * */
public class LeftRightMovement : ItemMovement {
    public float xDisplacement;
    public float yDisplacement;

    //We add if we are going to the right, subtract if going left
    private bool add = false;

    private Vector2 targetPos;

    void Start()
    {
        targetPos = new Vector2(transform.position.x, transform.position.y);
    }

    private void Update()
    {
        //Check if the item has reached the target position
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

        if (transform.position.y < -offscreenDistance) Destroy(gameObject);
    }
}
