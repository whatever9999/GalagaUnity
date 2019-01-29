using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserHandler : MonoBehaviour
{
    public float speed;
    public GameObject laser;
    private Startup gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<Startup>();
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
            gameManager.GetComponent<Startup>().AddScore(10);
            collision.gameObject.transform.position = new Vector3(Random.Range(-5.5f, 5.5f), 7.5f, 0);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            gameManager.GetComponent<Startup>().AddScore(50);
            ShipWeapons.GetRandomWeapon();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
