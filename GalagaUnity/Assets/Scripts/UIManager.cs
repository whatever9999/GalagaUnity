using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI pointsText;
    public TextMeshProUGUI livesText;

    public static UIManager instance;

    private void OnEnable()
    {
        GameManager.uim = instance;
        ShowLives(GameManager.instance.GetNumLives());
        ShowPoints(GameManager.instance.GetTotalPoints());
    }

    private void Awake()
    {
        instance = this;
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
