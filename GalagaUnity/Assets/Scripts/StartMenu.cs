using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    GameManager gm = GameManager.instance;

    public void StartButton()
    {
        gm.Game();
    }

    public void QuitButton()
    {
        gm.QuitGame();
    }
}
