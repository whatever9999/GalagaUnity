using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoading : MonoBehaviour
{
    void OnEnable()
    {
        Instantiate(GameManager.instance.player, GameManager.instance.startPos, Quaternion.identity);
    }
}