using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI pointsText;
    public TextMeshProUGUI livesText;

    public static UIManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void showLives(int lives)
    {
        livesText.SetText("Lives: " + lives);
    }

    public void showPoints(int points)
    {
        pointsText.SetText("Score: " + points);
    }
}
