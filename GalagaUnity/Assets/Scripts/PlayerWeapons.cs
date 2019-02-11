using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapons : MonoBehaviour
{
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
        instance = this;
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

        shootTimer += Time.deltaTime;

        if(powerUpTimer > powerUpTimeLimit)
        {
            currentWeapon = baseWeapon;
        }

        if (Input.GetKey("s") && shootTimer >= shootTimeLimit)
        {
            Shoot();
            shootTimer = 0;
        }
    }

    public void Shoot()
    {
        Vector3 shotPosition = transform.position;
        shotPosition.y += shotPlayerDistance;
        float shotDistanceRange = shotDistance * currentWeapon.numberShots - shotDistance;
        shotPosition.x -= shotDistanceRange / 2f;
        for (int i = 0; i < currentWeapon.numberShots; i++)
        {
            Instantiate(currentWeapon.weapon).transform.SetPositionAndRotation(shotPosition, Quaternion.identity);
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