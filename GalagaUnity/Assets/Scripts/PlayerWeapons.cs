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

    public GameObject bullet;
    public GameObject laser;

    enum Weapon { oneBullet, threeBullet, laser };
    public enum Points { ASTEROID = 10, ENEMY = 20 };
    private static int currentWeapon;


    private void Start()
    {
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
            currentWeapon = (int)Weapon.oneBullet;
        }

        if (Input.GetKey("s") && shootTimer >= shootTimeLimit)
        {
            Shoot();
            shootTimer = 0;
        }
    }

    public void Shoot()
    {
        switch (currentWeapon)
        {
            case (int)Weapon.oneBullet:
                Vector3 bulletPos = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
                GameObject.Instantiate(bullet).transform.SetPositionAndRotation(bulletPos, Quaternion.Euler(0, 0, 0));
                break;
            case (int)Weapon.threeBullet:
                bulletPos = new Vector3(transform.position.x - 0.5f, transform.position.y + 0.5f, transform.position.z);
                GameObject.Instantiate(bullet).transform.SetPositionAndRotation(bulletPos, Quaternion.Euler(0, 0, 0));

                Vector3 bulletTwoPos = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
                GameObject.Instantiate(bullet).transform.SetPositionAndRotation(bulletTwoPos, Quaternion.Euler(0, 0, 0));

                Vector3 bulletThreePos = new Vector3(transform.position.x + 0.5f, transform.position.y + 0.5f, transform.position.z);
                GameObject.Instantiate(bullet).transform.SetPositionAndRotation(bulletThreePos, Quaternion.Euler(0, 0, 0));
                break;
            case (int)Weapon.laser:
                Vector3 laserPos = new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z);
                GameObject.Instantiate(laser).transform.SetPositionAndRotation(laserPos, Quaternion.Euler(0, 0, 0));
                break;
        }

    }

    public static void GetRandomWeapon()
    {
        int rand = (int)Random.Range(1, 3);

        switch (rand)
        {
            case (int)Weapon.threeBullet:
                currentWeapon = (int)Weapon.threeBullet;
                break;
            case (int)Weapon.laser:
                currentWeapon = (int)Weapon.laser;
                break;
            default:
                currentWeapon = (int)Weapon.oneBullet;
                break;
        }

        powerUpTimer = 0;
        timerOn = true;
    }
}
