using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WeaponHandler : MonoBehaviour
{
    public float speed;
    public int pointsForHitting;
    public int pointsTakenForMissing;

    protected GameManager gm;

    private void Awake()
    {
        gm = GameManager.instance;
    }

    void Update()
    {
        transform.Translate(0, speed * Time.deltaTime, 0);

        if (transform.position.y >= 5)
        {
            Destroy(gameObject);
            gm.ChangePoints(-pointsTakenForMissing);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Asteroid"))
        {
            //missiles from asteroids are tagged as asteroids - since they cannot drop a NullReferenceException will occur if they are shot
            //They don't need to do anything in place of the drop
            try
            {
                collision.gameObject.GetComponent<Drops>().Drop();
            }
            catch (NullReferenceException) { };
            Destroy(gameObject);
            Destroy(collision.gameObject);
            gm.ChangePoints(pointsForHitting);
        }
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            PlayerWeapons.instance.GetRandomWeapon();
            Destroy(collision.gameObject);
            Destroy(gameObject);
            gm.ChangePoints(pointsForHitting);
        }
    }
}