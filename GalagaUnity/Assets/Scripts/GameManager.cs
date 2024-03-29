﻿using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Handles scene transitions, points and lives
 * */
public class GameManager : MonoBehaviour
{
    enum Scenes {GameManager, StartMenu, Game, EndMenu};

    public int startLives;
    public Transform player;
    public Vector3 startPos;

    private int numLives;
    private int totalPoints;

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

        if (instance != null && instance != this)
        {
            Destroy(instance);
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        StartMenu();
    }

    public void StartMenu()
    {
        SceneManager.LoadScene((int)Scenes.StartMenu);
    }

    public void Game()
    {
        numLives = startLives;
        totalPoints = 0;
        SceneManager.LoadScene((int)Scenes.Game);
        //Player is instantiated when scene is loaded fully (GameLoading script)
        //Score and lives text is also set
    }

    public void EndMenu()
    {
        SceneManager.LoadScene((int)Scenes.EndMenu);
        //Score is set when scene is loaded fully (EndMenu script)
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoseLife()
    {
        numLives--;

        //Check if has run out of lives
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

    public void GainLife()
    {
        numLives++;
        uim.ShowLives(numLives);
    }

    private void EndGame()
    {
        EndMenu();
    }

    private void NextLife()
    {
        PlayerState.isImmune = true;
    }

    public void ChangePoints(int points)
    {
        totalPoints += points;
        uim.ShowPoints(totalPoints);
    }
}