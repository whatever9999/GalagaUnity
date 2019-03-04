using UnityEngine;
using TMPro;

/*
 * Makes UI changes during the game
 * */
public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI pointsText;
    public TextMeshProUGUI livesText;

    public static UIManager instance;

    private void OnEnable()
    {
        //Game manager exists before the UIManger (Is enabled when the Game scene is reached) 
        //So the instance of the UIManager is set for the game manager here instead of in the GameManager's Start subroutine
        GameManager.uim = instance;

        //Show the start lives and points
        ShowLives(GameManager.instance.GetNumLives());
        ShowPoints(GameManager.instance.GetTotalPoints());
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(instance);
        }
        else
        {
            instance = this;
        }
    }

    public void ShowLives(int lives)
    {
        livesText.SetText("Lives: " + lives);
    }

    public void ShowPoints(int points)
    {
        pointsText.SetText("Score: " + points);
    }
}
