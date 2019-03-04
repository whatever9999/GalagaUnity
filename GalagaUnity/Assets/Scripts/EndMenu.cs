using UnityEngine;
using TMPro;

/*
 * Adds data relating to the previous scene into the UI e.g. score
 * End menu button controller
 * */
public class EndMenu : MonoBehaviour
{
    GameManager gm;
    public TextMeshProUGUI scoreText;

    //When the script is enabled (The end screen scene is loaded) the score will be allocated according to that found in the game manager
    private void OnEnable()
    {
        gm = GameManager.instance;
        scoreText.SetText("Final Score: " + gm.GetTotalPoints());
    }

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
