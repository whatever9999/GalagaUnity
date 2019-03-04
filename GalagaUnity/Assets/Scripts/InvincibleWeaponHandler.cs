﻿using UnityEngine;

/*
 * Item will not be destroyed when it collides with other objects
 * */
public class InvincibleWeaponHandler : WeaponHandler
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Asteroid"))
        {
            gm.ChangePoints(pointsForHitting);

            AudioManager.instance.Explosion();
            
            AnimationManager.instance.ExplodeMeteorite(collision.gameObject);
        }
        else if (collision.gameObject.tag.Equals("Enemy"))
        {
            gm.ChangePoints(pointsForHitting);

            AudioManager.instance.Explosion();

            PlayerWeapons.instance.GetRandomWeapon();

            Destroy(collision.gameObject);
        }
    }
}
