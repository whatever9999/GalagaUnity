using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibleWeaponHandler : WeaponHandler
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Asteroid"))
        {
            Destroy(collision.gameObject);
            gm.changePoints(pointsForHitting);
        }
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            PlayerWeapons.instance.GetRandomWeapon();
            Destroy(collision.gameObject);
            gm.changePoints(pointsForHitting);
        }
    }
}
