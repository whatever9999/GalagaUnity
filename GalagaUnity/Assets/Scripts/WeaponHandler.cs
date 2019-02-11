using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        if (transform.position.y >= 10)
        {
            Destroy(gameObject);
            gm.changePoints(-pointsTakenForMissing);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Asteroid"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            gm.changePoints(pointsForHitting);
        }
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            PlayerWeapons.instance.GetRandomWeapon();
            Destroy(collision.gameObject);
            Destroy(gameObject);
            gm.changePoints(pointsForHitting);
        }
    }
}