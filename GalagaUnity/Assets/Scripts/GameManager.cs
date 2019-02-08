using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int startLives;
    public Transform player;
    public Vector3 startPos;

    private int numLives;
    private int totalPoints;

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

    public void addPoints(int points)
    {
        totalPoints += points;
        Debug.Log(totalPoints);
    }
}