using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public float Speed = 5;
    public float MinMaxBoundsX;

    public GameObject bullet;
    public GameObject laser;
    public float timer;
    public float timeLimit;

    enum Weapon { oneBullet, threeBullet, laser };
    private static int currentWeapon;

    void Update()
    {
        timer += Time.deltaTime;

        //Movement      
        if (Input.GetKey("a"))
        {
            transform.Translate(-(Speed * Time.deltaTime), 0, 0);
        }
        if (Input.GetKey("d"))
        {
            transform.Translate((Speed * Time.deltaTime), 0, 0);
        }

        if (Input.GetKey("s") && timer >= timeLimit)
        {
            timer = 0;
            shoot();
        }

        //set the boundaries
        if (transform.position.x >= MinMaxBoundsX)
        {
            transform.position = new Vector3(MinMaxBoundsX, transform.position.y, 0);
        }
        if (transform.position.x <= -MinMaxBoundsX)
        {
            transform.position = new Vector3(-MinMaxBoundsX, transform.position.y, 0);
        }
    }

    public static void GetRandomWeapon()
    {
        int rand = (int)Random.Range(1, 2);

        switch(rand)
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
    }

    public void shoot()
    {
        switch(currentWeapon)
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
                Vector3 laserPos = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
                GameObject.Instantiate(laser).transform.SetPositionAndRotation(laserPos, Quaternion.Euler(0, 0, 0));
                break;
        }
        
    }
}