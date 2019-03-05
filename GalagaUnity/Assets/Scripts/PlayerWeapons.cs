using UnityEngine;

/*
 * Gives the player a random weapon of those added in the inspector temporarily (when an enemy ship is hit)
 * Shoots the weapon when the player presses the S key
 * Handles the timers for the random weapon power ups and between shots (don't want player to shoot a constant stream of bullets)
 * */
public class PlayerWeapons : MonoBehaviour
{
    public KeyCode shootKeyCode = KeyCode.S;

    private static bool timerOn;
    private static float powerUpTimer;
    public float powerUpTimeLimit;

    private static float shootTimer;
    public float shootTimeLimit;

    public Weapon baseWeapon;
    public Weapon[] powerUpWeapons;
    private Weapon currentWeapon;

    //Space between player and bullets/lasers
    private const float shotPlayerDistance = 1;
    //Space between bullets/lasers if there's more than one
    private const float shotDistance = 0.5f;

    public static PlayerWeapons instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(instance);
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        currentWeapon = baseWeapon;
        timerOn = false;
    }

    private void Update()
    {
        if (timerOn)
        {
            powerUpTimer += Time.deltaTime;
        }

        if(powerUpTimer > powerUpTimeLimit)
        {
            currentWeapon = baseWeapon;
        }

        shootTimer += Time.deltaTime;

        if (Input.GetKey(shootKeyCode) && shootTimer >= shootTimeLimit)
        {
            Shoot();
            shootTimer = 0;
        }
    }

    public void Shoot()
    {
        Vector3 shotPosition = transform.position;
        shotPosition.y += shotPlayerDistance;

        //Weapons may have multiple "shots" when fired
        //Each shot has a distance between it determined in the inspector
        float shotDistanceRange = shotDistance * currentWeapon.numberShots - shotDistance;
        //Move the shot position all the way to the left
        shotPosition.x -= shotDistanceRange / 2f;

        for (int i = 0; i < currentWeapon.numberShots; i++)
        {
            Instantiate(currentWeapon.weapon).transform.SetPositionAndRotation(shotPosition, Quaternion.identity);
            //Move the shot position to the right by the distance between one shot
            shotPosition.x += shotDistance;
        }
    }

    public void GetRandomWeapon()
    {
        int rand = (int)Random.Range(0, powerUpWeapons.Length);

        currentWeapon = powerUpWeapons[rand];

        powerUpTimer = 0;
        timerOn = true;
    }

    [System.Serializable]
    public class Weapon
    {
        public GameObject weapon;
        public int numberShots;
    }
}