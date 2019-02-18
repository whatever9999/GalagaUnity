using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
