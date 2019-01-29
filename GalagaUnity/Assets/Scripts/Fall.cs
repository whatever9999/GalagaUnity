using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script controls what the meteorite does. Attach to the meteor prefab
public class Fall : MonoBehaviour
{
    public float FallSpeed;
    public GameObject Rock;
    private Startup gameManager;

    public EGamestates State;

    private void Awake()
    {
        gameManager = FindObjectOfType<Startup>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, -FallSpeed * Time.deltaTime, 0);//make the rock fall 
        if (transform.position.y <= -5)
        {
            //Place the rock back at random point at the top of the screen (out of view)
            transform.position = new Vector3(Random.Range(-5.5f, 5.5f), 7.5f, 0);

        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            transform.position = new Vector3(Random.Range(-5.5f, 5.5f), 7.5f, 0);
            GameManager.GetComponent<Startup>().loseLife();
            GameManager.GetComponent<Startup>().loseLife();
            if (GameManager.GetComponent<Startup>().getLives() >= 0)
            {
                GameObject.Find("Player").transform.SetPositionAndRotation(new Vector2(Screen.width / 2, - Screen.height), Quaternion.Euler(0, 0, 0));
            } else if (GameManager.GetComponent<Startup>().getLives() == 0)
            {
                GameManager.GetComponent<Startup>().LoadCurrentScene(State);
            }
        }
    }
}