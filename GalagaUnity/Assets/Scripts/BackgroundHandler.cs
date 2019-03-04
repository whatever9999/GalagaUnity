using UnityEngine;

/*
 * Moves the background down and sets it to the top when it is no longer visible
 * */
public class BackgroundHandler : MonoBehaviour
{
    public float speed;
    public float backgroundHeight;
    //Background height is used in 'GameLoading' to instantiate the backgrounds to move and needs to be static
    //The inspector is used to input the background height so it cannot be static
    //Access background height is given the same value but is static and therefore accessable outside the BackgroundHandler class
    public static float staticBackgroundHeight;

    private void Awake()
    {
        staticBackgroundHeight = backgroundHeight;
    }

    void FixedUpdate()
    {
        transform.Translate(0, -speed * Time.deltaTime, 0);

        //Check to see if the image is out of sight
        if (transform.position.y <= -backgroundHeight)
        {
            //Move to a vector position that is out of sight but ABOVE the camera view
            Vector3 restartPos = transform.position;
            restartPos.y = backgroundHeight * 2;
            transform.SetPositionAndRotation(restartPos, Quaternion.Euler(0, 0, 0));
        }
    }
}