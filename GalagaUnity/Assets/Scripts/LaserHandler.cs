using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserHandler : WeaponHandler
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Asteroid"))
        {
            collision.gameObject.transform.position = new Vector3(Random.Range(-5.5f, 5.5f), 7.5f, 0);
            gm.addPoints((int)PlayerWeapons.Points.ASTEROID);
        }
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            PlayerWeapons.GetRandomWeapon();
            Destroy(collision.gameObject);
            gm.addPoints((int)PlayerWeapons.Points.ENEMY);
        }
    }
}
