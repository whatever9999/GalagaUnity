using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//Add this namespace

public enum EGamestates//These are used for swapping out scenes
{
    MENU, GAME, GAMEOVER, QUIT
};

public class Startup : MonoBehaviour
{
    public int levelNum = 0;//set the level number here
    public EGamestates e_gamestate;//for setting the initial game state

    public int score = 0;
    public int lastScore = 0;
    public int HiScore = 0;

    public int Lives;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Init();
    }


    void Init()//sets up the game and runs the menu
    {
        HiScore = 0;
        lastScore = 0;

        //e_gamestate = EGamestates.MENU;
        LoadCurrentScene(e_gamestate);
    }


    public void LoadCurrentScene(EGamestates State)
    {
        e_gamestate = State;
        switch (e_gamestate)
        {
            case EGamestates.MENU:
                SceneManager.LoadScene("Menu");
                break;

            case EGamestates.GAME:
                SceneManager.LoadScene("Main");
                //levelNum++;
                Lives = 3;
                break;

            case EGamestates.GAMEOVER:
                SceneManager.LoadScene("GameOver");
                lastScore = score;//update all the scores and set current score to 0
                if (score >= HiScore)
                {
                    HiScore = score;
                }
                score = 0;
                Lives = 3;
                break;

            case EGamestates.QUIT:
                Application.Quit();
                break;

            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Cancel"))
        {
            LoadCurrentScene(EGamestates.QUIT);//Can quit the game at any time with this
        }
    }

    //this is triggered once an Enemy dies or any other condition is met
    //the entity that has a score value will add a specific value when calling this
    public void AddScore(int Score)
    {
        score += Score;
    }

    public void addLife()
    {
        Lives++;
    }
    public void loseLife()
    {
        Lives--;
    }
    public int getLives()
    {
        return Lives;
    }
}