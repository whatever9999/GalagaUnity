using UnityEngine;

/*
 * Each weapon (bullet/laser/etc.) has a speed, an amount of points for hitting something and an amount for missing determined in the inspector
 * By default a weapon will move in a straight line and be destroyed when it hits a meteorite/enemy (destroying that object as well)
 * */
public class WeaponHandler : MonoBehaviour
{
    public string asteroidTag = "Asteroid";
    public string enemyTag = "Enemy";

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

        if (transform.position.y >= ItemMovement.offscreenDistance)
        {
            Destroy(gameObject);
            //If the weapon is destroyed because it goes out of bounds then points are deducted from the player's score
            gm.ChangePoints(-pointsTakenForMissing);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals(asteroidTag))
        {
            //Add points
            gm.ChangePoints(pointsForHitting);

            //Sfx
            AudioManager.instance.Explosion();

            //Animation and destruction of collision object (meteorite)
            AnimationManager.instance.ExplodeMeteorite(collision.gameObject);

            //Destroy this object
            Destroy(gameObject);
        }
        if (collision.gameObject.tag.Equals(enemyTag))
        {
            gm.ChangePoints(pointsForHitting);

            AudioManager.instance.Explosion();

            //Give the player a power up weapon for hitting an enemy ship
            PlayerWeapons.instance.GetRandomWeapon();

            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}