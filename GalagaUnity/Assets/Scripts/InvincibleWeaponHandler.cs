using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InvincibleWeaponHandler : WeaponHandler
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Asteroid"))
        {
            //missiles from asteroids are tagged as asteroids - since they cannot drop a NullReferenceException will occur if they are shot
            //They don't need to do anything in place of the drop
            AudioManager.instance.Explosion();
            try
            {
                collision.gameObject.GetComponent<Drops>().Drop();
            }
            catch (NullReferenceException) { };
            Destroy(collision.gameObject);
            gm.ChangePoints(pointsForHitting);
        }
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            AudioManager.instance.Explosion();
            PlayerWeapons.instance.GetRandomWeapon();
            Destroy(collision.gameObject);
            gm.ChangePoints(pointsForHitting);
        }
    }
}
