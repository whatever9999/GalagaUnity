using UnityEngine;

/*
 * Instantiates the backgrounds when the game scene is loaded
 * */
public class GameLoading : MonoBehaviour
{
    public const int numBackgrounds = 3;
    public GameObject background;

    void OnEnable()
    {
        Instantiate(GameManager.instance.player, GameManager.instance.startPos, Quaternion.identity);

        //Put the backgrounds accross three rows according to their height
        float backgroundHeight = background.GetComponent<BackgroundHandler>().backgroundHeight;
        for (int i = 0; i < numBackgrounds; i++)
        {
            Instantiate(background).transform.SetPositionAndRotation(new Vector3(0, backgroundHeight * i, 0), Quaternion.identity);
        }
    }
}