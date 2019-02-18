using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMovement : ShipMovement
{
    protected GameManager gm;

    private void Awake()
    {
        gm = GameManager.instance;
    }

    void Update()
    {
        transform.Translate(0, -speed * Time.deltaTime, 0);
        if (transform.position.y <= -5)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            gameObject.GetComponent<AudioSource>().Play();
            Destroy(gameObject);
            gm.LoseLife();
        }
    }
}
