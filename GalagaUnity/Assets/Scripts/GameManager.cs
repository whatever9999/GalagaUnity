using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    enum Scenes {GameManager, StartMenu, Game, EndMenu};

    public int startLives;
    public Transform player;
    public Vector3 startPos;

    int numLives;
    int totalPoints;

    public int GetNumLives()
    {
        return numLives;
    }
    public int GetTotalPoints()
    {
        return totalPoints;
    }

    public static UIManager uim;

    public static GameManager instance;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        instance = this;
        numLives = startLives;
        StartMenu();
    }

    public void StartMenu()
    {
        SceneManager.LoadScene((int)Scenes.StartMenu);
    }

    public void Game()
    {
        SceneManager.LoadScene((int)Scenes.Game);
        //Player is instantiated when scene is loaded fully (GameLoading class)
        //Score and lives text is also set
    }

    public void EndMenu()
    {
        SceneManager.LoadScene((int)Scenes.EndMenu);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoseLife()
    {
        numLives--;

        if (numLives < 0)
        {
            EndGame();
        }
        else
        {
            uim.ShowLives(numLives);
            NextLife();
        }
    }

    private void EndGame()
    {
        numLives = startLives;
        totalPoints = 0;
        EndMenu();
    }

    private void NextLife()
    {
        player.transform.position = startPos;
        PlayerState.isImmune = true;
    }

    public void ChangePoints(int points)
    {
        totalPoints += points;
        uim.ShowPoints(totalPoints);
    }
}