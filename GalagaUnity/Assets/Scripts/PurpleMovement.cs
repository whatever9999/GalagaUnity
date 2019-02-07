using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PurpleMovement: MonoBehaviour {
    public float speed = 0.5f;
    private GameManager gm;

    private void Awake()
    {
        gm = GameManager.instance;
    }

    private void Update() {
        try
        {
            Vector2 playerPosition = FindObjectOfType<ShipMovement>().transform.position;
            transform.position = Vector2.MoveTowards(transform.position, playerPosition, speed * Time.deltaTime);
        } catch (NullReferenceException)
        {
            //When the player dies the purple ship won't be able to find the object and will just move in a straight line instead of towards the player
            Vector2 targetPostion = new Vector2(transform.position.x, -5);
            transform.position = Vector2.MoveTowards(transform.position, targetPostion, speed * Time.deltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            Destroy(gameObject);
            gm.LoseLife();
        }
    }
}
