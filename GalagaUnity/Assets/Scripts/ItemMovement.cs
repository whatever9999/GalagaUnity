using UnityEngine;

/*
 * Moves the item down the screen
 * Destroys the object if it leaves the screen or hits the player (also making them lose a life)
 * */
public class ItemMovement : ShipMovement
{
    protected GameManager gm;

    private void Awake()
    {
        gm = GameManager.instance;
    }

    void Update()
    {
        transform.Translate(0, -speed * Time.deltaTime, 0);
        if (transform.position.y <= -5)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            AudioManager.instance.Explosion();
            Destroy(gameObject);
            gm.LoseLife();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
