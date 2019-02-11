using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script controls what the meteorite does. Attach to the meteor prefab
public class Fall : MonoBehaviour
{
    public float FallSpeed;
    public GameObject Rock;

    private GameManager gm;

    private void Awake()
    {
        gm = GameManager.instance;
    }

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
            gm.LoseLife();
        }
    }
}