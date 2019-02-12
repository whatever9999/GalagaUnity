using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    GameManager gm = GameManager.instance;

    public void RestartButton()
    {
        gm.Game();
        //Player is instantiated when scene is loaded fully (GameLoading class)
    }

    public void QuitButton()
    {
        gm.StartMenu();
    }
}
