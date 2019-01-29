using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject GameManager;
    public float timer;
    public float timeLimit;
    public EGamestates State;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeLimit)
        {
            GameManager.GetComponent<Startup>().LoadCurrentScene(State);
        }
    }
}
