using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int startLives;
    public Transform player;
    public Vector3 startPos;

    int numLives;
    int totalPoints;

    public static UIManager uim;

    public static GameManager instance;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        instance = this;
        numLives = startLives;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //Player is instantiated when scene is loaded fully (GameLoading class)

        GameManager.uim = UIManager.instance;
        while (uim = null)
        {
            if(uim != null)
            {
                GameManager.uim.showPoints(totalPoints);
                GameManager.uim.showLives(numLives);
            }
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoseLife()
    {
        numLives--;
        Debug.Log(numLives);

        if (numLives < 0)
        {
            numLives = startLives;
            EndGame();
        }
        else
        {
            uim.showLives(numLives);
            NextLife();
        }
    }

    private void EndGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void NextLife()
    {
        player.transform.position = startPos;
        PlayerState.isImmune = true;
    }

    public void changePoints(int points)
    {
        totalPoints += points;
        uim.showPoints(totalPoints);
    }
}