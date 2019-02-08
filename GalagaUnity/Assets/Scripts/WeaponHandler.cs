﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    public float speed;

    private GameManager gm;

    private void Awake()
    {
        gm = GameManager.instance;
    }

    void Update()
    {
        transform.Translate(0, speed * Time.deltaTime, 0);

        if (transform.position.y >= 10)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Asteroid"))
        {
            collision.gameObject.transform.position = new Vector3(Random.Range(-5.5f, 5.5f), 7.5f, 0);
            gm.addPoints((int)ShipWeapons.Points.ASTEROID);
        }
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            ShipWeapons.GetRandomWeapon();
            Destroy(collision.gameObject);
            gm.addPoints((int)ShipWeapons.Points.ENEMY);
        }
    }
}