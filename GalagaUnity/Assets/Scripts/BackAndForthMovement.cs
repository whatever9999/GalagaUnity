using UnityEngine;

/* 
 * Item moves in a straight line
 * Options: Move forward then back same amount (will stay in same place) or move forward then back smaller amount (will inch forward)
 * */
public class BackAndForthMovement : ItemMovement
{
    private const float requiredMagnitude = 0.1f;

    private Vector3 targetPos;
    //Whether the item is going forward or backwards
    private bool goingForth;
    public float distanceBack;
    public float distanceForth;

    private void Start()
    {
        //Target position's y will be altered according to if the ship is going back or forth
        targetPos = transform.position;
        goingForth = true;
    }

    private void Update()
    {
        //Check to see if the position of the GameObject is the same as the target position
        if (Vector3.Distance(transform.position, targetPos) < requiredMagnitude)
        {
            //Flip goingForth if the targetPosition has been reached
            goingForth = !goingForth;

            //Set the new target position according to if going back or forth
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
