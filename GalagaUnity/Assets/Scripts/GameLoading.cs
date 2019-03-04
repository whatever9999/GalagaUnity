using UnityEngine;

/*
 * Instantiates the backgrounds when the game scene is loaded
 * */
public class GameLoading : MonoBehaviour
{
    public GameObject background;

    void OnEnable()
    {
        Instantiate(GameManager.instance.player, GameManager.instance.startPos, Quaternion.identity);

        //Put the backgrounds accross three rows according to their height
        for(int i = 0; i < 3; i++)
        {
            Instantiate(background).transform.SetPositionAndRotation(new Vector3(0, BackgroundHandler.staticBackgroundHeight * i, 5), Quaternion.identity);
        }
    }
}