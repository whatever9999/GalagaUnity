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
        instance = this;
        numLives = startLives;
        StartGame();
    }

    private void StartGame()
    {
        startPos.z = 0;
        Instantiate(player, startPos, Quaternion.identity);
    }

    public void LoseLife()
    {
        numLives--;
        Debug.Log(numLives);

        if (numLives < 0)
        {
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
        //JUST CHANGED DOESN'T WORK
        GetComponent<PlayerState>().transform.position = GameManager.instance.startPos;
        PlayerState.isImmune = true;
    }

    public void addPoints(int points)
    {
        totalPoints += points;
        Debug.Log(totalPoints);
    }
}