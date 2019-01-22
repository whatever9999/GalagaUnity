using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadShip : MonoBehaviour {
    public GameObject Rocket;
    public int timeBetweenShots;

	void Update () {
        StartCoroutine(Shoot());

        if (transform.position.y < -5)
        {
            Destroy(this);
        }
        if (Rocket.transform.position.y < -5)
        {
            Destroy(Rocket);
        }
    }

    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(timeBetweenShots);
    }
}
