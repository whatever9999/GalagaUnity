using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoading : MonoBehaviour
{
    public GameObject background;

    void OnEnable()
    {
        Instantiate(GameManager.instance.player, GameManager.instance.startPos, Quaternion.identity);

        for(int i = 0; i < 3; i++)
        {
            Instantiate(background).transform.SetPositionAndRotation(new Vector3(0, BackgroundHandler.instance.backgroundHeight * i, 5), Quaternion.identity);
        }
    }
}