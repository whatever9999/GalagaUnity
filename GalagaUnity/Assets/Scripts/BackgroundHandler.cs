using UnityEngine;

/*
 * Moves the background down and sets it to the top when it is no longer visible
 * */
public class BackgroundHandler : MonoBehaviour
{
    public float speed;
    public float backgroundHeight;

    void FixedUpdate()
    {
        transform.Translate(0, -speed * Time.deltaTime, 0);

        //Check to see if the image is out of sight
        if (transform.position.y <= -backgroundHeight)
        {
            //Move to a vector position that is out of sight but ABOVE the camera view
            Vector3 restartPos = transform.position;
            //Move up by background height * one less than the number of backgrounds as we are going past that number
            restartPos.y = backgroundHeight * (GameLoading.numBackgrounds - 1);
            transform.SetPositionAndRotation(restartPos, Quaternion.Euler(0, 0, 0));
        }
    }
}