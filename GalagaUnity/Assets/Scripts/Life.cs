using UnityEngine;

/*
 * Life object gives the player an extra life and is destroyed when touched
 * */
public class Life : ItemMovement
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            Destroy(gameObject);
            gm.GainLife();
        }
    }
}
