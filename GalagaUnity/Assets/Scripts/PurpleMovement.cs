using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleMovement: MonoBehaviour {
    public float speed = 0.5f;

    private void Update() {
        Vector2 playerPosition = FindObjectOfType<ShipMovement>().transform.position;
        transform.position = Vector2.MoveTowards(transform.position, playerPosition, speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            Application.Quit();
        }
    }
}
